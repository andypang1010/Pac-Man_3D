using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PlayerCollision.winGame || PlayerCollision.lostGame)
        {
            audioSource.Pause();
        }
    }
}
