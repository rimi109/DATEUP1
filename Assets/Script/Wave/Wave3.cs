using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave3 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //�G�v���n�u��
    public GameObject enemyPrefabBoss;
    //�G���X�g
    public GameObject[] Enemies = new GameObject[12];
    //���j�J�E���^�[Wave1
    private float wave3Count = 0;
    //Enemy�̃C���^�[�o��
    private float EnemyIn = 0.0f;
    //Enemy��
    private float EnemyCount = 0;

    [SerializeField]
    private int EnemyCrushingWave1Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

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
        if (EnemyIn >= 5.0f)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(enemyPrefabBoss);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
            ++EnemySpawnCount;
        }

        if (EnemySpawnCount == 1)
        {
            for (int i = 0; i < 12; ++i)
            {
                //enemy���C���X�^���X������(��������)
                //���������G�̈ʒu�������_���ɐݒ肷��
                var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop x���E�[�@y����[                
                // leftbottom x�����[�@y�����[
                var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                GameObject enemy = Instantiate(Enemies[EnemySpawnCount]);
                enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                ++EnemySpawnCount;
            }
        }
        else
        {
            if (EnemySpawnCount < 20)
            {
                var ghosts = GameObject.FindGameObjectsWithTag("EnemyW3");
                if (ghosts.Length < 6)
                {
                    //enemy���C���X�^���X������(��������)
                    //���������G�̈ʒu�������_���ɐݒ肷��
                    var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                    var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                    // rightTop x���E�[�@y����[                
                    // leftbottom x�����[�@y�����[
                    var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                    var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                    GameObject enemy = Instantiate(Enemies[Random.Range(0, 3)]);
                    enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);
                    ++EnemySpawnCount;
                }
            }
        }

    }

    public void CountW3()
    {
        wave3Count += 1;
    }
}
