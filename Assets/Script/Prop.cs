using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public float duration = 1f;

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
            // Debug.Log("Collided with grenade");

            GameObject g = obj.gameObject;
            Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
            
            Vector2 original = rb.velocity;
            Vector2 v = original;
            float angle = Mathf.Atan2(original.y, original.x);
            v.x = v.x + 10 * Mathf.Cos(angle);
            v.y = v.y + 10 * Mathf.Sin(angle);

            rb.velocity = v;

            // Set grenade acceleration
            Vector2 a = (original - v) / duration;
            Debug.Log(a);
            g.GetComponent<Grenade>().UpdateAndResetAcceleration(a, duration);
            
        }
        
    }

    
}
