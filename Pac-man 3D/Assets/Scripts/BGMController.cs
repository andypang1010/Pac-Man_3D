using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioClip BGMClip;

    bool playedOnce = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(BGMClip);
    }

    private void Update()
    {
        if (PlayerCollision.winGame && !playedOnce)
        {
            audioSource.PlayOneShot(winClip);
        }

        else if (PlayerCollision.loseGame && !playedOnce)
        {
            audioSource.PlayOneShot(loseClip);
        }

        playedOnce = true;
    }
}
