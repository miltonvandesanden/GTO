using UnityEngine;
using System.Collections;

public class PokemonController : MonoBehaviour
{
    //public int health;
    //public int speed;
    //private ArrayList attacks = new ArrayList(4);
    private PlayerController owner;

    // Use this for initialization
    void Start(){}

    public PlayerController getOwner()
    {
        return owner;
    }

    public void setOwner(PlayerController owner)
    {
        this.owner = owner;
    }

    /*public PokemonController(ArrayList attacks, PlayerController owner)
    {
        this.attacks = attacks;
        this.owner = owner;
    }*/
	
    /*public bool attack(PokemonController otherPokemon, Attack attack)
    {
        return otherPokemon.getAttacked(attack);
    }*/

    /*public bool getAttacked(Attack attack)
    {
        bool hit = false;

        if (Random.Range(1, 100) - attack.getAccuracy() > 0)
        {
            health -= attack.getPower();

            hit = true;
        }

        if (health < 0)
        {
            health = 0;
        }

        return hit;
    }*/
}
