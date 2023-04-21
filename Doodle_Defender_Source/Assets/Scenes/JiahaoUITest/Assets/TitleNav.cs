using UnityEngine;
using UnityEngine.AI;


public class TitleNav : MonoBehaviour
{
    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        
        nav = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
    }
}
