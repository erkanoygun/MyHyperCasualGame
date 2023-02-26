using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllerNameSpace;
using TMPro;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public int health = 3;
    public int coin = 0;
    public int diamond = 0;
    public bool isMagnet = false;
    public bool isFinish = false;
    public TMP_Text coin_Text, diamond_Text;
    [SerializeField] private PlayerControl playerControlScript;
    public Image img_Magnet, img_Jump;
    [SerializeField] private GameObject[] _healtUI;
    [SerializeField] private GameObject soundManager;
    SoundManager soundManagerScript;
    public bool getIsMagnet
    {
        get { return isMagnet; }
    }

    private void Start()
    {
        img_Magnet.enabled = false;
        img_Jump.enabled = false;
        soundManagerScript = soundManager.GetComponent<SoundManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            coin++;
            coin_Text.text = coin.ToString();
            soundManagerScript.PlaySound(0);
        }
        if (collision.gameObject.CompareTag("Diamond"))
        {
            diamond++;
            diamond_Text.text = diamond.ToString();
            soundManagerScript.PlaySound(1);
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HealthDamage(1);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            HealthDamage(2);
        }
        if (collision.gameObject.CompareTag("MagnetWall"))
        {
            Destroy(collision.gameObject);
            isMagnet = true;
            Invoke("backMagnet", 10.0f);
            img_Magnet.enabled = true;
        }
        if (collision.gameObject.CompareTag("JumpWall"))
        {
            playerControlScript.jumpForc = 8.5f;
            Destroy(collision.gameObject);
            Invoke("backJumpForce", 10.0f);
            img_Jump.enabled = true;
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            isFinish = true;
        }
    }

    private void backJumpForce()
    {
        playerControlScript.jumpForc = 6.0f;
        img_Jump.enabled = false;
    }
    private void backMagnet()
    {
        isMagnet = false;
        img_Magnet.enabled = false;
    }

    private void HealthDamage(int healthSize)
    {
        health -= healthSize;
        if (health >= 0)
        {
            for (int i = 3; i > health; i--)
            {
                _healtUI[i - 1].gameObject.SetActive(false);
            }
        }
        else if(health == -1)
        {
            _healtUI[0].gameObject.SetActive(false);
        }
        
    }
}


