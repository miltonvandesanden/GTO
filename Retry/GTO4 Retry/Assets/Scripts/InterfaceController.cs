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

    public Text currentPlayerText;

    public GameObject ActionPanel;
    public Button attackBtn;
    public Button moveBtn;
    public Button spawnBtn;
    public Button nextTurnBtn;

    public GameObject pokemonPanel;
    public Button charBtn;
    public Button bulbBtn;
    public Button squiBtn;

    public GameObject attackPanel;
    public Button attack1Btn;
    public Button attack2Btn;
    public Button attack3Btn;

    public Color selectedColor;
    public Color selectableColor;
    public Color actionColor;
    [HideInInspector]
    public Color standardColor = Color.white;

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
        setClickableButtons();
        setTurnInfo();
    }

    public void setTurnInfo()
    {
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

        if(gameController.player1.currentPokemon != null)
        {
            player1HPText.text = "" + gameController.player1.currentPokemon.hp;
        }

        player1PPText.text = "" + gameController.player1.pp;

        if(gameController.player2.currentPokemon != null)
        {
            player2HPText.text = "" + gameController.player2.currentPokemon.hp;
        }
        player2PPText.text = "" + gameController.player2.pp;
    }

    public void highlightOwnedTiles()
    {
        foreach(TileController tile in gameController.getOwnedTiles(gameController.currentPlayer))
        {
            tile.GetComponent<Renderer>().material.color = selectableColor;
        }
    }

    public void highlightMovableTiles()
    {
        foreach (TileController movableTile in gameController.getMovableTiles(gameController.currentPlayer))
        {
            movableTile.GetComponent<Renderer>().material.color = selectableColor;
        }
    }

    public void deHighlightTiles()
    {
        foreach(TileController tile in gameController.tiles)
        {
            tile.GetComponent<Renderer>().material.color = standardColor;
        }
    }

    public void deHighlightGUI()
    {
        charBtn.image.color = standardColor;
        bulbBtn.image.color = standardColor;
        squiBtn.image.color = standardColor;

        attack1Btn.image.color = standardColor;
        attack2Btn.image.color = standardColor;
        attack3Btn.image.color = standardColor;

        attackBtn.image.color = standardColor;
        moveBtn.image.color = standardColor;
        spawnBtn.image.color = standardColor;
    }

    public void deHighlightUnits()
    {
        if(gameController.player1.currentPokemon != null)
        {
            if(gameController.player1.currentPokemon.name == "charmander")
            {
                gameController.player1.currentPokemon.GetComponent<Renderer>().material.color = gameController.charmander.GetComponent<Renderer>().sharedMaterial.color;
            }
            else if(gameController.player1.currentPokemon.name == "bulbasaur")
            {
                gameController.player1.currentPokemon.GetComponent<Renderer>().material.color = gameController.bulbasaur.GetComponent<Renderer>().sharedMaterial.color;
            }
        }

        if(gameController.player2.currentPokemon != null)
        {
            if (gameController.player2.currentPokemon.name == "charmander")
            {
                gameController.player2.currentPokemon.GetComponent<Renderer>().material.color = gameController.charmander.GetComponent<Renderer>().sharedMaterial.color;
            }
            else if (gameController.player2.currentPokemon.name == "bulbasaur")
            {
                gameController.player2.currentPokemon.GetComponent<Renderer>().material.color = gameController.bulbasaur.GetComponent<Renderer>().sharedMaterial.color;
            }
        }
    }

    public void closeAllPanels()
    {
        ActionPanel.SetActive(false);
        attackPanel.SetActive(false);
        pokemonPanel.SetActive(false);
    }

    public void setClickableButtons()
    {
        if(!gameController.isMoving)
        {
            if (gameController.currentPlayer.balls > 0)
            {
                spawnBtn.interactable = true;
            }
            else
            {
                spawnBtn.interactable = false;
            }

            if (gameController.currentPlayer.currentPokemon != null)
            {
                nextTurnBtn.interactable = true;

                if (gameController.currentPlayer.pp > 0)
                {
                    attackBtn.interactable = true;
                    moveBtn.interactable = true;
                }
            }
            else
            {
                nextTurnBtn.interactable = false;
                attackBtn.interactable = false;
                moveBtn.interactable = false;
            }
        }
    }

    public void btnAttackPressed()
    {
        gameController.selectedUnit = gameController.currentPlayer.currentPokemon;
        gameController.selectedUnit.GetComponent<Renderer>().material.color = selectedColor;

        if(gameController.currentPlayer.pp >= gameController.currentPlayer.currentPokemon.attack1.pp)
        {
            attack1Btn.interactable = true;
            attack1Btn.image.color = selectableColor;
        }
        else
        {
            attack1Btn.interactable = false;
        }
        //attack2Btn.image.color = selectableColor;
        //attack3Btn.image.color = selectableColor;

        attack1Btn.GetComponentInChildren<Text>().text = gameController.selectedUnit.attack1.name;

        closeAllPanels();
        attackPanel.SetActive(true);
    }

    public void btnMovePressed()
    {
        gameController.selectedUnit = gameController.currentPlayer.currentPokemon;

        gameController.selectedUnit.GetComponent<Renderer>().material.color = selectedColor;

        gameController.isMoving = true;

        highlightMovableTiles();

        attackBtn.interactable = false;
        moveBtn.interactable = false;
        spawnBtn.interactable = false;

        deHighlightGUI();
        nextTurnBtn.GetComponentInChildren<Text>().text = "Cancel";
        moveBtn.image.color = selectedColor;
    }

    public void btnSpawnPressed()
    {
        charBtn.image.color = selectableColor;
        squiBtn.image.color = selectableColor;
        bulbBtn.image.color = selectableColor;

        closeAllPanels();
        pokemonPanel.SetActive(true);
    }

    public void btnCancelPressed()
    {
        gameController.unselectSelection();

        deHighlightTiles();
        deHighlightGUI();
        deHighlightUnits();

        closeAllPanels();
        ActionPanel.SetActive(true);
    }

    public void btnNextTurnPressed()
    {
        if(gameController.isMoving)
        {
            gameController.unselectSelection();

            deHighlightTiles();
            deHighlightGUI();
            deHighlightUnits();

            gameController.isMoving = false;

            nextTurnBtn.GetComponentInChildren<Text>().text = "NEXT TURN";
        }
        else
        {
            gameController.nextTurn();
        }
    }

    public void btnCharPressed()
    {
        deHighlightGUI();
        highlightOwnedTiles();
        charBtn.image.color = selectedColor;

        gameController.selectedSpawn = gameController.charmander;
    }

    public void btnSquiPressed()
    {
        deHighlightGUI();
        highlightOwnedTiles();
        squiBtn.image.color = selectedColor;

        gameController.selectedSpawn = gameController.charmander;
    }

    public void btnbulbPressed()
    {
        deHighlightGUI();
        highlightOwnedTiles();
        bulbBtn.image.color = selectedColor;

        gameController.selectedSpawn = gameController.bulbasaur;
    }

    public void btnAttack1Pressed()
    {
        gameController.selectedAttack = gameController.currentPlayer.currentPokemon.attack1;

        deHighlightGUI();
        attack1Btn.image.color = selectedColor;
        highlightTilesWithinAttackRange(gameController.selectedAttack);
    }

    public void highlightTilesWithinAttackRange(Attack attack)
    {
        foreach(TileController tile in gameController.getTilesWithinAttackRange(attack))
        {
            tile.GetComponent<Renderer>().material.color = selectableColor;

            if (tile.pokemon != null)
            {
                tile.pokemon.GetComponent<Renderer>().material.color = selectableColor;
            }
        }
    }
}
