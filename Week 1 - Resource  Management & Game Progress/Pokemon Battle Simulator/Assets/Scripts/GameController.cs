using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    private PlayerController currentPlayer;

    public Text tbTurn;
    public Text tbCurrentPlayer;

    public GameObject charmander;
    public GameObject squirtle;

    public GameObject panelPokemon;

    public TileController whiteTile;
    private ArrayList tiles = new ArrayList();

    public int gridWidth;
    public int gridHeight;

    private int turn;

    public void Start()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                TileController tile = (TileController) Instantiate(whiteTile, new Vector3(x, 0, z), Quaternion.identity);
                tile.name = "Tile: " + x + "," + z;

                tiles.Add(tile);

                if(tile.transform.position.z == 0 || tile.transform.position.z == 1)
                {
                    tile.setOwner(player1);
                }
                else
                {
                    tile.setOwner(player2);
                }
            }
        }

        currentPlayer = player1;
        turn = 1;

        updateGUI();
    }

    public void showPokemon()
    {
        panelPokemon.SetActive(!panelPokemon.active);
    }

    public void spawnCharmander()
    {
        if(currentPlayer.resourceController.balls > 0)
        {
            despawnPokemon();

            foreach(TileController tile in tiles)
            {
                if(tile.getOwner() == currentPlayer)
                {
                    //tile.renderer.material.color = Color.yellow;
                }
            }

            foreach (TileController tile in tiles)
            {
                if (tile.getPokemon() == null)
                {
                    Object pokemon = Instantiate(charmander, new Vector3(tile.transform.position.x, 0.5f, tile.transform.position.z), Quaternion.identity);
                    pokemon.name = currentPlayer.playerName + ", Charmander";
                    currentPlayer.setCurrentPokemon(pokemon);

                    currentPlayer.resourceController.balls -= 1;
                    endTurn();

                    break;
                }
            }
        }

        /*ArrayList charAttacks = new ArrayList();
        charAttacks.Add(new Attack("tackle", "normal", 30, 80, 1, 2));
        charAttacks.Add(new Attack("ember", "fire", 50, 60, 1, 4));
        charAttacks.Add(new Attack("flamethrower", "fire", 80, 100, 3, 8));*/

    }

    public void spawnSquirtle()
    {
        /*ArrayList squirtAttacks = new ArrayList();
        squirtAttacks.Add(new Attack("tackle", "normal", 30, 80, 1, 2));
        squirtAttacks.Add(new Attack("bubble beam", "water", 50, 60, 1, 4));
        squirtAttacks.Add(new Attack("water gun", "water", 80, 100, 3, 8));*/

        if(currentPlayer.resourceController.balls > 0)
        {
            despawnPokemon();

            foreach (TileController tile in tiles)
            {
                if (tile.getPokemon() == null)
                {
                    Object pokemon = Instantiate(squirtle, new Vector3(tile.transform.position.x, 0.5f, tile.transform.position.z), Quaternion.identity);
                    pokemon.name = currentPlayer.playerName + ", Squirtle";
                    currentPlayer.setCurrentPokemon(pokemon);

                    currentPlayer.resourceController.balls -= 1;
                    endTurn();

                    break;
                }
            }
        }
    }

    public void updateGUI()
    {
        tbCurrentPlayer.text = "Current Player: " + currentPlayer.playerName;
        tbTurn.text = "Turn: " + turn.ToString();

        currentPlayer.resourceController.tbPp.text = "PP: " + currentPlayer.resourceController.pp.ToString();
        currentPlayer.resourceController.tbBalls.text = "Balls: " + currentPlayer.resourceController.balls.ToString();
        currentPlayer.resourceController.tbXp.text = "XP: " + currentPlayer.resourceController.xp.ToString();
    }

    public void endTurn()
    {
        currentPlayer.resourceController.pp += 2;
        turn += 1;

        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else if (currentPlayer == player2)
        {
            currentPlayer = player1;
        }

        updateGUI();
    }

    public void despawnPokemon()
    {
        if (currentPlayer.getCurrentPokemon() != null)
        {
            Destroy(currentPlayer.getCurrentPokemon());
            currentPlayer.setCurrentPokemon(null);
        }
    }
}