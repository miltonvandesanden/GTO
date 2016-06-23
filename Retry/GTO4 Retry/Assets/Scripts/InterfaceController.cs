using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public GameController gameController;

    public Text player1NameText;
    public Text player1HPText;
    public Text player1PPText;
    public Text player1BallsText;

    public Text player2NameText;
    public Text player2HPText;
    public Text player2PPText;
    public Text player2BallsText;

    public Text currentTurnText;
    public Text currentPlayerText;

    public GameObject ActionPanel;
    public Button attackBtn;
    public Button moveBtn;
    public Button spawnBtn;

    public GameObject pokemonPanel;
    public Button charBtn;
    public Button bulbButton;
    public Button squiBtn;

    public GameObject attackPanel;
    public Button attack1Btn;
    public Button attack2Btn;
    public Button attack3Btn;

    // Use this for initialization
    void Start()
    {
        setPlayerNames();

        pokemonPanel.SetActive(false);
        attackPanel.SetActive(false);

        spawnBtn.interactable = true;
    }
	
	// Update is called once per frame
	void FixedUpdate()
    {
        setPlayerStats();
        setTurnInfo();
    }

    public void setTurnInfo()
    {
        currentTurnText.text = "" + gameController.currentTurn;
        currentPlayerText.text = gameController.currentPlayer.name;
    }

    public void setPlayerNames()
    {
        player1NameText.text = gameController.player1.name;
        player2NameText.text = gameController.player2.name;
    }

    public void setPlayerStats()
    {
        player1BallsText.text = "" + gameController.player1.balls;
        player2BallsText.text = "" + gameController.player2.balls;

        if (gameController.player1.currentPokemon != null)
        {
            player1HPText.text = "" + gameController.player1.currentPokemon.hp;
            player1PPText.text = "" + gameController.player1.currentPokemon.pp;
        }
        else
        {
            player1HPText.text = "0";
            player1PPText.text = "0";
        }

        if (gameController.player2.currentPokemon != null)
        {
            player2HPText.text = "" + gameController.player2.currentPokemon.hp;
            player2PPText.text = "" + gameController.player2.currentPokemon.pp;
        }
        else
        {
            player2HPText.text = "0";
            player2PPText.text = "0";
        }
    }

    public void btnSpawnPressed()
    {
        ActionPanel.SetActive(false);
        attackPanel.SetActive(false);
        pokemonPanel.SetActive(true);
    }

    public void btnCancelPressed()
    {
        ActionPanel.SetActive(true);
        pokemonPanel.SetActive(false);
        attackPanel.SetActive(false);
    }
}
