using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVProcessing : MonoBehaviour
{
    [Header("“G‚Ìî•ñ‚ğæ“¾")]
    public MonsterData[] Monster_Data;

    [Tooltip("Enemy‚ÌTextAsset‚ğİ’è")]
    private TextAsset Enemy_Text_Asset;

    [Header("Wave‚Ìî•ñ‚ğæ“¾")]
    public WaveDate[] Wave_Date;

    [Tooltip("Wave‚ÌTextAsset‚ğİ’è")]
    private TextAsset Wave_Date_Text_Asset;

    [Header("Enemy‚ªˆê‰ñWave‚ÅoŒ»‚·‚éÅ‘åŒÂ”‚Ìî•ñ‚ğæ“¾")]
    public EnemySpawnMaxDate[] Enemy_Spawn_Max_Date;

    [Tooltip("EnemySpawnMaxDate‚ÌTextAsset‚ğİ’è")]
    private TextAsset Enemy_Spawn_Max_Date_Text_Asset;


    void Start()
    {
        //“G‚ÌExcel‚ğæ“¾
        Enemy_Text_Asset = Resources.Load("MonsterDate", typeof(TextAsset)) as TextAsset;
        Monster_Data = CSVSerializer.Deserialize<MonsterData>(Enemy_Text_Asset.text);

        //Wave1‚ÌExcel‚ğæ“¾
        Wave_Date_Text_Asset = Resources.Load("Wave1Date", typeof(TextAsset)) as TextAsset;
        Wave_Date = CSVSerializer.Deserialize<WaveDate>(Wave_Date_Text_Asset.text);

        //EnemySpawnMaxDate‚ÌExcel‚ğæ“¾
        Enemy_Spawn_Max_Date_Text_Asset = Resources.Load("EnemySpawnMaxDate", typeof(TextAsset)) as TextAsset;
        Enemy_Spawn_Max_Date = CSVSerializer.Deserialize<EnemySpawnMaxDate>(Enemy_Spawn_Max_Date_Text_Asset.text);
    }

    public void Wave_2()
    {
        //Wave2‚ÌCSV‚ğæ“¾
        Wave_Date_Text_Asset = Resources.Load("Wave2Date", typeof(TextAsset)) as TextAsset;
        Wave_Date = CSVSerializer.Deserialize<WaveDate>(Wave_Date_Text_Asset.text);
    }

    public void Wave_3()
    {
        //Wave3‚ÌCSV‚ğæ“¾
        Wave_Date_Text_Asset = Resources.Load("Wave3Date", typeof(TextAsset)) as TextAsset;
        Wave_Date = CSVSerializer.Deserialize<WaveDate>(Wave_Date_Text_Asset.text);
    }
}
