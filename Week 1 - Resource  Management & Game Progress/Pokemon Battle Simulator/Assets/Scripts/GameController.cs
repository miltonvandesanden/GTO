using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
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
}
