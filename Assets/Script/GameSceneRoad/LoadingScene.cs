using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Tooltip("次のSceneに移行する際に測る秒数")]
    private float Change_Scene_Time_Count;


    [Tooltip("次のSceneに移行する秒数")]
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