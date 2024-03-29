using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop1 : MonoBehaviour
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

            // float x = Random.Range(-1f, 1f);
            // Debug.Log(x);
            
            // if (v.x < 3){
            //     v.x = 3;
            // }

            // v.y = original.y +  original.x * x;

            // rb.velocity = v;
            Vector2 a = new Vector2(Random.Range(0, original.x), Random.Range(3f, 5f) * (Random.Range(0, 1) - 0.5f) * 2);
            Debug.Log(a);
            g.GetComponent<Grenade>().UpdateAndResetAcceleration(a, duration);
            
        }
        
    }
}
