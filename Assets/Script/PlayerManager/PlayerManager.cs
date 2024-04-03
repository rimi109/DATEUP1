using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player‚Ìˆêlˆêl‚ÌTransform‚ğæ“¾"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    [Header("PlayerGreen‚ÌScrip‚ğæ“¾"), SerializeField]
    private PlayerScript Player_Green;

    [Header("PlayerRed‚ÌScrip‚ğæ“¾"), SerializeField]
    private PlayerRed Player_Red;

    [Header("PlayerBlue‚ÌScrip‚ğæ“¾"), SerializeField]
    private PlayerBlue Player_Blue;


    public void ListAdd(Transform transform)
    {
        Players.Add(transform);
    }

    public void List_Remove(Transform transform)
    {
        Players.Remove(transform);
    }
}
