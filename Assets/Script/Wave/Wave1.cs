using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;

    [Header("�P�F�̓G"), SerializeField]
    public GameObject[] Enemies;

    [Header("���{�X"), SerializeField]
    public GameObject[] MediumBoss;

    [SerializeField]
    private int EnemyCrushingWave1Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    [Header("kokokok"), SerializeField]
    private int EnemyCrushing;

    //���j�J�E���^�[Wave1
    private int wave1Count = 0;

    //Enemy��
    private int EnemyCount = 0;

    //Medium Boss��
    private int MediumBossCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyCount = 0;
        wave1Count = 0;
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

    void Update()
    {
        if (EnemyCount == 1 && wave1Count == 1)
        {
            EnemySystem.WaveInterval1();
        }

        Debug.Log(EnemyCrushingWave1Count);
    }

    //Enemies�̏o��
    public void wave1()
    {
        if (EnemySpawnCount == 0)
        {
            for (int i = 0; i < 6; ++i)
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
            if (EnemySpawnCount < 20) {
                var ghosts = GameObject.FindGameObjectsWithTag("EnemyW1");
                if(ghosts.Length < 6)
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

        if(EnemyCrushingWave1Count >= 20 && MediumBossCount < 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemy = Instantiate(MediumBoss[Random.Range(0, 3)]);
            enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

            ++MediumBossCount;
        }
    }

    public void CountW1()
    {
        ++EnemyCrushingWave1Count;
        //--EnemySpawnCount;
    }
}
