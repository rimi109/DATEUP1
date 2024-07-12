using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVProcessing : MonoBehaviour
{
    [Header("“G‚Ìî•ñ‚ğæ“¾")]
    public MonsterData[] monsterData;

    [Tooltip("Enemy‚ÌTextAsset‚ğİ’è")]
    private TextAsset enemyTextAsset;

    [Header("Wave‚Ìî•ñ‚ğæ“¾")]
    public WaveDate[] waveDate;

    [Tooltip("Wave‚ÌTextAsset‚ğİ’è")]
    private TextAsset waveDateTextAsset;

    [Header("Enemy‚ªˆê‰ñWave‚ÅoŒ»‚·‚éÅ‘åŒÂ”‚Ìî•ñ‚ğæ“¾")]
    public EnemySpawnMaxDate[] enemySpawnMaxDate;

    [Tooltip("EnemySpawnMaxDate‚ÌTextAsset‚ğİ’è")]
    private TextAsset enemySpawnMaxDateTextAsset;


    void Start()
    {
        //“G‚ÌExcel‚ğæ“¾
        enemyTextAsset = Resources.Load("MonsterDate", typeof(TextAsset)) as TextAsset;
        monsterData = CSVSerializer.Deserialize<MonsterData>(enemyTextAsset.text);

        //Wave1‚ÌExcel‚ğæ“¾
        waveDateTextAsset = Resources.Load("Wave1Date", typeof(TextAsset)) as TextAsset;
        waveDate = CSVSerializer.Deserialize<WaveDate>(waveDateTextAsset.text);

        //EnemySpawnMaxDate‚ÌExcel‚ğæ“¾
        enemySpawnMaxDateTextAsset = Resources.Load("EnemySpawnMaxDate", typeof(TextAsset)) as TextAsset;
        enemySpawnMaxDate = CSVSerializer.Deserialize<EnemySpawnMaxDate>(enemySpawnMaxDateTextAsset.text);
    }

    public void Wave2()
    {
        //Wave2‚ÌCSV‚ğæ“¾
        waveDateTextAsset = Resources.Load("Wave2Date", typeof(TextAsset)) as TextAsset;
        waveDate = CSVSerializer.Deserialize<WaveDate>(waveDateTextAsset.text);
    }

    public void Wave3()
    {
        //Wave3‚ÌCSV‚ğæ“¾
        waveDateTextAsset = Resources.Load("Wave3Date", typeof(TextAsset)) as TextAsset;
        waveDate = CSVSerializer.Deserialize<WaveDate>(waveDateTextAsset.text);
    }
}
