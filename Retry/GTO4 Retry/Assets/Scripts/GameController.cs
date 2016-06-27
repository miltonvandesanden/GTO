using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public InterfaceController interfaceController;

    public Camera camera;

    //game settings
    public int levelWidth;
    public int levelHeight;

    public int ppRegen;
    public float speed;

    //players
    public PlayerController player1;
    public PlayerController player2;

    //prefabs
    public GameObject floortile;
    public GameObject charmander;
    public GameObject bulbasaur;
    public GameObject squirtle;

    //state
    public bool isMoving = false;

    //current selection
    [HideInInspector]
    public GameObject selectedSpawn;
    [HideInInspector]
    public TileController selectedTile;
    [HideInInspector]
    public PokemonController selectedUnit;
    [HideInInspector]
    public Attack selectedAttack;
    [HideInInspector]
    public PokemonController selectedTarget;


    [HideInInspector]
    public List<TileController> tiles = new List<TileController>();

    [HideInInspector]
    public PlayerController currentPlayer;

    // Use this for initialization
    void Start()
    {
        currentPlayer = player1;

        generateLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (selectedTile != null)
        {
            if (selectedSpawn != null)
            {
                if (selectedTile.owner == currentPlayer && selectedTile.pokemon == null)
                {
                    spawnPokemon();
                }
            }
            else if (selectedUnit != null && isMoving)
            {
                int distance = (int) Vector3.Distance(selectedTile.transform.position, selectedUnit.transform.position);

                if (distance <= currentPlayer.pp && selectedTile.pokemon == null)
                {
                    //selectedUnit.transform.position = selectedTile.transform.position;
                    StartCoroutine(MoveFromTo(selectedUnit, selectedUnit.transform.position, selectedTile, speed));
                    currentPlayer.pp -= distance;

                    unselectSelection();

                    interfaceController.deHighlightGUI();
                    interfaceController.deHighlightTiles();
                    interfaceController.deHighlightUnits();
                }
            }
        }
        else if(selectedAttack != null && selectedTarget != null)
        {
            currentPlayer.pp -= selectedAttack.pp;
            selectedTarget.changeCurrentPokemonHP(selectedAttack.damage);

            unselectSelection();

            interfaceController.deHighlightGUI();
            interfaceController.deHighlightTiles();
            interfaceController.deHighlightUnits();

            interfaceController.btnCancelPressed();
        }
    }

    IEnumerator MoveFromTo(PokemonController objectToMove, Vector3 startPosition, TileController endTile, float speed)
    {
        Vector3 endPosition = endTile.transform.position;
        endPosition.y += 0.5f;

        float step = (speed / (startPosition - endPosition).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.transform.position = Vector3.Lerp(startPosition, endPosition, t); // Move objectToMove closer to b

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }

        objectToMove.transform.position = endPosition;

        endTile.pokemon = objectToMove;

        isMoving = false;
        interfaceController.nextTurnBtn.GetComponentInChildren<Text>().text = "NEXT TURN";

        /*PokemonController neighbour = getNeighbouringUnit(endTile);

        if(neighbour != null)
        {
            neighbour.changeCurrentPokemonHP(0 - neighbour.hp);
        }*/
    }

    IEnumerator rotateFromToo(Camera objectToMove, Vector3 startRotation, Vector3 endRotation, float speed)
    {
        float step = (speed / (startRotation - endRotation).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            objectToMove.transform.position = Vector3.Lerp(startRotation, endRotation, t); // Move objectToMove closer to b

            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }

        objectToMove.transform.position = endRotation;
    }

    IEnumerator SpinObject(GameObject go, Quaternion startRotation, Quaternion endRotation)
    {
        //float duration = 30f;
        float elapsed = 0f;
        float spinSpeed = 1f;

        while (startRotation != endRotation)
        {
            elapsed += Time.deltaTime;
            go.transform.Rotate(Vector3.down, spinSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    public PokemonController getNeighbouringUnit(TileController sourceTile)
    {
        PokemonController neighbour = null;

        foreach(TileController tile in tiles)
        {
            if (tile.pokemon != null)
            {
                if (tile.pokemon != sourceTile.pokemon)
                {
                    if ((tile.transform.position.x == sourceTile.transform.position.x && tile.transform.position.z == sourceTile.transform.position.z + 1) || (tile.transform.position.x == sourceTile.transform.position.x && tile.transform.position.z == sourceTile.transform.position.z - 1) || (tile.transform.position.x == sourceTile.transform.position.x + 1 && tile.transform.position.z == sourceTile.transform.position.z) || (tile.transform.position.x == sourceTile.transform.position.x - 1 && tile.transform.position.z == sourceTile.transform.position.z))
                    {
                        neighbour = tile.pokemon;
                    }
                }
            }
        }

        return neighbour;
    }


    public void generateLevel()
    {
        for (int i = 0; i < levelHeight; i++)
        {
            for (int j = 0; j < levelWidth; j++)
            {
                TileController tile = ((GameObject)Instantiate(floortile, new Vector3(i, 0, j), Quaternion.identity)).GetComponent<TileController>();

                if (tile.transform.position.z == 0 || tile.transform.position.z == 1)
                {
                    tile.owner = player1;
                }
                else if (tile.transform.position.z == levelHeight - 1 || tile.transform.position.z == levelHeight - 2)
                {
                    tile.owner = player2;
                }

                tile.gameController = this;
                tiles.Add(tile);
            }
        }
    }

    public void spawnPokemon()
    {
        if (currentPlayer.balls > 0)
        {
            currentPlayer.spawnPokemon(selectedSpawn, selectedTile);
            currentPlayer.balls--;

            interfaceController.btnCancelPressed();

            nextTurn();
        }
    }

    public List<TileController> getMovableTiles(PlayerController player)
    {
        List<TileController> result = new List<TileController>();

        foreach (TileController tile in tiles)
        {
            if ((int) Vector3.Distance(player.currentPokemon.transform.position, tile.transform.position) <= player.pp && tile.pokemon == null)
            {
                result.Add(tile);
            }
        }

        return result;
    }

    public List<TileController> getOwnedTiles(PlayerController player)
    {
        List<TileController> result = new List<TileController>();

        foreach(TileController tile in tiles)
        {
            if(tile.owner == player)
            {
                result.Add(tile);
            }
        }
        return result;
    }

    public void nextTurn()
    {
        StartCoroutine(SpinObject(camera.gameObject, camera.transform.rotation, new Quaternion(90, 180, 0, 0)));

        currentPlayer.pp += ppRegen;

        if(player1.currentPokemon == null)
        {
            currentPlayer = player1;
        }
        else if(player2.currentPokemon == null)
        {
            currentPlayer = player2;
        }
        else if(currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else if(currentPlayer == player2)
        {
            currentPlayer = player1;
        }

        unselectSelection();

        interfaceController.deHighlightGUI();
        interfaceController.deHighlightTiles();
        interfaceController.deHighlightUnits();
    }

    public void unselectSelection()
    {
        selectedSpawn = null;
        selectedTile = null;
        selectedUnit = null;
        selectedAttack = null;
        selectedTarget = null;
    }

    public List<TileController> getTilesWithinAttackRange(Attack attack)
    {
        List<TileController> result = new List<TileController>();

        foreach(TileController tile in tiles)
        {
            if((tile.transform.position.x >= selectedUnit.transform.position.x + attack.minDistance && tile.transform.position.x <= selectedUnit.transform.position.x + attack.maxDistance && tile.transform.position.z == selectedUnit.transform.position.z) || (tile.transform.position.x <= selectedUnit.transform.position.x - attack.minDistance && tile.transform.position.x >= selectedUnit.transform.position.x - attack.maxDistance && tile.transform.position.z == selectedUnit.transform.position.z) || (tile.transform.position.z >= selectedUnit.transform.position.z + attack.minDistance && tile.transform.position.z <= selectedUnit.transform.position.z + attack.maxDistance && tile.transform.position.x == selectedUnit.transform.position.x) || (tile.transform.position.z <= selectedUnit.transform.position.z - attack.minDistance && tile.transform.position.z >= selectedUnit.transform.position.z - attack.maxDistance && tile.transform.position.x == selectedUnit.transform.position.x))
            {
                result.Add(tile);
            }
            /*else if(tile.transform.position.x <= selectedUnit.transform.position.x - attack.minDistance && tile.transform.position.x >= selectedUnit.transform.position.x - attack.maxDistance && tile.transform.position.z == selectedUnit.transform.position.z)
            {
                result.Add(tile);
            }
            else if (tile.transform.position.z >= selectedUnit.transform.position.z + attack.minDistance && tile.transform.position.z <= selectedUnit.transform.position.z + attack.maxDistance && tile.transform.position.x == selectedUnit.transform.position.x)
            {
                result.Add(tile);
            }
            else if (tile.transform.position.z <= selectedUnit.transform.position.z - attack.minDistance && tile.transform.position.z >= selectedUnit.transform.position.z - attack.maxDistance && tile.transform.position.x == selectedUnit.transform.position.x)
            {
                result.Add(tile);
            }*/
        }

        return result;
    }
}
