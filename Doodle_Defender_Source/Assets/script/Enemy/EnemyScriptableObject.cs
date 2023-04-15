using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies", order = 1)]
public class EnemyScriptableObject : ScriptableObject
{
    //NavMeshAgent nav;

    public Sprite enemySprite; 

    public int attack;
    public float moveSpeed;
    public float angularSpeed; //temporary until i figure out how to use navmesh with scriptableobj
    public float health; //total health

    //previously [hideininspector], can be hidden again if necessary 
    public bool slowness = false;
    public float slownessCounter = 0;

    public bool slownessTrigger = false;
    public float slownessTotalTime = 3; //i feel like this could be moved somewhere else or just implemented into slownessCounter or something. we'll see
    public float slownessStrength = 0.7f;
    public bool gotHit;

    [SerializeField]
    Animator anim;
    [SerializeField]
    Transform target;

}