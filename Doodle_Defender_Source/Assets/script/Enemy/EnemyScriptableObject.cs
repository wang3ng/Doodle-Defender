using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemies", order = 1)] //set up menus
public class EnemyScriptableObject : ScriptableObject
{
    //NavMeshAgent nav;

    public Sprite enemySprite; 

    public int attack;
    public float moveSpeed;
    public float angularSpeed; //temporary until i figure out how to use navmesh with scriptableobj
    public float health; //total health

    //previously [hideininspector], can be hidden again if necessary 
    //public bool isSlowed = false; //previously 'slowness' 
    //public float slowedCount = 0; //tracks time enemy's been slowed for, previously 'slownessCounter'

    //public bool slownessTrigger = false;
    public float slowedLimit = 3; //upper limit on time enemy is slowed for, previously 'slownessTotalTime' 
    public float slowStrength = 0.7f; //how strongly slowed 
    //public bool gotHit;

    [SerializeField]
    Animator anim;
    [SerializeField]
    Transform target;

}