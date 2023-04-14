using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalBullet : MonoBehaviour
{
    public Transform Target;
    public float speed;
    void Update()
    {
        if (Target==null || Vector3.Distance(Target.position, transform.position) < 0.1)
        {
            Destroy(gameObject);
        }
        else transform.position = Vector3.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
    }
}
