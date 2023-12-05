using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemyCollision : MonoBehaviour
{
    [Tooltip("")]
    private Collision Player_Purple_Attack;

    private void OnTriggerStay(Collider other)
    {
        Player_Purple_Attack = other.gameObject.GetComponent<Collision>();

        if (Player_Purple_Attack.Purple_Attack_)
        {
            Destroy(gameObject);
        }
    }
}
