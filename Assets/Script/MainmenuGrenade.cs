using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuGrenade : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-50, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
