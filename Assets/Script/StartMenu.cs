using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject g;

    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GrenadeMove()
    {
        Debug.Log("GrenadeMove");
        Debug.Log(g.name);
        Debug.Log(g.GetComponent<Rigidbody2D>().velocity);
        g.GetComponent<Rigidbody2D>().velocity = g.GetComponent<Rigidbody2D>().velocity + new Vector2(Random.Range(-100f, 100f), Random.Range(-100f, 100f));
        Debug.Log(g.GetComponent<Rigidbody2D>().velocity);
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButton("Fire1"))
        // {
            
        // }
    }
}
