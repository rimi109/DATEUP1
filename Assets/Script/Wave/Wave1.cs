using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;

    //�G�v���n�u��
    public GameObject enemyPrefabR;
    //�G�v���n�u��
    public GameObject enemyPrefabG;
    //�G�v���n�u��
    public GameObject enemyPrefabB;
    //���j�J�E���^�[Wave1
    private float wave1Count = 0;

    //Enemy��
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        wave1Count = 0;
    }

    void Update()
    {
        if (EnemyCount == 3 && wave1Count == 3)
        {
            EnemySystem.WaveInterval1();
          
        }
    }

    void ShufflePosX(float[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            float temp = num[i]; // ���݂̗v�f��a���Ă���
            int randomIndex = Random.Range(0, num.Length); // ����ւ����������_���ɑI��
            num[i] = num[randomIndex]; // ���݂̗v�f�ɏ㏑��
            num[randomIndex] = temp; // ����ւ����ɗa���Ă������v�f��^����
        }
    }

    void ShufflePosZ(float[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            float temp = num[i]; // ���݂̗v�f��a���Ă���
            int randomIndex = Random.Range(0, num.Length); // ����ւ����������_���ɑI��
            num[i] = num[randomIndex]; // ���݂̗v�f�ɏ㏑��
            num[randomIndex] = temp; // ����ւ����ɗa���Ă������v�f��^����
        }
    }

    //Enemies�̏o��
    public void wave1()
    {
        if (EnemyCount == 0 && wave1Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, -1.0f, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabR);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            ++EnemyCount;
        }
    }

    public void CountW1()
    {
        wave1Count += 1;
    }
}
