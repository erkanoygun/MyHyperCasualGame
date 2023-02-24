using System;
using System.Diagnostics;
using UnityEngine;

namespace PlayerControllerNameSpace
{
    public class PlayerControl : MonoBehaviour
    {
        private Rigidbody _rb;
        Vector2 firstPressPos;
        Vector2 secondPressPos;
        Vector2 currentSwipe;
        [SerializeField] private float _speed = 5.0f;
        public float jumpForc = 6.0f;
        Animator _animator;
        [SerializeField] private GameObject _playerBody;

        void Start()
        {
            _animator = _playerBody.GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }



        void Update()
        {
            Swipe();
        }

        void FixedUpdate()
        {
            transform.position += transform.forward * _speed * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _animator.SetBool("isJump", false);
            }
        }

        public void Swipe()
        {
            // first touch screen
            if (Input.GetMouseButtonDown(0))
            {
                firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
            // ended touch screen
            if (Input.GetMouseButtonUp(0))
            {
                secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

                //create vector from the two points
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                currentSwipe.Normalize();

                // Up swipe
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {

                    _rb.velocity = new Vector3(0, jumpForc, 0);
                    _animator.SetBool("isJump", true);
                }

                //Left swipe
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    _rb.velocity = new Vector3(-1f * SwipeXForce((secondPressPos.x - firstPressPos.x)), 0, 0);

                }

                //Right swipe
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    _rb.velocity = new Vector3(SwipeXForce((secondPressPos.x - firstPressPos.x)), 0, 0);
                }
            }
        }

        private float SwipeXForce(float value)
        {
            float force;
            value = Math.Abs(value);

            if (value >= 0 && value <= 5)
            {
                force = 1.2f;
            }
            else if (value >= 6 && value <= 45)
            {
                force = 3.2f;
            }
            else if (value >= 21 && value <= 90)
            {
                force = 4.2f;
            }
            else if (value >= 91 && value <= 200)
            {
                force = 6.2f;
            }
            else if (value >= 201 && value <= 350)
            {
                force = 8.2f;
            }
            else
            {
                force = 12.2f;
            }
            return force;
        }
    }
}

