using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class BleuTitleSeneTransition : MonoBehaviour
{

    [Header("Playerが何人目のPlayerかを指定"), SerializeField]
    private int Player_Numbers_;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all[Player_Numbers_].aButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
