using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Wave WaveSystem;
    void Update()
    {
        //Player�̈ړ�(��)
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
        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            WaveSystem.CountDestroy();
        }
    }
}