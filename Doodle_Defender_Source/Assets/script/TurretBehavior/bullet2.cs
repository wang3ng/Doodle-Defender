
using UnityEngine;

public class bullet2: MonoBehaviour
{
    public GameObject targetEnemy;
    public float spd;
    public float bulletDis;
    Vector3 startPos;
    public GameObject hitParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(targetEnemy.transform);
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * spd * Time.deltaTime;
        if (Vector3.Distance(transform.position, startPos) >= bulletDis)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        // check if the other object has a specific tag
        if (hit.gameObject.CompareTag("Enemy"))
        {
            var a = Instantiate(hitParticle, new Vector3(hit.transform.position.x + 0.1f, hit.transform.position.y, hit.transform.position.z), hit.transform.rotation);
            hit.transform.GetComponent<Enemy>().health -= 10;
            hit.transform.GetComponent<Enemy>().gotHit = true;
            if (hit.transform.GetComponent<Enemy>().health > 0)
            {
                a.transform.SetParent(hit.transform);
            }
            SoundManager.Instance.sdHit.Play();
            Destroy(this.gameObject);
        }
    }
}
