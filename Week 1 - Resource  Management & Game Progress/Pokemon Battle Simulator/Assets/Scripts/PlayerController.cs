using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public ResourceController resourceController;
    public string playerName;

    private Object currentPokemon;

	// Use this for initialization
	void Start(){}
	
	// Update is called once per frame
	void Update(){}

    public Object getCurrentPokemon()
    {
        return currentPokemon;
    }

    public void setCurrentPokemon(Object currentPokemon)
    {
        this.currentPokemon = currentPokemon;
    }
}
