using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Playerの一人一人のTransformを取得"), SerializeField]
    public List<Transform> Players = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Players.RemoveAll(Players>)
    }
}
