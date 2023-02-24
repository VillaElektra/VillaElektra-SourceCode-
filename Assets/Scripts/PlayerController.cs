using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizontal; //Input horizontal
    float vertical; //Input vertical
    public float moveLimiter = 0.7f; //Limiter for diagonal speed
    public float runSpeed = 20.0f; //Runspeed
    public float angleOffset = -90f; //Offset angle
    Rigidbody2D body;
    public Animator animator;

    private float lastKnownPositionX;
    private float lastKnownPositionY;
    private float lastKnownRotation;

    public AudioSource Footsteps;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey("lastKnownPositionX") && PlayerPrefs.HasKey("lastKnownPositionY")) //If saved position, apply this position
        {
            GetComponent<RectTransform>().localPosition = new Vector3 (PlayerPrefs.GetFloat("lastKnownPositionX"),PlayerPrefs.GetFloat("lastKnownPositionY"),0);
        }
        if (PlayerPrefs.HasKey("lastKnownRotation")) //If saved rotation, apply this rotation
        {
             GetComponent<RectTransform>().transform.rotation = Quaternion.Euler(0, 0, PlayerPrefs.GetFloat("lastKnownRotation"));  
        }
    }

    void Update()
    {
        lastKnownPositionX = GetComponent<RectTransform>().localPosition.x; //Get pos x
        lastKnownPositionY = GetComponent<RectTransform>().localPosition.y; //Get pos y
        lastKnownRotation = GetComponent<RectTransform>().eulerAngles.z; //Get rot
        PlayerPrefs.SetFloat("lastKnownPositionX", lastKnownPositionX); //Save pos x
        PlayerPrefs.SetFloat("lastKnownPositionY", lastKnownPositionY); //Save pos y
        PlayerPrefs.SetFloat("lastKnownRotation", lastKnownRotation); //Save rot
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Get input horizontal
        vertical = Input.GetAxisRaw("Vertical"); // Get input vertical
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        } 
        Vector2 movementVector = new Vector2(horizontal * runSpeed, vertical * runSpeed); //Create movement Vector
        Move(movementVector); //Call move function
        Rotate(movementVector); //Call rotate function

        if (body.velocity.magnitude > 0.01) //If player has speed, play walking/footsteps sounds
        {
            if (!Footsteps.isPlaying)
            {
                Footsteps.Play();
            }
        }
        else
        {
            Footsteps.Stop();
        }
    }

    void Move(Vector2 movementVector) //Moves player
    {
        body.velocity = movementVector;
        animator.SetFloat("Speed", body.velocity.magnitude);
    }

    void Rotate(Vector2 movementVector) //Rotates player
    {
        if (movementVector != Vector2.zero) 
        {
            float angle = Mathf.Atan2(movementVector.y, movementVector.x) * Mathf.Rad2Deg + angleOffset;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }    
    }
}

 