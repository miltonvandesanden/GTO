using UnityEngine;
using System.Collections;

public class PokemonController : MonoBehaviour
{
    public int level;
    public ArrayList attacks;
    public string pokemonName;
    public int health;

	// Use this for initialization
	void Start(string name)
    {
        this.name = name;

        if(name == "charmander")
        {
            //attacks.Add(new Attack("tackle", "normal", 50));
        }
    }
	
    public void attack(PokemonController enemyPokemon, Attack attack)
    {
        enemyPokemon.getAttacked(attack);
    }

    public void getAttacked(Attack attack)
    {

    }
}
