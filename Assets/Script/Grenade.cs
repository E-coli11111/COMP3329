using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float speed = 5;
    public Rigidbody2D rb;
    public Vector2 v;
    public Vector2 acceleration = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);

    }

    // Update is called once per frame
    void Update()
    {   
        rb.velocity += acceleration * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D obj) {
        // Debug.Log("Collided with prop1");
        if(obj.name.Contains("prop")) {
            // Debug.Log("Clearing prop");
            Destroy(obj.gameObject);
            // Destroy(gameObject);
        }
    }

    // void OnCollisionEnter2D(Collision2D obj) {
    //     Debug.Log("Collided with "+obj.gameObject.name);
    //     if(obj.gameObject.name.Contains("player")) {

    //         foreach(ContactPoint2D contact in obj.contacts) {
    //             obj.gameObject.GetComponent<Rigidbody2D>().AddForce(contact.normalImpulse, ForceMode2D.Impulse);
    //         }

            
    //     }
    // }

    // void OnCollisionStay2D(Collision2D obj) {
    //     // Debug.Log("Collided with "+obj.gameObject.name);
    //     if(obj.gameObject.name.Contains("player")) {

    //         foreach(ContactPoint2D contact in obj.contacts) {
    //             obj.gameObject.GetComponent<Rigidbody2D>().AddForce(contact.normalImpulse, ForceMode2D.Impulse);
    //         }
            
    //     }
    // }

    void OnCollisionExit2D(Collision2D obj) {
        // Debug.Log("Collided with "+obj.gameObject.name);
        if(obj.gameObject.name.Contains("Boundary1")) {

            Vector2 v = rb.velocity;
            if(v.x < 0 && v.x > -7){
                v.x = v.x - 2;
            }else if(v.x > 0 && v.x < 7){
                v.x = v.x + 2;
            }
            rb.velocity = v;
            
        }
    }

    public void UpdateAcceleration(Vector2 a) {
        // Debug.Log("Updating acceleration: Grenade");
        acceleration += a;
        // Debug.Log(acceleration);
        // Debug.Log(rb.velocity);
        // Debug.Log("----");
    }

    // Update acceleration for a duration and then reset it
    public void UpdateAndResetAcceleration(Vector2 a, float duration) {
        StartCoroutine(UpdateAndResetAccelerationRoutine(a, duration));
    }

    IEnumerator UpdateAndResetAccelerationRoutine(Vector2 a, float duration) {
        // Debug.Log("Updating acceleration: Coroutine");
        UpdateAcceleration(a);

        yield return new WaitForSeconds(duration);
        // Debug.Log("Updating acceleration: Resetting");
        UpdateAcceleration(-a);
    }

    
}
