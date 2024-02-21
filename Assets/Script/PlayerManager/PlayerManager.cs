using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player�̈�l��l��Transform���擾"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    [Header("PlayerGreen��Scrip���擾"), SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerRed��Scrip���擾"), SerializeField]
    private PlayerRed Player_Red;

    [Header("PlayerBlue��Scrip���擾"), SerializeField]
    private PlayerBlue Player_Blue;


    public void List_Add(Transform transform)
    {
        Players.Add(transform);
    }

    public void List_Remove(Transform transform)
    {
        Players.Remove(transform);
    }
}
