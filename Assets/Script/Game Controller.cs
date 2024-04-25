using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject grenade;
    // public GameObject explode;
    public AudioSource bgm;
    public Canvas endMenu;
    public Canvas pauseMenu;
    public Canvas countDownMenu;
    public Canvas main;
    public float time = 70;
    public TextMeshProUGUI timeText;
    private float b;
    private int state = 1; // 0: start, 1: main, 2: pause, 3: countdown
    // public Text countDownText;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = "Time: " + time.ToString("F2");
        grenade.GetComponent<Animator>().SetBool("end", false);
        OnStart();
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
        // startMenu.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
        countDownMenu.gameObject.SetActive(false);
        endMenu.gameObject.SetActive(false);

        Time.timeScale = 0f;
        StartCoroutine(StartGameRoutine());

        Vector3 p = grenade.GetComponent<Transform>().position;
        b = p.x;
    }

    public void OnPause(){
        if(state != 1){
            return;
        }
        bgm.Pause();
        state = 2;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void OnResume(){
        Debug.Log("Resume");
        StartCoroutine(StartGameRoutine());
    }
    
    public void OnRestart(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        OnStart();
        state = 1;
    }
    
    public void OnExit(){
        Application.Quit();
    }
    
    public void OnWin(){
        state = 2;
        Vector3 p = grenade.GetComponent<Transform>().position;
        // Debug.Log(p);
        if(p.x < b){
            timeText.text = "Player 2 wins";
        } else {
            timeText.text = "Player 1 wins";
        }
        // Time.timeScale = 0;
        // explode.GetComponent<Animator>().Play();
        grenade.GetComponent<Grenade>().Explode();
        GameObject.Find("Spawner").GetComponent<Spawner>().clearProps();
        Invoke("invokeEndMenu", 2f);
    }

    public void OnReturnToMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private IEnumerator StartGameRoutine(){
        yield return CountdownCoroutine();
        bgm.Play();
    }

    void invokeEndMenu(){
        endMenu.gameObject.SetActive(true);
    }

    private IEnumerator CountdownCoroutine()
    {
        state = 3;
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
        state = 1;
    }

    public void End(){
        Time.timeScale = 0;
        // grenade.GetComponent<Animator>().SetBool("end", true);
    }
}
