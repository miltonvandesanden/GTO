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

    public void spawnPokemon(GameObject pokemon, Vector3 position)
    {
        if(currentPokemon != null)
        {
            despawnPokemon();
        }

        currentPokemon = ((GameObject)Instantiate(pokemon, position, Quaternion.identity)).GetComponent<PokemonController>();
        currentPokemon.gameController = gameController;
    }

    public void despawnPokemon()
    {
        Destroy(currentPokemon.gameObject);
        currentPokemon = null;
    }

}
