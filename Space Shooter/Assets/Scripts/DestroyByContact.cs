using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    //OnTrigger→今回はBoundaryのコライダーを使う→タグ付け判定→対象のタグ付けしたオブジェクトを返す。
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        //other.gameObject : Anteroid   gameobject : Fire1
        Destroy(other.gameObject);
        Destroy(gameObject);

    }
}
