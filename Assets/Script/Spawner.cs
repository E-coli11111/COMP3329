using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] props;
    public static int x_bound = 10;
    public static int y_bound = 0;
    public static int freq = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        props = Resources.LoadAll<GameObject>("prop");

        InvokeRepeating("spawnProps", 0, freq);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnProps(){

        double p = 0.1 * Time.time;

        // Debug.Log("Activate spawn");
        
        if (Random.value > p){
            return;
        }

        GameObject[] existing;

        try{
            existing = GameObject.FindGameObjectsWithTag("Prop");
        }catch{
            existing = new GameObject[0];
        }

        // Debug.Log(existing.Length);
        if (existing.Length > 2){
            // Debug.Log("Too many props");
            return;
        }

        float x = Random.Range(-x_bound, x_bound);
        float y = Random.Range(-y_bound, y_bound);
        Vector2 spawnPoint = new Vector2(x, y);

        GameObject prop = props[Random.Range(0, props.Length)];
        Instantiate(prop, spawnPoint, Quaternion.identity);

    }
}
