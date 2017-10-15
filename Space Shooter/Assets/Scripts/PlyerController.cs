using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//自前のクラスをインスペクタから編集できるようにする
[System.Serializable]

//この後にでてくる移動できる位置の限界値の設定で、クラスを定義
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlyerController : MonoBehaviour {
    //コントロールに必要な変数を宣言
    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform[] shotSpawns;
    //public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private AudioSource audiosorce_p;



    void Start()
    {
        //Rigidbodyのコンポーネントを呼び出す
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {

        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (var shotSpawn in shotSpawns)
            {
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            audiosorce_p = GetComponent<AudioSource>();
            audiosorce_p.Play();

        }

    }

    void FixedUpdate()
    {
        // Horizontal = x軸 Vertical =z軸をGetAxisの入力値（規定値）を代入
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //機体の動きを設定。深さvelocityに機体の座標 × 機体スピードを代入
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //上記状態だと、どこでも動けてしまうので制限をかける
        rb.position = new Vector3
            (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );

        //横移動したときの、機体の傾きを設定。移動するスピード × tiltで設定した値を rotation
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

    }
    }

