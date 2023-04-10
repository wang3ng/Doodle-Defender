using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
