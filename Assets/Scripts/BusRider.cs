using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusRider : MonoBehaviour
{
	public float speed;
	Rigidbody2D body;

    void Start()
    {
      body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
		  body.velocity = new Vector2 (speed,0); //Move with speed in horizontal direction
    }
}
