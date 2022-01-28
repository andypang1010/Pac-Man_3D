using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static int score = 0;
    public static bool fruitPower = false;

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Ghost":
                if (!fruitPower)
                {
                    PlayerMovement.isAlive = false;
                    Debug.Log("Player lost");
                    score = 0;
                }
                else
                {
                    Debug.Log("Ate ghost");
                    score += 5;
                    Destroy(collision.gameObject);
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Portal":
                float offset = 10f;
                if (transform.position.x < 0)
                {
                    offset *= -1;
                }
                transform.position = new Vector3(-transform.position.x + offset, transform.position.y, transform.position.z);
                break;

            case "Gem":
                score++;
                Destroy(other.gameObject);
                break;

            case "Fruit":
                score += 2;
                fruitPower = true;
                Destroy(other.gameObject);
                break;
        }
    }
}
