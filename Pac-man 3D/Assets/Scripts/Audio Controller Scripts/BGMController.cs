using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip loseClip;
    [SerializeField] AudioClip BGMClip;

    bool playedOnce = false;
    bool playingBGM = false;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        else
        {
            if (!playingBGM)
            {
                playingBGM = true;
                audioSource.PlayOneShot(BGMClip);
                //audioSource.
            }
        }
        playedOnce = true;
    }
}
