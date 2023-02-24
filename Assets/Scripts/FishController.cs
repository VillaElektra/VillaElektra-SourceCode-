using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class FishController : MonoBehaviour
{
    public float speed = 3f; //Swimming speed
    public float rotSpeed = 1.5f; //Rotation speed
    public float distance = 4f; //Distance forward ray
    //private float moveHorizontal;
    public float raydistance1 = 2f; //Distance ray1
    public float raydistance2 = 1f; //Distance ray2
    private bool rotatingr = false;
    private bool rotatingl = false;

    void FixedUpdate()
    {
        CheckObstacles();
        MoveForwards();
    }
    
    void CheckObstacles()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        var right10 = Quaternion.Euler(0,0,-30) * transform.right;
        var left10 = Quaternion.Euler(0,0,30) * transform.right;
        var right110 = Quaternion.Euler(0,0,-110) * transform.right;
        var left110 = Quaternion.Euler(0,0,110) * transform.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, distance, layerMask);
        RaycastHit2D hit1 = Physics2D.Raycast(transform.position, right10, raydistance1, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, left10, raydistance1, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, right110, raydistance2, layerMask);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, left110, raydistance2, layerMask);

        Debug.DrawRay(transform.position, transform.right * distance, Color.red, 0.01f);
        Debug.DrawRay(transform.position, right10 * raydistance1, Color.blue, 0.01f);
        Debug.DrawRay(transform.position, left10 * raydistance1, Color.green, 0.01f);
        Debug.DrawRay(transform.position, right110 * raydistance2, Color.blue, 0.01f);
        Debug.DrawRay(transform.position, left110 * raydistance2, Color.green, 0.01f);

        if (rotatingr || rotatingl) //Already rotating
        {
            if (rotatingr) //Rotating to the right
            {
                if ((hit2.collider != null) || (hit4.collider != null)) //Still seeing something to the left
                {
                    rotatingr = true;
                }
                else    //See nothing to the left
                {
                    if (hit.collider ==null)
                    {
                        rotatingr = false;
                    }
                }
            }
            else if (rotatingl) //Rotating to the left
            {
                if ((hit1.collider != null) | (hit3.collider != null)) //Still seeing something to the right
                {
                    rotatingl = true;
                }
                else    //See nothing to the right
                {
                    if (hit.collider ==null)
                    {
                        rotatingl = false;
                    }
                }    
            }
        }
        else    //Not rotating
        {
            if (hit1.collider != null || hit2.collider != null) //Seeing something
            {
                if (hit1.collider == null)
                {
                    rotatingr = true;
                }
                else if (hit2.collider == null)
                {
                    rotatingl = true;
                }
                else
                {
                    if (hit1.distance <= hit2.distance) //what you see on the right is closer
                    {
                        rotatingl = true;
                    }
                    else if (hit1.distance > hit2.distance) //what you see on the left is closer
                    {
                        rotatingr = true;
                    }
                }
            }
            else //Not seeing anything
            {
                rotatingl = false;
                rotatingr = false;
            }
        }
        if (rotatingl)
        {
            RotateLeft();
        }
        if (rotatingr)
        {
            RotateRight();
        }
    }

    void MoveForwards()
    {
        this.transform.Translate(speed * Time.deltaTime,0,0); //Move with constant speed
    }
    
    void RotateRight()
    {
        transform.Rotate( new Vector3(0, 0, -1 * rotSpeed), Space.Self ); //Rotate right
    }
    void RotateLeft()
    {
        transform.Rotate( new Vector3(0, 0, 1 * rotSpeed), Space.Self ); //Rotate left
    }
}    

