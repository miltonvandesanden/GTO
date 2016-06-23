using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PokemonController : MonoBehaviour
{
    [HideInInspector]
    public string name;
    //0 is down, 1 is left, 2 is up, 3 is right
    public int direction;

    public int hp;
    public int pp;
    public decimal movementModifier;

    public List<Attack> attacks = new List<Attack>();

    // Use this for initialization
    void Start(){}

    // Update is called once per frame
    void Update() { }
}
