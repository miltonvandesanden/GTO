using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public InterfaceController interfaceController;

    //game settings
    public int levelWidth;
    public int levelHeight;
    public int ppRegen;

    //players
    public PlayerController player1;
    public PlayerController player2;

    //prefabs
    public GameObject floortile;
    public GameObject charmander;
    public GameObject bulbasaur;
    public GameObject squirtle;

    //current selection
    [HideInInspector]
    public GameObject selectedSpawn;
    [HideInInspector]
    public TileController selectedTile;
    [HideInInspector]
    public PokemonController selectedUnit;


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
                    spawnPokemon(selectedSpawn.name);
                }
            }

            if (selectedUnit != null)
            {
                int distance = (int) Vector3.Distance(selectedTile.transform.position, selectedUnit.transform.position);

                if (distance <= currentPlayer.pp && selectedTile.pokemon == null)
                {
                    selectedUnit.transform.position = selectedTile.transform.position;
                    currentPlayer.pp -= distance;

                    unselectSelection();

                    interfaceController.deHighlightGUI();
                    interfaceController.deHighlightTiles();
                    interfaceController.deHighlightUnits();
                }
            }
        }
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

    public void spawnPokemon(string whichPokemon)
    {
        if (currentPlayer.balls > 0)
        {
            switch (whichPokemon)
            {
                case "charmander":
                    currentPlayer.spawnPokemon(charmander, selectedTile.transform.position);
                    break;
                default:
                    break;
            }
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
        currentPlayer.pp += ppRegen;

        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else
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
    }
}
