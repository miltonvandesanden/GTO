using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public new string name;
    //resources
    public int pp;
    public int balls;

    [HideInInspector]
    public PokemonController currentPokemon;

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update(){}

    public void spawnPokemon(GameObject pokemon, TileController tile)
    {
        if(currentPokemon != null)
        {
            despawnPokemon();
        }

        Vector3 position = tile.transform.position;
        position.y += 0.5f;

        currentPokemon = ((GameObject)Instantiate(pokemon, position, Quaternion.identity)).GetComponent<PokemonController>();

        currentPokemon.gameController = gameController;
        currentPokemon.owner = this;
        tile.pokemon = currentPokemon;
        if(currentPokemon.name == "charmander")
        {
            currentPokemon.attack1 = new Attack("Ember", -20, 2, 2, 2);
        }
        else if(currentPokemon.name == "bulbasaur")
        {
            currentPokemon.attack1 = new Attack("Vine Whip", -30, 1, 1, 2);
        }
    }

    public void despawnPokemon()
    {
        Destroy(currentPokemon.gameObject);
        currentPokemon = null;

        gameController.nextTurn();
    }
}
