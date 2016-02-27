using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResourceController : MonoBehaviour
{
    public Text tbBalls;
    public Text tbPp;

    public int balls;
    public int pp;

	// Use this for initialization
	void Start()
    {
        tbBalls.text = "Balls: " + balls;
        tbPp.text = "PP: " + pp;
    }
	
	// FixedUpdate is called once per frame
	void FixedUpdate()
    {
        tbBalls.text = "Balls: " + balls;
        tbPp.text = "PP: " + pp;
	}

    public void endTurn()
    {
        pp += 2;
    }
}
