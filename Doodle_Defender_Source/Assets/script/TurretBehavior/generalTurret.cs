using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generalTurret : ScriptableObject
{
    [SerializeReference]
    public GameObject Bullet;    
    public float Damage=0;
    public float Durration=0;
    public float AttackSpeed=1;//Per Second
    public float Range=0;
    public string Name;
    public string description;
    public Sprite Art;
    public LayerMask TargetType;
    public virtual void Effect1(Transform Target, Transform Start)
    {
        Debug.Log("No effect given");
    }
    public float AttackCooldown()
    {
        return 1/AttackSpeed;
    }

}
[CreateAssetMenu(fileName = "Turret", menuName = "Turret/AttackingTurret", order = 1)]
public class AttackingTurret : generalTurret
{
    public override void Effect1(Transform Target,Transform Start)
    {
        GameObject bullet = Instantiate(Bullet, Start.position ,Quaternion.identity);
        bullet.GetComponent<generalBullet>().Target = Target;
    }
}


