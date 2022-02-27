using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    float portalOffset = 10f;

    [SerializeField] Material ghostHitMaterial;

    public static int score = 0;
    public static int lives = 3;
    public static bool fruitPower = false;
    public static bool winGame = false;
    public static bool lostGame = false;
    public static bool enterPortal = false;
    public static bool eatSomething = false;
    public static bool respawning = false;

    private void Update()
    {
        winGame = false;
        lostGame = false;
        enterPortal = false;
        eatSomething = false;
        respawning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Portal":

                enterPortal = true;

                // Offset the player after leaving a portal so it doesn't get stuck
                if (transform.position.x < 0)
                {
                    portalOffset *= -1;
                }

                // Transforming the player's x-position to -1 * it's original x-position
                PlayerMovement.controller.enabled = false;
                transform.position = new Vector3(-transform.position.x + portalOffset, transform.position.y, transform.position.z);
                PlayerMovement.controller.enabled = true;

                break;

            case "Gem":
                Destroy(other.gameObject);
                score++;

                // Wins if no more gems are left in the game
                if (GameObject.FindGameObjectsWithTag("Gem").Length <= 1)
                {
                    winGame = true;
                    PlayerMovement.movable = false;
                }
                else
                {
                    PlayerMovement.controller.enabled = false;
                    eatSomething = true;
                    PlayerMovement.controller.enabled = true;

                }
                break;

            case "Fruit":
                eatSomething = true;
                score += 2;
                fruitPower = true;
                Destroy(other.gameObject);
                Invoke("deactivatePower", 14f);
                break;

            case "Ghost":

                // Eats ghost if player eats power up
                if (fruitPower)
                {
                    eatSomething = true;
                    score += 5;
                    Destroy(other.gameObject);
                }
                else
                {

                // Loses a life when ghost eats player
                    lives -= 1;

                    if (lives <= 0)
                    {
                        lostGame = true;
                        PlayerMovement.movable = false;
                    }
                    else
                    {
                        respawn();

                    }
                }
                break;
        }
    }

    // Respawn the player after being eaten by the ghosts at the starting position
    private void respawn()
    {
        respawning = true;
        PlayerMovement.controller.enabled = false;
        transform.position = PlayerMovement.startingPosition;
        transform.rotation = PlayerMovement.startingRotation;
        Invoke("allowMovement", 1.5f);
    }

    // Deactivate power up
    private void deactivatePower()
    {
        fruitPower = false;
    }

    // Allow player to move
    private void allowMovement()
    {
        PlayerMovement.controller.enabled = true;
        PlayerMovement.movable = true;
    }
}
