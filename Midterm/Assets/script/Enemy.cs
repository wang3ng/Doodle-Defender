
using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent nav;

    public int attack;
    public float moveSpeed;
    public float health;
    float totalHealth;
    [HideInInspector]public bool slowness = false;
    [HideInInspector]public float slownessCounter = 0;
    bool slownessTrigger = false;
    float slownessTotalTime = 3;
    float slownessStrength = 0.7f;
    public bool gotHit;

    [SerializeField]
    Animator anim;
    [SerializeField]
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("enemyTarget").transform;
        totalHealth = health;

    }

    // Update is called once per frame
    void Update()
    {

        nav.SetDestination(target.position);
        nav.speed = moveSpeed;


        if (slowness)
        {
            nav.speed = moveSpeed * (1- slownessStrength);
            slownessTrigger = true;
        }

        if (slownessTrigger)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(156, 174, 217, 255);
        }

        if (health <= 0)
        {
            target.gameObject.GetComponent<Health>().enemyNum += 1;
            Destroy(this.gameObject,0.1f);
        }

        if(health < totalHealth * 3/5)
        {
            if (anim != null) {
                anim.SetTrigger("Hurt");
                Debug.Log("hurt");
            }
        }

        if (slowness)
        {
            slownessCounter += Time.deltaTime;
        }

        if(slownessCounter >= slownessTotalTime)
        {
            slowness = false;
            slownessCounter = 0;
            slownessTrigger = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (gotHit)
        {
            this.GetComponent<SpriteRenderer>().color = new Color32(226, 67, 79, 255);
            Invoke("cancelGotHit", 0.5f);
        }



    }

    void cancelGotHit()
    {
        gotHit = false;
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == target.GetComponent<Collider>())
        {
            target.gameObject.GetComponent<Health>().currentHealth -= attack;
            
            Destroy(this.gameObject);
        }
    }
}
