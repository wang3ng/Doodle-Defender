using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class EnemyManager : MonoBehaviour
{
    public EnemyScriptableObject enemy; //management variables 
    NavMeshAgent nav;
    [SerializeField] Animator anim;
    [SerializeField] Transform target; 

    [SerializeField] int attack; //basic variables 
    [SerializeField] float moveSpeed;
    [SerializeField] float currentHealth;

    bool isSlowed; //slow related variables 
    bool onSlow;
    float slowedCounter;

    bool hit; //if gotten hit 

    private void Start()
    {
        AssignValues();
    }
    private void Update()
    {
        nav.SetDestination(target.position);
        nav.speed = moveSpeed;

        CheckIfSlowed(isSlowed);

        CheckHealth(currentHealth);

        if (hit)
        {
            GetComponent<SpriteRenderer>().color = new Color32(226, 67, 79, 255);
            Invoke("ResetAfterHit", 0.5f); 
        }
    }

    void ResetAfterHit()
    {
        hit = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == target.GetComponent<Collider>())
        {
            target.gameObject.GetComponent<Health>().currentHealth -= attack;
            Destroy(gameObject);
        }
    }

    void AssignValues() //this script instantiates and manages the enemy generated using the enemy scriptableobj template 
    {
        attack = enemy.attack; //basic values  
        moveSpeed = enemy.moveSpeed; 
        currentHealth = enemy.health;

        isSlowed = false; //slow management 
        onSlow = false; 

        nav = GetComponent<NavMeshAgent>(); //pathfinding vars
        nav.angularSpeed = enemy.angularSpeed;

        target = GameObject.Find("enemyTarget").transform; //pathfinding endpoint
    }

    void CheckIfSlowed(bool slowStatus)
    {
        if (slowStatus)
        {
            nav.speed = moveSpeed * (1 - enemy.slowStrength); //calculate slowed movespeed
            onSlow = true;

            slowedCounter += Time.deltaTime; //track the time slowed 
        }

        if (onSlow) { //change sprite color. i don't know if this needs to be a separate var 
            GetComponent<SpriteRenderer>().color = new Color32(156, 174, 217, 255); 
        }

        if(slowedCounter >= enemy.slowedLimit) //if slow runs out 
        {
            isSlowed = false;
            slowedCounter = 0;
            onSlow = false;
            GetComponent<SpriteRenderer>().color = Color.white; 
        }

    }

    void CheckHealth(float health)
    {
        if(health <= 0) //if enemy at 0 hp
        {
            target.gameObject.GetComponent<Health>().enemyNum += 1; //update display of enemies killed

            Destroy(gameObject, 0.1f); //destroy enemy
        }
        else if(health < enemy.health * 0.6) //if at less than 60% health 
        {
            if(anim != null) //if animator exists
            {
                anim.SetTrigger("Hurt");
                Debug.Log("enemy hurt"); 
            }
        }
    }
}
