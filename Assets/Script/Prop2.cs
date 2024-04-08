using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop2 : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D obj){
       
        if(obj.name.Contains("Grenade")) {
            wall1 = GameObject.Find("Wall1");
            wall2 = GameObject.Find("Wall2");
            
            Wall w1 = wall1.GetComponent<Wall>();
            Wall w2 = wall2.GetComponent<Wall>();

            w1.StartShrink();
            w2.StartShrink();
        }
    }
}
