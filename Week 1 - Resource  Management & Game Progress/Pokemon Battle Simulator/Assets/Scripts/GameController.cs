using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public PlayerController player1;
    public PlayerController player2;
    public Transform blackTile;
    public Transform whiteTile;

    private int currentPlayer = 1;
    private ArrayList tiles = new ArrayList();

    public void Start()
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                //if(x % 2 == 0)
                //{
                    if(y % 2 == 0)
                    {
                        Instantiate(whiteTile, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(blackTile, new Vector3(x, y, 0), Quaternion.identity);
                    }
                //}
                //else
                //{
                    /*
                    if (y % 2 == 0)
                    {
                        Instantiate(whiteTile, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(blackTile, new Vector3(x, y, 0), Quaternion.identity);
                    }
                    */
                //}
            }
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
