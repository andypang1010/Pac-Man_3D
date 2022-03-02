using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip eatClip;
    [SerializeField] AudioClip portalClip;
    [SerializeField] AudioClip respawnClip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (PlayerCollision.eatGem || PlayerCollision.eatFruit || PlayerCollision.eatGhost)
        {
            audioSource.PlayOneShot(eatClip);
        }

        else if (PlayerCollision.enterPortal)
        {
            audioSource.PlayOneShot(portalClip);
        }
        else if (PlayerCollision.startRespawn)
        {
            audioSource.PlayOneShot(respawnClip);
        }
    }
}