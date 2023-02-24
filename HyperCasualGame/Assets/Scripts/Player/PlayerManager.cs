using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControllerNameSpace;


public class PlayerManager : MonoBehaviour
{
    private int _health = 3;
    //private int _score = 0;
    private int _coin;
    private int _diamond;
    public bool isMagnet = false;
    [SerializeField] private PlayerControl playerControlScript;
    public bool getIsMagnet
    {
        get { return isMagnet; }
    }

    private void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            _coin++;
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            _diamond++;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            _health--;
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            _health -= 2;
        }
        else if (collision.gameObject.CompareTag("MagnetWall"))
        {
            Destroy(collision.gameObject);
            isMagnet = true;
            Invoke("backMagnet", 10.0f);
        }
        else if (collision.gameObject.CompareTag("JumpWall"))
        {
            playerControlScript.jumpForc = 7.5f;
            Destroy(collision.gameObject);
            Invoke("backJumpForce", 5.0f);
        }
    }

    private void backJumpForce()
    {
        playerControlScript.jumpForc = 6.0f;
    }
    private void backMagnet()
    {
        isMagnet = false;
    }
}


