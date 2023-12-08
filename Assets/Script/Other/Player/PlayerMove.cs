using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Wave WaveSystem;
    void Update()
    {
        //Playerの移動(仮)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, -0.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.5f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.5f, 0f, 0f);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //当たったオブジェクトのタグが"Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //衝突した相手オブジェクトを削除する
            Destroy(collision.gameObject);
            WaveSystem.CountDestroy();
        }
    }
}