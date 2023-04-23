using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class gameManager : MonoBehaviour
{

    
    public static gameManager Instance;
    [Header("This gameManager script manages the \n transition between scenes, \n as well as the big datas.")]
    [SerializeField]

    GameObject pauseFrame;

    public float levelTime;
    float timer;
    public bool usingTimer;

    //The following is temporary initialization gameobjects. They are used to test turret inventory.
    public GameObject turret2;
    public GameObject turret3;
    public GameObject turret5;
    
    //The follow variables are all used for the turret inventory and turret select for level mechanism
    public int currentLevel;
    public List<GameObject> turretsForThisLevel = new List<GameObject>();
    public List<GameObject> turretInventory = new List<GameObject>();
    [HideInInspector]public GameObject preLevelCanvas;
    [HideInInspector] public GameObject turretSelectedContent;
    [HideInInspector] public GameObject turretInventoryContent;



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

    private void Start()
    {

        turretInventory.Add(turret2);
        turretInventory.Add(turret3);
        turretInventory.Add(turret5);

        preLevelCanvas = GameObject.Find("preLevelCanvas");
        turretInventoryContent = GameObject.Find("turretInventoryContent");
        turretSelectedContent = GameObject.Find("turretInventoryContent");


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
