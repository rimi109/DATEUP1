using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowScript : MonoBehaviour
{
    [Tooltip("�����U�������ǂ����𔻒�")]
    public bool Pillow_Attack_ { get; private set; } = true;

    public void Pillow_No_Attack_Function()
    {
        Pillow_Attack_ = false;
    }

    public void Pillow_Attack_Function()
    {
        Pillow_Attack_ = true;
    }

}
