using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Quaternion = UnityEngine.Quaternion;

public class bullet5 : MonoBehaviour
{
    public GameObject targetEnemy;
    public GameObject hitParticle;
    public float spd = 10f;
    float gravity = 7.5f;
    float timer = 0;
    public float attack;
    private Vector3 initialVelocity;
    bool hitted = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos;
        targetPos.x = transform.position.x + (targetEnemy.transform.position.x - transform.position.x) / 2;
        targetPos.z = transform.position.z + (targetEnemy.transform.position.z - transform.position.z) / 2;
        float height = Vector3.Distance(this.transform.position,targetEnemy.transform.position)*1.2f;
        transform.LookAt(new Vector3(targetPos.x,height, targetPos.z));


        Destroy(this.gameObject, 3f);


    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += transform.forward * spd * Time.deltaTime;
        Vector3 pos = transform.position;
        pos.y = transform.position.y - gravity * Time.deltaTime*timer*1.2f;
        transform.position = pos;

        if (this.transform.position.y<= 0f)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider hit)
    {
        // check if the other object has a specific tag
        if (hit.gameObject.CompareTag("Enemy") && !hitted)
        {
            var a = Instantiate(hitParticle, new Vector3(hit.transform.position.x + 0.1f, hit.transform.position.y, hit.transform.position.z), hit.transform.rotation);
            hit.transform.GetComponent<Enemy>().health -= attack;
            if (hit.transform.GetComponent<Enemy>().health > 0)
            {
                a.transform.SetParent(hit.transform);
                
            }
            hitted = true;
            SoundManager.Instance.sdHit.Play();
            Destroy(this.gameObject, 1f);
        }
    }
}
