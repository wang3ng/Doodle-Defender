using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameManager : MonoBehaviour
{
    public static gameManager Instance;
    [SerializeField]
    GameObject pauseFrame;
    public float levelTime;
    float timer;
    public bool usingTimer;
    [SerializeField] TextMeshProUGUI timerTxt;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        if (usingTimer)
        {
            timer += Time.deltaTime;

            if (levelTime - timer <= 0)
            {
                levelComplete();
            }
            var a = Mathf.RoundToInt(levelTime - timer);
            timerTxt.text = "Level Remaining: " + a;
        }

    }

    public void levelComplete()
    {
        switchToNextScene();
    }

    public void pauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseFrame.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseFrame.SetActive(false);
        }
    }

    public void switchToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Destroy(gameObject);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
    }

}
