using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    float speed = 5;
    public GameObject controller;
    public Rigidbody2D rb;
    public Vector2 v;
    public Vector2 acceleration = new Vector2(0, 0);
    public int last = 1;
    public bool isExploding = false;

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
        Debug.Log(obj.name);
        if(obj.name.Contains("prop")) {
            // Debug.Log("Clearing prop");
            Destroy(obj.gameObject);
            // Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D obj) {
        Debug.Log("Collided with "+obj.gameObject.name);
        if(obj.gameObject.name.Contains("Boundary1")){
            Debug.Log("Collided with Boundary1");
            GameController gc = controller.GetComponent<GameController>();
            gc.time = gc.time - 2;
        }else if(obj.gameObject.name.Contains("player l")){
            last = 1;
        }else if(obj.gameObject.name.Contains("player r")){
            last = 2;
        }
    }

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

    public void Explode() {
        if(isExploding) return;
        isExploding = true;
        rb.velocity = new Vector2(0, 0);

        this.gameObject.GetComponent<Animator>().SetTrigger("End");
        // this.gameObject.GetComponent<AudioSource>().PlayDelayed(0.5f);
    }

    public void PlayExplosionSound() {
        Debug.Log("Playing explosion sound");
        Debug.Log(this.gameObject.GetComponent<AudioSource>());
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    public void Test() {
        Debug.Log("Test");
    }

    
}
