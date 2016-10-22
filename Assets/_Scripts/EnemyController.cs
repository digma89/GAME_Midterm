/*
 **
 *Author: Diego Rodriguez 
 *ID 300824022
 *Title: MidTerm
 *10/22/2016
 *
 * This Class defines the behavior for the enemies and detects collisions
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public Speed speed;
	public Boundary boundary;

	// PRIVATE INSTANCE VARIABLES
	private float _CurrentSpeed;
	private float _CurrentDrift;
    private GameController controllerG;  // To access the GameObjectController class 
    private AudioSource EnemySound;
				


	// Use this for initialization
	void Start () {
		this._Reset ();            
        //To access the GameObjectController class 
        controllerG = FindObjectOfType(typeof(GameController)) as GameController;
        this.EnemySound = GetComponent<AudioSource>();
				

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 currentPosition = gameObject.GetComponent<Transform> ().position;
		currentPosition.y -= this._CurrentSpeed;
		gameObject.GetComponent<Transform> ().position = currentPosition;
		
		// Check bottom boundary
		if (currentPosition.y <= boundary.yMin) {
            this.controllerG.ScoreValue += 10;
			this._Reset();            
		}
	}

	// resets the gameObject
	private void _Reset() {        
		this._CurrentSpeed = Random.Range (speed.minSpeed, speed.maxSpeed);
		Vector2 resetPosition = new Vector2 (Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
		gameObject.GetComponent<Transform> ().position = resetPosition;
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        //when pick up a coin
        if (other.gameObject.CompareTag("Player"))
        {
            this.EnemySound.Play();
            this.controllerG.LivesValue -= 1;
            _Reset();
        }

    }


}
