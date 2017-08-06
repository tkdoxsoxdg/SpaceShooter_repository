using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    //OnTrigger→今回はBoundaryのコライダーを使う→タグ付け判定→対象のタグ付けしたオブジェクトを返す。
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);// as GameObject;
        }
        //other.gameObject : Anteroid   gameobject : Fire1
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
