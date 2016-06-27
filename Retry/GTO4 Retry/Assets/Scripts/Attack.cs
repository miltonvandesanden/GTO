using UnityEngine;
using System.Collections;

public class Attack
{
    public string name = "ATTACK";
    public int damage = 0;
    public int maxDistance = 0;
    public int minDistance = 0;
    public int pp = 0;

    
    //0 is around, 1 is front, 2 is back, 3 is sides
    public int direction = 0;

    public Attack(string name, int damage, int maxDistance, int minDistance, int pp)
    {
        this.name = name;
        this.damage = damage;
        this.maxDistance = maxDistance;
        this.minDistance = minDistance;
        this.pp = pp;
        //this.direction = direction;
    }
}
