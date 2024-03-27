using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float speed = 10;
    public Rigidbody2D rb;
    public Vector2 v;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-10, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj) {
        Debug.Log("Collided with prop");
        if(obj.name.Contains("prop")) {
            Debug.Log("Clearing prop");
            Destroy(obj.gameObject);
            // Destroy(gameObject);
        }
    }
}
