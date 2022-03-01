using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    float portalOffset = 10f;

    public static int score = 0;
    public static int lives = 3;
    public static float powerTime = 10f;

    public static bool eatGem;
    public static bool eatFruit;
    public static bool hasPower;
    public static bool eatGhost;
    public static bool collideGhost;
    public static bool startRespawn;
    public static bool winGame;
    public static bool loseGame;
    public static bool enterPortal;

    private void Update()
    {
        eatGem = false;
        eatFruit = false;
        eatGhost = false;
        collideGhost = false;
        startRespawn = false;
        enterPortal = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Gem":
                eatGem = true;

                score++;
                Destroy(collider.gameObject);

                if (GameObject.FindGameObjectsWithTag("Gem").Length <= 1)
                {
                    winGame = true;
                    loseGame = false;
                }
                break;

            case "Fruit":
                eatFruit = true;
                hasPower = true;

                score += 2;
                Destroy(collider.gameObject);
                Invoke("deactivatePower", powerTime);
                break;

            case "Ghost":
                if (hasPower)
                {
                    eatGhost = true;
                    score += 5;
                }
                else
                {
                    lives--;
                    if (lives == 0)
                    {
                        loseGame = true;
                        winGame = false;
                    }
                    else
                    {
                        collideGhost = true;
                        startRespawn = true;
                        PlayerMovement.Respawn(gameObject);
                        Invoke("EnableMovement", 1.5f);
                    }
                }
                break;

            case "Portal":
                enterPortal = true;
                PlayerMovement.Teleport(gameObject, portalOffset);
                break;
        }
    }

    private void deactivatePower()
    {
        hasPower = false;
    }

    // Enable player movement
    private void EnableMovement()
    {
        PlayerMovement.controller.enabled = true;
    }
}