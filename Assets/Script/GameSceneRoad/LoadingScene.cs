using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Tooltip("����Scene�Ɉڍs����ۂɑ���b��")]
    private float Change_Scene_Time_Count;


    [Tooltip("����Scene�Ɉڍs����b��")]
    private const float Change_Time = 4.0f;


    private void Update()
    {
        Change_Scene_Time_Count += Time.deltaTime;
        if (Change_Scene_Time_Count > Change_Time)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}