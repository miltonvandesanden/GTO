using UnityEngine;
using System.Collections;

public class PokemonController : MonoBehaviour
{
    public string name;
    public int health;
    public int speed;
    public ArrayList attacks = new ArrayList(4);

    // Use this for initialization
    void Start(string name, int health, int speed, ArrayList attacks)
    {
        this.name = name;
        this.health = health;
        this.speed = speed;
        this.attacks = attacks;
    }
	
    public bool attack(PokemonController otherPokemon, Attack attack)
    {
        return otherPokemon.getAttacked(attack);
    }

    public bool getAttacked(Attack attack)
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
    }
}
