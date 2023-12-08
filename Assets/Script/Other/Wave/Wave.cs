using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wave : MonoBehaviour
{

    //�G�v���n�u
    public GameObject[] enemyPrefab;
    //�G�����_��
    private int number;
    //���ԊԊu�̍ŏ��l
    public float minTime = 0.5f;
    //���ԊԊu�̍ő�l
    public float maxTime = 1f;
    //X���W�̍ŏ��l
    public float xMinPosition = -1f;
    //X���W�̍ő�l
    public float xMaxPosition = 1f;
    //Y���W�̍ŏ��l
    public float yMinPosition = 3f;
    //Y���W�̍ő�l
    public float yMaxPosition = 3f;
    //Z���W�̍ŏ��l
    public float zMinPosition = -1f;
    //Z���W�̍ő�l
    public float zMaxPosition = 1f;
    //�G�������ԊԊu
    private float interval;
    //�o�ߎ���
    private float time = 0f;
    //�G�̐�����
    private int EnemyCount = 0;
    //���Đ�
    private int DestroyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        //���ԊԊu�����肷��
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        //Wave1

        //���j�J�E���^�[
        if (DestroyCount <= 3)
        {
            //3�̖ڂ܂ł�Enemy���o�Ă�����
            if (EnemyCount < 3)
            {
                //���Ԍv��
                time += Time.deltaTime;
                //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
                if (time > interval)
                {
                    number = Random.Range(0, enemyPrefab.Length);
                    //enemy���C���X�^���X������(��������)
                    GameObject enemy = Instantiate(enemyPrefab[number]);
                    //���������G�̈ʒu�������_���ɐݒ肷��
                    enemy.transform.position = GetRandomPosition();
                    //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                    time = 0f;
                    //���ɔ������鎞�ԊԊu�����肷��
                    interval = GetRandomTime();
                    //�����J�E���^�[
                    EnemyCount += 1;
                }
            }
        }

        //Wave2

        //���j�J�E���^�[
        if (3 <= DestroyCount && DestroyCount <= 7)
        {
            //7�̖ڂ܂ł�Enemy���o�Ă�����
            if (EnemyCount < 7)
            {
                //���Ԍv��
                time += Time.deltaTime;
                //�o�ߎ��Ԃ��������ԂɂȂ����Ƃ�(�������Ԃ��傫���Ȃ����Ƃ�)
                if (time > interval)
                {
                    number = Random.Range(0, enemyPrefab.Length);
                    //enemy���C���X�^���X������(��������)
                    GameObject enemy = Instantiate(enemyPrefab[number]);
                    //���������G�̈ʒu�������_���ɐݒ肷��
                    enemy.transform.position = GetRandomPosition();
                    //�o�ߎ��Ԃ����������čēx���Ԍv�����n�߂�
                    time = 0f;
                    //���ɔ������鎞�ԊԊu�����肷��
                    interval = GetRandomTime();
                    //�����J�E���^�[
                    EnemyCount += 1;
                }
            }
        }
    }

    public void CountDestroy()
    {
        DestroyCount += 1;
    }

    //�����_���Ȏ��Ԃ𐶐�����֐�
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
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