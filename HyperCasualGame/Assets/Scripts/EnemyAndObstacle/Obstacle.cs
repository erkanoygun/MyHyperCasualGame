using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           collision.rigidbody.velocity = new Vector3(0, 0, -7);
          // collision.rigidbody.AddForce(-transform.forward * 10, ForceMode.Impulse);
        }
    }

}
