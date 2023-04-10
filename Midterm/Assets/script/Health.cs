using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;
    [SerializeField]
    TextMeshProUGUI healthText;
    [SerializeField]
    TextMeshProUGUI enemyNumText;
    public int enemyNum = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "" + currentHealth;
        enemyNumText.text = "Enemy Defeated: " + enemyNum;
        if (currentHealth <= 0)
        {
            gameManager.Instance.restartScene();
        }

    }
}
