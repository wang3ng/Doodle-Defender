using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemyType;

    float timer = 0f;
    public float gapTime = 5f;
    public float gapMin = 0.7f;
    public float gapRaise = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= gapTime)
        {
            SoundManager.Instance.sdSpawn.Play();
            Instantiate(enemyType[Random.Range(0,enemyType.Length)],this.transform.position,this.transform.rotation);
            timer = 0;
            if (gapTime >= gapMin)
            {
                if (Random.Range(1, 10) <= 7)
                {
                    gapTime -= gapRaise;
                }
                else
                {
                    gapTime += gapRaise;
                }
            }
            else
            {
                gapTime = gapMin;
            }
        }
        
    }
}
