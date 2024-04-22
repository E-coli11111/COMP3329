using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public GameObject ingameMenu;

    // Start is called before the first frame update
    public void OnPause(){
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }
    public void OnResume(){
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }
    public void OnRestart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
