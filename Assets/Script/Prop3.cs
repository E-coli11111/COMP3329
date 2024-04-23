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
            Debug.Log(1);
            playerL = GameObject.Find("player l");
            playerR = GameObject.Find("player r");
            Debug.Log(playerL.GetComponentsInChildren<Shield>());
            if(obj.GetComponent<Grenade>().last == 1){
                playerL.GetComponentInChildren<Shield>().OnExpand();
            }else{
                playerR.GetComponentInChildren<Shield>().OnExpand();
            }
        }
    }
}
