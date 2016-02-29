using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceController : MonoBehaviour
{
    public Text tbBalls;
    public Text tbPp;
    public Text tbXp;

    public int balls;
    public int pp;
    public int xp;

	// Use this for initialization
	void Start()
    {
        tbBalls.text = "Balls: " + balls;
        tbPp.text = "PP: " + pp;
        tbXp.text = "XP: " + xp;
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate()
    {
        tbBalls.text = "Balls: " + balls;
        tbPp.text = "PP: " + pp;
        tbXp.text = "XP: " + xp;
	}

    public void endTurn()
    {
        pp += 2;
    }
}
