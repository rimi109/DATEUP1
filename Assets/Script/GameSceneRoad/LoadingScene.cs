using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [Tooltip("ŽŸ‚ÌScene‚ÉˆÚs‚·‚éÛ‚É‘ª‚é•b”")]
    private float Change_Scene_Time_Count;


    [Tooltip("ŽŸ‚ÌScene‚ÉˆÚs‚·‚é•b”")]
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