using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyScriptableObject enemy;

    private float attack;
    private float currentHealth; 

    private void Start()
    {
        AssignValues();
    }

    void AssignValues() //this script instantiates and manages the enemy generated using the enemy scriptableobj template 
    {
        attack = enemy.attack;
        currentHealth = enemy.health; 
        //etc?
    }
}
