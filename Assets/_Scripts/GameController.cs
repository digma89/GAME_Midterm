using UnityEngine;
using System.Collections;

// reference to the UI namespace
using UnityEngine.UI;

// reference to manage my scenes
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;


    public int enemyCount;
	public GameObject enemy;
    public GameObject Hero;
    

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++
    private int _livesValue;
    private int _scoreValue;

	
	// Use this for initialization
	void Start () {
		this._GenerateEnemies ();
        this.LivesValue = 5;
        this.ScoreValue = 0;
        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // PUBLIC PROPERTIES +++++++++++++++++++++++++++
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this.LivesLabel.text = "Lives: " + 0;
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }



	// generate Clouds
	private void _GenerateEnemies() {
      
            for (int count = 0; count < this.enemyCount; count++)
            {
                Instantiate(enemy);
            }      
	}

    //end game function
    private void _endGame()
    {
        this.GameOverLabel.gameObject.SetActive(true);
        this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.FinalScoreLabel.gameObject.SetActive(true);
        this.RestartButton.gameObject.SetActive(true);
        this.Hero.SetActive(false);
    }

    public void RestartButton_Click()
    {
        SceneManager.LoadScene("Main");
    }
}
