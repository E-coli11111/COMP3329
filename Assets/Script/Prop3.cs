using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerL;
    public GameObject playerR;
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
            playerL = GameObject.Find("player_l");
            playerR = GameObject.Find("player_r");
            
            // Wall w1 = wall1.GetComponent<Wall>();
            // Wall w2 = wall2.GetComponent<Wall>();

            // w1.StartShrink();
            // w2.StartShrink();
        }
    }
}
