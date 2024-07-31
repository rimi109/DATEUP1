using UnityEngine;

public class BlueLightCollision : MonoBehaviour
{
    [Header("Blue‚ÌPlayerGameObject‚ğæ“¾"), SerializeField]
    private GameObject Blue_Player_Object;

    [Header("player‚Ì‹–ì”ÍˆÍ‚ğİ’è"),SerializeField]
    private float      Player_Angle;

    [Tooltip("…F‚ÌUŒ‚‚ª—LŒø‚©–³Œø"),HideInInspector]
    public bool       Light_Blue_Attack_Flag { get; private set; } = false;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("greenlight"))
        {
            Vector3 posDelta = other.transform.position - Blue_Player_Object.transform.position;
            float target_angle = Vector3.Angle(Blue_Player_Object.transform.forward, posDelta);
            if (target_angle < Player_Angle)
            {
               Light_Blue_Attack_Flag = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("greenlight"))
        {
            Light_Blue_Attack_Flag = false;
        }
    }
}
