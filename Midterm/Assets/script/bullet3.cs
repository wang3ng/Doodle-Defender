using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class bullet3 : MonoBehaviour
{

    public GameObject targetEnemy;
    public GameObject hitParticle;
    public float bulletTime;
    private float timer;
    public float attack;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        float dis = Vector3.Distance(startPos,targetEnemy.transform.position);
        Vector3 size = this.transform.localScale;
        float width = size.x;
        float height = size.y;
        float depth = size.z;
        timer = 0;
        transform.LookAt(targetEnemy.transform);
        this.transform.localScale = new Vector3(width,height, dis);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > bulletTime)
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
            hit.transform.GetComponent<Enemy>().health -= 0.5f;
            hit.transform.GetComponent<SpriteRenderer>().color = new Color32(226, 67, 79, 255);
            hit.GetComponent<Enemy>().slowness = true;
            hit.GetComponent<Enemy>().slownessCounter = 0;
            if (hit.transform.GetComponent<Enemy>().health > 0)
            {
                a.transform.SetParent(hit.transform);
            }
            SoundManager.Instance.sdHit.Play();
            Invoke("DestroySelf", 0.2f);
        }
    }

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
