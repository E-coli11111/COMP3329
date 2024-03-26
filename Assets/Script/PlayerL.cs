using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeft : MonoBehaviour
{
    float speed = 10;
    public Rigidbody2D rb;
    public Vector2 v;
    public Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        v = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {

            v.y = -speed;
            rb.velocity = v;

        }

        else if (Input.GetKey(KeyCode.W))
        {

            v.y = speed;
            rb.velocity = v;

        }

        else
        {
            v.y = 0;
            rb.velocity = v;

        }
        v.x = 0;
        rb.velocity = v;
    }
}
