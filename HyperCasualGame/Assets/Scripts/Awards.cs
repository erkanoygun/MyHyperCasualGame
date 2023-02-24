using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AwardsNameSpace
{
    public class Awards : MonoBehaviour
    {
        PlayerManager playerManager;
        GameObject player;
        private bool isMagnetArea = false;

        private void Start()
        {
            player = GameObject.Find("Player");
            playerManager = player.GetComponent<PlayerManager>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //Destroy(gameObject);
                DestroyObject(gameObject);
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Magnet"))
            {
                isMagnetArea = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Magnet"))
            {
                isMagnetArea = false;
            }
        }

        private void Update()
        {
            if (!gameObject.CompareTag("Diamond"))
            {
                if (playerManager.getIsMagnet)
                {
                    if (isMagnetArea)
                    {
                        Vector3 toPosition = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
                        transform.position = Vector3.MoveTowards(transform.position, toPosition, 8.0f * Time.deltaTime);
                        float _distance = Vector3.Distance(transform.position, player.transform.position);
                        if (_distance <= 0.65f)
                        {
                            DestroyObject(gameObject);
                        }
                    }

                }
            }
            
        }

        private void DestroyObject(GameObject destroyObject)
        {
            Destroy(destroyObject);
        }

    }
}

