using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [Tooltip(""), SerializeField]
    private AudioSource Game_Bgm;

    [Tooltip(""), SerializeField]
    private AudioClip Game_Bgm_Clip;


    // Start is called before the first frame update
    void Start()
    {
        Game_Bgm.PlayOneShot(Game_Bgm_Clip);
    }
}
