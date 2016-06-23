using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject floortile;

    public int levelWidth;
    public int levelHeight;

    public int hpRegen;
    public int ppRegen;

    public PlayerController player1;
    public PlayerController player2;


    [HideInInspector]
    public List<GameObject> tiles = new List<GameObject>();

    [HideInInspector]
    public int currentTurn;
    [HideInInspector]
    public PlayerController currentPlayer;

	// Use this for initialization
	void Start()
    {
        currentTurn = 1;
        currentPlayer = player1;


        generateLevel();
	}
	
	// Update is called once per frame
	void Update(){}

    public void generateLevel()
    {
        for (int i = 0; i < levelHeight; i++)
        {
            for (int j = 0; j < levelWidth; j++)
            {
                Instantiate(floortile, new Vector3(i, 0, j), Quaternion.identity);
            }
        }
    }
}
