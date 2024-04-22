using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas countDownMenu;
    // public Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(CountdownCoroutine());
        // pauseMenu.gameObject.SetActive(false);
        // countDownMenu.gameObject.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            OnPause();
        }
    }

    public void OnPause(){
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }
    public void OnResume(){
        Debug.Log("Resume");
        StartCoroutine(CountdownCoroutine());
    }
    public void OnRestart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        StartCoroutine(CountdownCoroutine());
    }
    public void OnExit(){
        Application.Quit();
    }

    private IEnumerator CountdownCoroutine()
    {
        pauseMenu.gameObject.SetActive(false);
        TextMeshProUGUI countDownText = countDownMenu.GetComponentInChildren<TextMeshProUGUI>();
        Debug.Log(countDownText);
        countDownMenu.gameObject.SetActive(true);
        Debug.Log("3");
        countDownText.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("2");
        countDownText.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        Debug.Log("1");
        countDownText.text = "1";
        yield return new WaitForSecondsRealtime(1f);

        countDownText.text = "Go!";
        yield return new WaitForSecondsRealtime(1f);

        countDownMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
