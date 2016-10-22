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
	public int enemyCount;
	public GameObject enemy;

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++
    private int _livesValue;
    private int _scoreValue;

	
	// Use this for initialization
	void Start () {
		this._GenerateEnemies ();
        this.LivesValue = 5;
        this.ScoreValue = 0;

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
            if (this._livesValue < 0)
            {

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
}
