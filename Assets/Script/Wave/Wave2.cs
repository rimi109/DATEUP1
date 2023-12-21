using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    [Header("�G�̏o������Script���Q��"),SerializeField]
    private EnemyGenerate EnemySystem;

    [Header(""),SerializeField]
    public GameObject[] Enemies;

    [Header("���{�X"), SerializeField]
    public GameObject[] MediumBoss;

    [SerializeField]
    private int EnemyCrushingWave2Count = 0;

    [SerializeField]
    private int EnemySpawnCount = 0;

    //Medium Boss��
    private int MediumBossCount = 0;

    [Header("kokokok"),SerializeField]
    private int EnemyCrushing;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleEnemy(Enemies);
        ShuffleBoss(MediumBoss);
    }

    void Update()
    {

        if (EnemyCrushingWave2Count == EnemyCrushing)
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

    void ShuffleBoss(GameObject[] num)
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
            if (EnemySpawnCount < 40)
            {
                var ghosts = GameObject.FindGameObjectsWithTag("EnemyW2");
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

        if (EnemyCrushingWave2Count >= 40 && MediumBossCount < 2)
        {
            for (int i = 0; i < 2; ++i)
            {
                //enemy���C���X�^���X������(��������)
                //���������G�̈ʒu�������_���ɐݒ肷��
                var rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.farClipPlane - 50.0f));
                var leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane - 100.0f));

                // rightTop x���E�[�@y����[                
                // leftbottom x�����[�@y�����[
                var randomPosX = Random.Range(leftBottom.z, rightTop.z);
                var randomPosZ = Random.Range(leftBottom.x, rightTop.x);

                GameObject enemy = Instantiate(MediumBoss[i]);
                enemy.transform.position = new Vector3(randomPosX, 3, randomPosZ);

                ++MediumBossCount;
            }
        }
    }

    public void CountW2()
    {
        EnemyCrushingWave2Count += 1;

        //--EnemySpawnCount;
    }
}
