using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    public Text winner;

	// Use this for initialization
	void Start()
    {
        winner.text = GameController.winner.name;
    }
	
	// Update is called once per frame
	void Update(){}

    public void btnBackToMenuPressed()
    {
        SceneManager.LoadScene(0);
    }
}
