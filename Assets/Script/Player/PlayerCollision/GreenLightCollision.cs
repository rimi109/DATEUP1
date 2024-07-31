using UnityEngine;

public class GreenLightCollision : MonoBehaviour
{


    [Header(""), SerializeField]
    private GameObject thisGameObject;

    [Header("player‚Ì‹–ì”ÍˆÍ‚ğİ’è"), SerializeField]
    private float        Player_Angle;

    [Tooltip("‰©F‚ÌUŒ‚‚ª—LŒø‚©–³Œø"), HideInInspector]
    public bool          Yellow_Attack_Flag { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("redlight") ||
            other.gameObject.CompareTag("bluelight")||
            other.gameObject.CompareTag("greenlight"))
        {
            Vector3 posDelta = other.transform.position - thisGameObject.transform.position;
            float target_angle = Vector3.Angle(gameObject.transform.forward, posDelta);

            if (target_angle < Player_Angle)
            {
                Yellow_Attack_Flag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("redlight"))
        {
            Yellow_Attack_Flag = false;
        }
    }
}
