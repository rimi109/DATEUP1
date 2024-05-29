using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player‚Ìˆêlˆêl‚ÌTransform‚ğæ“¾"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    public void ListAdd(Transform transform)
    {
        Players.Add(transform);
    }

    public void List_Remove(Transform transform)
    {
        Players.Remove(transform);
    }
}
