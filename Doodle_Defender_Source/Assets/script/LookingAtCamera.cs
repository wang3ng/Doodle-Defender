using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LookingAtCamera : MonoBehaviour
{
    protected Transform targetToLook;
    public bool Flip;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        targetToLook = Camera.main.transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Flip)
        {
            transform.LookAt(2 * transform.position - targetToLook.transform.position);
        }
        else
        {
            transform.LookAt(targetToLook);
        }
    }
}
