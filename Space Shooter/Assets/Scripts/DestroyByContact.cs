using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
	public int scoreValue;
    private GameController gameController;
    //OnTrigger→今回はBoundaryのコライダーを使う→タグ付け判定→対象のタグ付けしたオブジェクトを返す。
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Can't find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);// as GameObject;
			gameController.GameOver();

        }
        //other.gameObject : Anteroid   gameobject : Fire1
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
