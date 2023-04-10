using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class turret5 : MonoBehaviour
{
    public float attackGap;
    float timer = 0f;
    public GameObject firePoint;
    public GameObject bullet;
    public GameObject targetEnemy;


    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackGap)
        {
            timer = 0f;
            shoot();

        }


    }

    void shoot()
    {
        if (targetEnemy != null)
        {
            GameObject a = Instantiate(bullet, firePoint.transform.position, transform.rotation);
            a.GetComponent<bullet5>().targetEnemy = targetEnemy;
        }
    }
}
