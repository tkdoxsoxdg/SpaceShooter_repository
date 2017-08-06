using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardcount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

	public GUIText gameOverText;
	public GUIText restartText;
	public GUIText scoreText;

	private bool gameOver;
	private bool restart;
	private int score;


    void Start()
    {
        StartCoroutine(SpawnWaves());
		gameOver = false;
		restart = false;
		gameOverText.text = "";
		restartText.text = "";
		score = 0;
		UpdateScore ();


    }
	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
	}

    IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardcount; i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
        
			if (gameOver) {
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

		}
	}

	public void AddScore (int addScoreValue)
	{
		score += addScoreValue;
		//Debug.Log(score);
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.text = "Score:" + score;
	}
	public void GameOver(){
		gameOverText.text = "Game Over!!!";
		gameOver = true;
	
	}
		
}
