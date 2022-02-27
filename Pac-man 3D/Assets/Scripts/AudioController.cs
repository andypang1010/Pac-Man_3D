using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip portalClip;
    [SerializeField] AudioClip respawnClip;
    [SerializeField] AudioClip eatClip;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip lostClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

        // Play portal clip when player passes through a portal
        if (PlayerCollision.enterPortal)
        {
            audioSource.PlayOneShot(portalClip);
        }

        // Play respawn clip when player is respawning
        if (PlayerCollision.respawning && PlayerCollision.lives > 0)
        {
            audioSource.PlayOneShot(respawnClip);
        }

        // Play eat clip when player eats something
        if (PlayerCollision.eatSomething)
        {
            audioSource.PlayOneShot(eatClip, 0.3f);
        }

        // Play win clip when player wins
        if (PlayerCollision.winGame)
        {
            Invoke("playWin", 1f);
        }

        // Play lose clip when player loses
        if (PlayerCollision.lostGame)
        {
            Invoke("playLose", 1f);
        }

    }

    private void playWin()
    {
        audioSource.PlayOneShot(winClip, 0.5f);
    }

    private void playLose()
    {
        audioSource.PlayOneShot(lostClip, 0.5f);
    }
}