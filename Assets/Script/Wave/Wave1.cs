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
    private float wave1Count = 0;
    //Enemy��
    private float EnemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (EnemyCount == 3 && wave1Count == 3)
        {
            EnemySystem.WaveInterval1();
        }
    }

    //Enemies�̏o��
    public void wave1()
    {
        if (EnemyCount == 0 && wave1Count == 0)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(enemyPrefabR);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 1 && wave1Count == 1)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(enemyPrefabG);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }

        if (EnemyCount == 2 && wave1Count == 2)
        {
            //enemy���C���X�^���X������(��������)
            //���������G�̈ʒu�������_���ɐݒ肷��
            GameObject enemy = Instantiate(enemyPrefabB);
            enemy.transform.position = GetRandomPosition();
            EnemyCount += 1;
        }
    }

    public void CountW1()
    {
        wave1Count += 1;
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
