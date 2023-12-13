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
        //Player�̈ړ�(��)
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
        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW1"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            EnemySystem.wave1Count();
            Wave1System.CountW1();
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW2"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            EnemySystem.wave2Count();
            Wave2System.CountW2();
        }

        //���������I�u�W�F�N�g�̃^�O��"Enemy"
        if (collision.gameObject.CompareTag("EnemyW3"))
        {
            //�Փ˂�������I�u�W�F�N�g���폜����
            Destroy(collision.gameObject);
            Wave3System.CountW3();
        }
    }
}