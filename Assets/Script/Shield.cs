using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        shield = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExpand(){
        // Expand the shield
        shield.transform.localScale = 2 * shield.transform.localScale;
        shield.GetComponent<CircleCollider2D>().radius = 2 * shield.GetComponent<CircleCollider2D>().radius;

        // Shrink the shield after 5 seconds
        Invoke("OnShrink", 5);
    }

    void OnShrink(){
        // Shrink the shield
        shield.transform.localScale = 0.5f * shield.transform.localScale;
        shield.GetComponent<CircleCollider2D>().radius = 0.5f * shield.GetComponent<CircleCollider2D>().radius;
    }
}
