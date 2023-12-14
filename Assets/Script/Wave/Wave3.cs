using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //�G�v���n�u��
    public GameObject enemyPrefabW;
    //�G���X�g
    public GameObject[] Enemies = new GameObject[12];
    //���j�J�E���^�[Wave1
    private float wave3Count = 0;
    //Enemy�̃C���^�[�o��
    private float EnemyIn = 0.0f;
    //Enemy��
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(Enemies);
    }

    void Shuffle(GameObject[] num)
    {
        for (int i = 0; i < num.Length; i++)
        {
            GameObject temp = num[i]; // ���݂̗v�f��a���Ă���
            int randomIndex = Random.Range(0, num.Length); // ����ւ����������_���ɑI��
            num[i] = num[randomIndex]; // ���݂̗v�f�ɏ㏑��
            num[randomIndex] = temp; // ����ւ����ɗa���Ă������v�f��^����
        }
    }

    public void EnemyInterval()
    {
        EnemyIn += 1.0f * Time.deltaTime;
    }

    //Enemies�̏o��
    public void wave3()
    {
        //BOSS
        if (wave3Count >= 0 && EnemyCount == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabW);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        //Enemies
        if (EnemyIn >= 2.0f && EnemyCount == 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[0]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 2)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[1]);
            enemy.transform.position = new Vector3(randomPosX, -3, randomPosZ);
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 3)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[2]);
            enemy.transform.position = new Vector3(randomPosX, randomPosZ, 0);
            EnemyCount += 1;
        }

        if (EnemyIn >= 2.0f && EnemyCount == 4)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[3]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 1 && EnemyCount == 5)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[4]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 2 && EnemyCount == 6)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[5]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 3 && EnemyCount == 7)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[6]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 4 && EnemyCount == 8)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[7]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 5 && EnemyCount == 9)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[8]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 6 && EnemyCount == 10)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[9]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 7 && EnemyCount == 11)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[10]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

        if (wave3Count == 8 && EnemyCount == 12)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(Enemies[11]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            EnemyCount += 1;
        }

    }

    public void CountW3()
    {
        wave3Count += 1;
    }
}
