using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    [SerializeField]
    private Wave1 WaveSystem1;

    [SerializeField]
    private Wave2 WaveSystem2;

    [SerializeField]
    private Wave3 WaveSystem3;

    //インターバル
    private float WaveInTime1 = 0.0f;
    private float WaveInTime2 = 0.0f;


    //撃破カウンターWave1
    private float Wave1count = 0;
    //撃破カウンターWave2
    private float Wave2count = 0;
    //撃破カウンターWave3
    private float Wave3count = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Wave1count < 44/*中ボスを倒すまで実行に変更*/)
        {
            WaveSystem1.wave1();
        }

        if (Wave2count < 43 && Wave1count >= 44/*中ボスを2体倒すまで実行に変更*/)
        {
            WaveSystem2.wave2();
        }

        if (Wave3count < 50  && Wave2count >= 43 && Wave1count >= 50/*ボスを倒すまで実行*/)
        {
            WaveSystem3.wave3();
            WaveSystem3.EnemyInterval();
        }

    }

    public void wave1Count()
    {
        Wave1count += 1;
    }

    public void WaveInterval1()
    {
        WaveInTime1 += Time.deltaTime;
        Debug.Log(WaveInTime1);
    }

    public void wave3Count()
    {
        Wave2count += 1;
    }

    public void WaveInterval2()
    {
        WaveInTime2 += Time.deltaTime;
    }

}