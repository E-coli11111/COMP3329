using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj) {
        
        if(obj.name.Contains("Grenade")) {
            Debug.Log("Collided with grenade");
            g = obj.gameObject;
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            
            Vector2 v = rb.velocity;
            v.x = 2 * v.x;
            v.y = 2 * v.y;

            rb.velocity = v;
        }
    }
}
