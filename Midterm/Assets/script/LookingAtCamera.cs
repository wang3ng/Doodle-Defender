using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtCamera : MonoBehaviour
{
    protected Transform targetToLook;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        targetToLook = Camera.main.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.LookAt(targetToLook);
    }
}
