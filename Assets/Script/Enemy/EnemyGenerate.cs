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
        if (Wave2count < 1)
        {
            WaveSystem1.wave1();
        }

        if (WaveInTime1 >= 5.0f && Wave2count < 43)
        {
            WaveSystem2.wave2();
        }

        if (WaveInTime2 >= 5.0f && Wave2count >= 43 && Wave3count < 50)
        {
            WaveSystem3.wave3();
            WaveSystem3.EnemyInterval();
        }

        if (Wave2count >= 1)
        {
            WaveInTime1 += Time.deltaTime;
        }

        if (Wave2count >= 43)
        {
            WaveInTime2 += Time.deltaTime;
        }
    }

    public void wave1Count()
    {
        Wave1count += 1;
    }

    public void wave3Count()
    {
        Wave2count += 1;
    }

}