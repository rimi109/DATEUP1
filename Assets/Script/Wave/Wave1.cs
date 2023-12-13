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

    private bool fast_flag;

    // Start is called before the first frame update
    void Start()
    {
        fast_flag = false;
    }

    void Update()
    {
        if (EnemyCount == 3 && wave1Count == 3)
        {
            EnemySystem.WaveInterval1();
        }
        Debug.Log(EnemyCount);
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
        if (!fast_flag)
        {
            EnemyCount = 0;
            fast_flag = true;
        }

        if (EnemyCount == 0 && wave1Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop   = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabR);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave1Count == 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabG);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave1Count == 2)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabB);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }
    }

    public void CountW1()
    {
        wave1Count += 1;
    }
}
