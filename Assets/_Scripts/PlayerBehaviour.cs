using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject deathpanel;
    public GameObject deathEffect;
    public int health = 1;

  
    private bool buttonDown = false;
    private Vector2 inputVector = Vector2.zero;

    public float movementForce = 50f;
    public float boostForce = 0.5f;
    public float jumpLimit = 0.5f;
    public float startJump = 0.1f;

    private Rigidbody2D playerRigidbody;

    
    private bool autoStart = true;
    private bool isActivated = true;

    // Use this for initialization - 
    // Start is called automatically when the object starts for the first time
    void Start()
    {
        // grab the physics object so we can move it
        playerRigidbody = GetComponent<Rigidbody2D>();
        if (!isActivated)
        {
            isActivated = autoStart; // enable the player
        }

    }


    void FixedUpdate()
    {
        if (isActivated)
        {
            buttonDown = Input.GetButton("Jump");

            inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (buttonDown && startJump <= jumpLimit)
            {
                playerRigidbody.AddForce(inputVector * boostForce);
                startJump += Time.deltaTime;
            }
            else
            {
                playerRigidbody.AddForce(inputVector * movementForce);
                startJump -= Time.deltaTime;
                if(startJump < 0)
                {
                    startJump = 0f;
                }
            }
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            deathpanel.SetActive(true);
        }
    }

    public bool isActive()
    {
        return isActivated;
    }

}
