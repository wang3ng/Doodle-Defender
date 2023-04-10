using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret3 : MonoBehaviour
{
    public float attackGap;
    float timer;
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
            a.GetComponent<bullet3>().targetEnemy = targetEnemy;
        }
    }
}
