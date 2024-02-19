using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player‚Ìˆêlˆêl‚ÌTransform‚ğæ“¾"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    [Header("PlayerGreen‚ÌScrip‚ğæ“¾"),SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerRed‚ÌScrip‚ğæ“¾"), SerializeField]
    private PlayerRed Player_Red;

    [Header("PlayerBlue‚ÌScrip‚ğæ“¾"), SerializeField]
    private PlayerBlue Player_Blue;

    // Update is called once per frame
    void Update()
    {
        if (Player_Green.Player_Green_revival_Flag)
        {
            Player_Green_List_Add_Function();
        }

        if (Player_Red.Player_Red_revival_Flag)
        {
            Player_Red_List_Add_Function();
        }

        if (Player_Blue.Player_Blue_revival_Flag)
        {
            Player_Blue_List_Add_Function();
        }
    }

    private void Player_Red_List_Add_Function()
    {
        Transform PlayerGreen = GameObject.FindGameObjectWithTag("PlayerRed").transform;
        Players.Add(PlayerGreen);
    }

    private void Player_Blue_List_Add_Function()
    {
        Transform PlayerGreen = GameObject.FindGameObjectWithTag("PlayerBlue").transform;
        Players.Add(PlayerGreen);
    }

    private void Player_Green_List_Add_Function()
    {
        Transform PlayerGreen = GameObject.FindGameObjectWithTag("PlayerGreen").transform;
        Players.Add(PlayerGreen);
    }

    public void Player_List_Remove_Function()
    {
        //Players.Remove();
    }
}
