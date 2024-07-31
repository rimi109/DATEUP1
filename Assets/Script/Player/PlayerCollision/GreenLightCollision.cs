using UnityEngine;

public class GreenLightCollision : MonoBehaviour
{


    [Header(""), SerializeField]
    private GameObject playerGameObject;

    [Header("playerの視野範囲を設定"), SerializeField]
    private float      playerAngle;

    [Tooltip("黄色の攻撃が有効か無効"), HideInInspector]
    public bool        yellowAttackFlag { get; private set; } = false;

    [Tooltip("黄色の攻撃が有効か無効"), HideInInspector]
    public bool        purpleAttackFlag { get; private set; } = false;

    [Tooltip("黄色の攻撃が有効か無効"), HideInInspector]
    public bool        lightBlueAttackFlag { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("redlight") || other.CompareTag("bluelight") || other.CompareTag("greenlight"))
        {
            Vector3 posDelta = other.transform.position - playerGameObject.transform.position;
            float target_angle = Vector3.Angle(playerGameObject.transform.forward, posDelta);

            if (target_angle < playerAngle)
            {
                switch (other.tag)
                {
                    case "redlight":
                        yellowAttackFlag = true;
                        break;
                    case "bluelight":
                        purpleAttackFlag = true;
                        break;
                    case "greenlight":
                        lightBlueAttackFlag = true;
                        break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "redlight":
                yellowAttackFlag = false;
                break;
            case "bluelight":
                purpleAttackFlag = false;
                break;
            case "greenlight":
                lightBlueAttackFlag = false;
                break;
        }
    }
}
}
