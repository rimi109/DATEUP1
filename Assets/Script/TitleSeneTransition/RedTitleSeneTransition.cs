using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class RedTitleSeneTransition : MonoBehaviour
{
    [Header("Player�����l�ڂ�Player�����w��"), SerializeField]
    private int Player_Numbers_;

    // Update is called once per frame
    void Update()
    {

        if (Gamepad.current == null)
            return;

        if (Gamepad.all[Player_Numbers_].aButton.wasPressedThisFrame)
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
