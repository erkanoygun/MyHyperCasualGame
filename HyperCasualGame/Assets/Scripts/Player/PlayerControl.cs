using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody _rb;
    UnityEngine.Vector2 firstPressPos;
    UnityEngine.Vector2 secondPressPos;
    UnityEngine.Vector2 currentSwipe;
    private float posX, posY, posZ;
    [SerializeField] private float _speed = 10.0f;
    void Start()
    {
        /*posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;*/
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        Swipe();
    }

    void FixedUpdate()
    {
        //UnityEngine.Vector3 vector = new UnityEngine.Vector3(0,0,1);
        //_rb.AddForce(vector * _speed, ForceMode.Force);

        //transform.position = new UnityEngine.Vector3(posX, transform.position.y, posZ);
        transform.position += transform.forward * 2 * Time.fixedDeltaTime;
    }

    public void Swipe()
    {
        // first touch screen
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        // ended touch screen
        if (Input.GetMouseButtonUp(0))
        {
            secondPressPos = new UnityEngine.Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new UnityEngine.Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            currentSwipe.Normalize();

            // Up swipe
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                transform.position += transform.up * 3;
            }

            //Left swipe
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                transform.position += (transform.right * -1) * 2;
                
            }

            //Right swipe
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                transform.position += transform.right * 2;
            }
            /*
            //Down Swipe
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
            }*/
        }
    }
}
