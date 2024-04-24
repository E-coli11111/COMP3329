using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject grenade;
    public Canvas startMenu;
    public Canvas pauseMenu;
    public Canvas countDownMenu;
    public Canvas main;
    public float time = 60;
    public TextMeshProUGUI timeText;
    private float b;
    // public Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        main.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        countDownMenu.gameObject.SetActive(false);
        startMenu.gameObject.SetActive(true);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            OnPause();
        }
        time -= Time.deltaTime;
        timeText.text = "Time: " + time.ToString("F2");

        if(time <= 0){
            OnWin();
        }
    }
    public void OnStart(){
        startMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
        Time.timeScale = 0f;
        StartCoroutine(CountdownCoroutine());
        // pauseMenu.gameObject.SetActive(false);
        // countDownMenu.gameObject.SetActive(false);
        Vector3 p = grenade.GetComponent<Transform>().position;
        b = p.x;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        StartCoroutine(CountdownCoroutine());
    }
    
    public void OnExit(){
        Application.Quit();
    }
    
    public void OnWin(){
        Vector3 p = grenade.GetComponent<Transform>().position;
        Debug.Log(p);
        if(p.x < b){
            timeText.text = "Player 2 wins";
        } else {
            timeText.text = "Player 1 wins";
        }
        Time.timeScale = 0;
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