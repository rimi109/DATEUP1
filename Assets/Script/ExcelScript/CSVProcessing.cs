using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVProcessing : MonoBehaviour
{
    //　流し込む配列
    public MonsterData[] Monster_Data;

    void Start()
    {
        //　テキストファイルの読み込みを行ってくれるクラス
        TextAsset textasset = new TextAsset();
        //　先ほど用意したcsvファイルを読み込ませる。
        //　ファイルは「Resources」フォルダを作り、そこに入れておくこと。また"CSVTestData"の部分はファイル名に合わせて変更する。
        textasset = Resources.Load("Enemy", typeof(TextAsset)) as TextAsset;
        //　CSVSerializerを用いてcsvファイルを配列に流し込む。
        Monster_Data = CSVSerializer.Deserialize<MonsterData>(textasset.text);
    }

    void Update()
    {
        
    }
}
