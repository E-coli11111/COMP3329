using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] props;
    public int x_bound = 10;
    public int y_bound = 10;
    public int freq = 5;
    
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

        Debug.Log("Activate spawn");
        
        if (Random.value > p){
            return;
        }

        Debug.Log(props.Length);
        Vector2 spawnPoint = new Vector2(Random.Range(-x_bound, x_bound), Random.Range(-y_bound, y_bound));


        GameObject prop = props[Random.Range(0, props.Length)];
        Instantiate(prop, spawnPoint, Quaternion.identity);

    }
}
