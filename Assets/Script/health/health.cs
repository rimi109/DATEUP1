using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    [SerializeField]
    private GameObject[] health_;

    [SerializeField]
    private Transform Green_Player;

    [SerializeField]
    private Camera MainCamera;

    void Update()
    {
        for (int i = 0; i < health_.Length; ++i)
        {
            health_[i].transform.rotation = Camera.main.transform.rotation;
            health_[i].transform.position = new Vector3(Green_Player.transform.position.x - 10, Green_Player.transform.position.y + 15, Green_Player.transform.position.z - 4);
            health_[i].transform.position = new Vector3(health_[i].transform.position.x + (i * 10), health_[i].transform.position.y,  health_[i].transform.position.z);
        }
    }
}
