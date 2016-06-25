using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour
{
    [HideInInspector]
    public GameController gameController;

    [HideInInspector]
    public PlayerController owner;
    [HideInInspector]
    public PokemonController pokemon;
    

	// Use this for initialization
	void Start(){}
	
	// Update is called once per frame
	void Update(){}

    void OnMouseDown()
    {
        gameController.selectedTile = this;
    }
}
