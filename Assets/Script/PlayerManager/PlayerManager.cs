using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player‚Ìˆêlˆêl‚ÌTransform‚ğæ“¾"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    // Update is called once per frame
    void Update()
    {
        Players.RemoveAll(playerGreen => playerGreen.GetComponent<PlayerScript>() != null && playerGreen.GetComponent<PlayerScript>().Player_Green_dead_Flag);
        Players.RemoveAll(playerBlue => playerBlue.GetComponent<PlayerBlue>() != null && playerBlue.GetComponent<PlayerBlue>().Player_Blue_Dead_Flag);
        Players.RemoveAll(playerRed => playerRed.GetComponent<PlayerRed>() != null && playerRed.GetComponent<PlayerRed>().Player_Red_dead_Flag);







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

}
