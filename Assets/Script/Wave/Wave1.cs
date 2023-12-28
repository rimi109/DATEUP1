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

    //BossBattleEnemy��
    private int BossBattleCount = 0;

    //BossBattle��Enemy�o��Time
    private float BossBattleTime = 0.0f;

    private bool EnemySpawn = false;

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

        if(MediumBossCount >= 1)
        {
            BossBattleTime += Time.deltaTime;
            EnemySpawn = true;
        }

        Debug.Log(EnemyCrushingWave1Count);
    }

    //Enemies�̏o��
    public void wave1()
    {
        if (!EnemySpawn)
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
                if (EnemySpawnCount < 20)
                {
                    var ghosts = GameObject.FindGameObjectsWithTag("EnemyW1");
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

        //���{�X��
        if (EnemyCrushingWave1Count >= 20 && MediumBossCount < 1)
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

            //���{�X�ƈꏏ�ɏo�Ă���Enemy
            for (int i = 0; i < 4; ++i)
            {
                //enemy���C���X�^���X������(��������)
                //���������G�̈ʒu�������_���ɐݒ肷��
                var rightTopEne = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottomEne = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop x���E�[�@y����[                
                // leftbottom x�����[�@y�����[
                var randomPosXEne = Random.Range(leftBottomEne.z, rightTopEne.z);
                var randomPosZEne = Random.Range(leftBottomEne.x, rightTopEne.x);

                GameObject enemyEne = Instantiate(Enemies[i]);
                enemyEne.transform.position = new Vector3(randomPosXEne, 3, randomPosZEne);
                ++MediumBossCount;
            }
        }

        //���Ԍo�߂ŏo������Enemy
        if(BossBattleTime >= 6.0f && EnemyCrushingWave1Count >= 20 && BossBattleCount == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemyEnemy = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTopEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottomEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosXEnemy2 = Random.Range(leftBottomEnemy2.z, rightTopEnemy2.z);
            var randomPosZEnemy2 = Random.Range(leftBottomEnemy2.x, rightTopEnemy2.x);

            GameObject enemyEnemy2 = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy2.transform.position = new Vector3(randomPosXEnemy2, 3, randomPosZEnemy2);

            ++BossBattleCount;
            BossBattleTime = 0;
        }

        if (BossBattleTime >= 4.0f && EnemyCrushingWave1Count >= 20 && BossBattleCount < 10)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosX = Random.Range(leftBottom.z, rightTop.z);
            var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

            GameObject enemyEnemy = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            var rightTopEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
            var leftBottomEnemy2 = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

            // rightTop x���E�[�@y����[                
            // leftbottom x�����[�@y�����[
            var randomPosXEnemy2 = Random.Range(leftBottomEnemy2.z, rightTopEnemy2.z);
            var randomPosZEnemy2 = Random.Range(leftBottomEnemy2.x, rightTopEnemy2.x);

            GameObject enemyEnemy2 = Instantiate(Enemies[Random.Range(0, 3)]);
            enemyEnemy2.transform.position = new Vector3(randomPosXEnemy2, 3, randomPosZEnemy2);

            ++BossBattleCount;
            BossBattleTime = 0;
        }
    }

    public void CountW1()
    {
        ++EnemyCrushingWave1Count;
    }
}
