using UnityEngine;

public class RedLightCollision : MonoBehaviour
{
    [Header("Red‚ÌPlayerGameObject‚ğæ“¾"), SerializeField]
    private GameObject Red_Player_Object;

    [Header("player‚Ì‹–ì”ÍˆÍ‚ğİ’è"), SerializeField]
    private float Player_Angle;

    [Tooltip("‡F‚ÌUŒ‚‚ª—LŒø‚©–³Œø"), HideInInspector]
    public bool Purple_Attack_Flag { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("bluelight"))
        {
            Vector3 posDelta = other.transform.position - Red_Player_Object.transform.position;
            float target_angle = Vector3.Angle(Red_Player_Object.transform.forward, posDelta.normalized);

            if (target_angle < Player_Angle)
            {
               Purple_Attack_Flag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            Purple_Attack_Flag = false;
        }
    }
}
