using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public PlayerController player1;
    //public PlayerController player2;
    private PlayerController currentPlayer;

    public PokemonController charmander;

    public GameObject panelPokemon;

    public Transform whiteTile;
    private ArrayList tiles = new ArrayList();

    public int gridWidth;
    public int gridHeight;

    public void Start()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Instantiate(whiteTile, new Vector3(x, y, 0), Quaternion.identity);
            }
        }

        currentPlayer = player1;
    }

    public void showPokemon()
    {
        panelPokemon.SetActive(!panelPokemon.active);
    }

    public void spawnCharmander()
    {
        ArrayList charAttacks = new ArrayList();
        charAttacks.Add(new Attack("tackle", "normal", 30, 80, 1, 2));
        charAttacks.Add(new Attack("ember", "fire", 50, 60, 1, 4));
        charAttacks.Add(new Attack("flamethrower", "fire", 80, 100, 3, 8));

        print("hi");
        if (currentPlayer == player1)
        {
            print("bye");
            Instantiate(currentPlayer.charmander, new Vector3(5, 9.5f, 4.5f), Quaternion.identity);
        }
    }

    public void spawnSquirtle()
    {
        ArrayList squirtAttacks = new ArrayList();
        squirtAttacks.Add(new Attack("tackle", "normal", 30, 80, 1, 2));
        squirtAttacks.Add(new Attack("bubble beam", "water", 50, 60, 1, 4));
        squirtAttacks.Add(new Attack("water gun", "water", 80, 100, 3, 8));

        print("hi");
        if (currentPlayer == player1)
        {
            print("bye");
            Instantiate(currentPlayer.squirtle, new Vector3(0, 9.5f, 4.5f), Quaternion.identity);
        }
    }


    /*
    public ResourceController resourceController;
    public Transform charmander;

    public Text tbTurn;
    public int turn;

    // Use this for initialization
    void Start ()
    {
        tbTurn.text = "Turn: " + turn;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        tbTurn.text = "Turn: " + turn;
    }

    public void endTurn()
    {
        turn += 1;

        resourceController.endTurn();
    }

    public void spawnPokemon()
    {
        if (resourceController.balls > 0)
        {
            resourceController.balls -= 1;

            Instantiate(charmander, new Vector3(resourceController.balls * 2.0f, 0, 0), Quaternion.identity);
        }
    }
    */
}
