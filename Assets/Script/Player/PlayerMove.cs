using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;

    [SerializeField]
    private Wave1 Wave1System;

    [SerializeField]
    private Wave2 Wave2System;

    [SerializeField]
    private Wave3 Wave3System;

    void Update()
    {
        //Playerの移動(仮)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 0.2f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -0.2f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.2f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.2f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW1"))
        {
            //衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            EnemySystem.wave1Count();
            Wave1System.CountW1();
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            //衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            EnemySystem.wave2Count();
            Wave2System.CountW2();
        }

        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            //衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            Wave3System.CountW3();
        }
    }
}