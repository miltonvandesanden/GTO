using UnityEngine;

public class TileController : MonoBehaviour
{
    private PokemonController pokemon;
    private PlayerController owner;

	// Use this for initialization
	void Start()
    {
    }
	
	// Update is called once per frame
	void Update(){}

    public PokemonController getPokemon()
    {
        return pokemon;
    }

    public void setPokemon(PokemonController pokemon)
    {
        this.pokemon = pokemon;
    }

    public PlayerController getOwner()
    {
        return owner;
    }

    public void setOwner(PlayerController owner)
    {
        this.owner = owner;
    }


}
