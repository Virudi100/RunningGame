using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool isGounded = true;
    [SerializeField] private GameObject beginText;

    private bool isPlaying = false;

    private Animator playerAnimator;
    private Rigidbody rb;
    [SerializeField] private float forceJump = 2f;

    private void Start()
    {
        playerAnimator = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z pressed");
            playerAnimator.SetTrigger("IsRunning");
            beginText.SetActive(false);
            isPlaying = true;
        }

        if (isPlaying == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && isGounded == true)
            {
                Debug.Log("Space Pressed");
                playerAnimator.SetBool("IsJumping", true);
                rb.AddForce(new Vector3(0,2f,0) * forceJump, ForceMode.Impulse);
            }
            else
            {
                playerAnimator.SetBool("IsJumping", false);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnimator.SetTrigger("Slide");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGounded = true;
        }
    }


    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGounded = false;
        }
    }
}
