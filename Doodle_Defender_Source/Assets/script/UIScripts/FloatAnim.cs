using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

using Vector2 = UnityEngine.Vector2;


public class FloatAnim : MonoBehaviour
{
    [Header("UI script")]
    [Header("This commponenet adds a vertical float animation to the object")]
    [Header("The range of the float animation")]
    [SerializeField] float maxFloat; //The range of the float animation
    float floatDir = -1f; //private Float direction, either -1 or 1, used to determined if going up or down.
    Vector2 startPos;
    [Header("The strength of the float, recommended 0.01 for UI elements")]
    [SerializeField] float floatStrength; // The strength of the float

    void Start()
    {
        startPos = this.transform.position;
    }

    void Update()
    {

        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + floatDir * floatStrength);
        if (Mathf.Abs(this.transform.position.y - startPos.y) >= maxFloat - 1)
        {
            floatDir *= -1f;
        }
    }
}
