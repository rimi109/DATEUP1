using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Playerの一人一人のTransformを取得"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    [Header("PlayerGreenのScripを取得"), SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerRedのScripを取得"), SerializeField]
    private PlayerRed Player_Red;

    [Header("PlayerBlueのScripを取得"), SerializeField]
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
