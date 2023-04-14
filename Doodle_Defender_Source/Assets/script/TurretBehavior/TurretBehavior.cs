using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    public AttackingTurret Turret;
    private float attackCoolDown = 0;
    private Transform Target;
    //0=roving,1=shooting,2=other
    private int state;
    void Update()
    {
        if (state == 0)
        {
            searchingTarget();
        }
        if (state == 1)
        {
            attackingTarget();
        }
        attackCoolDown -= Time.deltaTime;
        if(Target!=null)
        {
            transform.Find("HeadBase").LookAt(Target);
        }
    }
    private void searchingTarget()
    {
        Collider[] inRangeEnemies = Physics.OverlapSphere(transform.position, Turret.Range, Turret.TargetType);
        if (inRangeEnemies.Length > 0)
        {
            Target = inRangeEnemies[0].transform;
            state = 1;
        }
    }
    private void attackingTarget()
    {
        if (Target!=null && Vector2.Distance(transform.position, Target.position) <= Turret.Range)
        {
            doAttack();
        }
        else state = 0;
    }
    private void doAttack()
    {
        if (attackCoolDown <= 0)
        {
            Turret.Effect1(Target,transform);
            attackCoolDown = Turret.AttackCooldown();
        }        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Turret.Range);
    }
}
