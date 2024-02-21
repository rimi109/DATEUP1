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
    private float Wave1_count = 0;
    //撃破カウンターWave2
    private float Wave2_count = 0;
    //撃破カウンターWave3
    private float Wave3_count = 0;

    [Header(""), SerializeField]
    private HeartGenerate Heart_Generate;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Wave2_count < 1)
        {
            WaveSystem1.wave1();
        }

        if (WaveInTime1 >= 10.0f && Wave2_count < 43)
        {
            WaveSystem2.wave2();
        }

        if (WaveInTime2 >= 10.0f && Wave2_count >= 43 && Wave3_count < 50)
        {
            WaveSystem3.wave3();
            WaveSystem3.EnemyInterval();
        }

        if (Wave2_count >= 1)
        {
            WaveInTime1 += Time.deltaTime;
        }

        if (Wave2_count >= 43)
        {
            WaveInTime2 += Time.deltaTime;
        }
    }

    public void wave1Count()
    {
        Wave1_count += 1;
    }

    public void wave3Count()
    {
        Wave2_count += 1;
        Heart_Generate.heart();
    }

}