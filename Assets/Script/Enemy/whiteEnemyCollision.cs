using UnityEngine;
using UnityEngine.SceneManagement;

public class whiteEnemyCollision : MonoBehaviour
{

    [Tooltip("緑のライトが当たっているかを判定")]
    private bool Green_Attack_Flag;

    [Tooltip("青色のライトが当たっているかを判定")]
    private bool Blue_Attack_Flag;

    [Tooltip("赤色の敵に当たっているかを判定")]
    private bool Red_Attack_Flag;

    [Tooltip("")]
    private bool ParticleSystem;

    [Tooltip("紫色のライトが当たっているかを判定")]
    private RedLightCollision Player_Purple_Flag;

    [Tooltip("緑色のライトが当たっているかを判定")]
    private GreenLightCollision Player_Green_Flag;

    [Tooltip("水色のライトが当たっているかを判定")]
    private BlueLightCollision Player_Light_Blue_Flag;

    [Header("WhiteのHpを設定"), SerializeField]
    private int White_Enemy_Hp;

    [Tooltip("")]
    private float Enemy_Hit_Time = 1.1f;

    [Tooltip("")]
    private const float Hit_Cool_Time = 1;

    [SerializeField]
    private ParticleSystem particle;

    [Tooltip("")]
    private ParticleSystem newParticle;


    private void Start()
    {
        Green_Attack_Flag = false;
        Blue_Attack_Flag = false;
        Red_Attack_Flag = false;
        ParticleSystem = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Green_Attack_Flag &&
            Blue_Attack_Flag &&
            Red_Attack_Flag &&
            Player_Light_Blue_Flag.Light_Blue_Attack_Flag &&
            Player_Green_Flag.Yellow_Attack_Flag &&
            Player_Purple_Flag.Purple_Attack_Flag)

        {
            Enemy_Hit_Time += Time.deltaTime;

            if (Enemy_Hit_Time > Hit_Cool_Time)
            {
                White_Enemy_Hp -= 3;
                Debug.Log(White_Enemy_Hp);
                Enemy_Hit_Time = 0;
                if (White_Enemy_Hp <= 0)
                {
                    Destroy(this.gameObject);
                    Destroy(newParticle);
                    SceneManager.LoadScene("GameClear");
                }
            }

            if (!ParticleSystem)
            {
                newParticle = Instantiate(particle);
                newParticle.Play();
                ParticleSystem = true;
            }
            else
            {
                newParticle.transform.position = this.transform.position;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            Green_Attack_Flag = true;
            Player_Light_Blue_Flag = other.gameObject.GetComponent<BlueLightCollision>();
        }

        if (other.gameObject.CompareTag("greenlight"))
        {
            Blue_Attack_Flag = true;
            Player_Green_Flag = other.gameObject.GetComponent<GreenLightCollision>();

        }

        if (other.gameObject.CompareTag("redlight"))
        {
            Red_Attack_Flag = true;
            Player_Purple_Flag = other.gameObject.GetComponent<RedLightCollision>();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bluelight"))
        {
            ParticleSystem = false;
            Green_Attack_Flag = false;
            Destroy(newParticle);

        }

        if (other.gameObject.CompareTag("greenlight"))
        {
            ParticleSystem = false;
            Blue_Attack_Flag = false;
            Destroy(newParticle);
        }

        if (other.gameObject.CompareTag("redlight"))
        {
            ParticleSystem = false;
            Red_Attack_Flag = false;
            Destroy(newParticle);
        }
    }

}
