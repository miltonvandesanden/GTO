using UnityEngine;
using System.Collections;

public class Attack
{
    public string name = "ATTACK";
    public int damage = 0;
    public int range = 0;
    public int distance = 0;

    
    //0 is around, 1 is front, 2 is back, 3 is sides
    public int direction = 0;

    public Attack(string name, int damage, int range, int distance, int direction)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
        this.distance = distance;
        this.direction = direction;
    }
}
