using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GreenPlayeTransition : MonoBehaviour
{
    [Header("Player‚ª‰½l–Ú‚ÌPlayer‚©‚ğw’è"), SerializeField]
    private int Player_Numbers_;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all[Player_Numbers_].aButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("RoadScene");
        }
    }
}
