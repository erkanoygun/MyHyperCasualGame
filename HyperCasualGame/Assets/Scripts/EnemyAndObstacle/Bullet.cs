using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100, ForceMode.Force);
        Destroy(gameObject,5);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

    }
}
