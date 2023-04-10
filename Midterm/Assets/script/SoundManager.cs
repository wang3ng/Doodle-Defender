using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource sdHit;
    public AudioSource sdSpawn;
    public AudioSource sdBGM;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        //sdBGM.Play();


    }


}
