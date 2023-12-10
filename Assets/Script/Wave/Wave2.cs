using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2 : MonoBehaviour
{
    [SerializeField]
    private EnemyGenerate EnemySystem;
    //�G���X�g
    public GameObject[] Enemies = new GameObject[6];
    //X���W�̍ŏ��l
    public float xMinPosition = -10f;
    //X���W�̍ő�l
    public float xMaxPosition = 10f;
    //Y���W�̍ŏ��l
    public float yMinPosition = 0f;
    //Y���W�̍ő�l
    public float yMaxPosition = 10f;
    //Z���W�̍ŏ��l
    public float zMinPosition = 10f;
    //Z���W�̍ő�l
    public float zMaxPosition = 20f;
    //���j�J�E���^�[Wave1
    private float wave2Count = 0;
    //Enemy��
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Shuffle(Enemies);
    }

    void Update()
    {

        if (wave2Count == 6)
        {
            EnemySystem.WaveInterval2();
        }
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

    //Enemies�̏o��
    public void wave2()
    {
        if (EnemyCount == 0 && wave2Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[0]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave2Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[1]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave2Count == 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[2]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 3 && wave2Count == 2)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[3]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 4 && wave2Count == 3)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[4]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 5 && wave2Count == 4)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(Enemies[5]);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }
    }

    public void CountW2()
    {
        wave2Count += 1;
    }

    //�����_���Ȉʒu�𐶐�����֐�
    private Vector3 GetRandomPosition()
    {
        //���ꂼ��̍��W�������_���ɐ�������
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3�^��Position��Ԃ�
        return new Vector3(x * 60, y, z * 60);
    }

}
