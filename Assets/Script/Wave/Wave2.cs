using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //�G���X�g
    public GameObject[] Enemies = new GameObject[6];
    //���j�J�E���^�[Wave1
    private float wave2Count = 0;
    //Enemy��
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleEnemy(Enemies);
    }

    void Update()
    {

        if (wave2Count == 6)
        {
            EnemySystem.WaveInterval2();
        }
    }

    void ShuffleEnemy(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // ���݂̗v�f��a���Ă���
            int randomIndex = Random.Range(0, num.Length); // ����ւ����������_���ɑI��
            num[i] = num[randomIndex]; // ���݂̗v�f�ɏ㏑��
            num[randomIndex] = temp; // ����ւ����ɗa���Ă������v�f��^����
        }
    }

    //Enemies�̏o��
    public void wave2()
    {
        if (EnemyCount == 0 && wave2Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[0]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave2Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[1]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave2Count == 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[2]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 3 && wave2Count == 2)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[3]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 4 && wave2Count == 3)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[4]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyCount == 5 && wave2Count == 4)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 30.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 30.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[5]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }
    }

    public void CountW2()
    {
        wave2Count += 1;
    }
}
