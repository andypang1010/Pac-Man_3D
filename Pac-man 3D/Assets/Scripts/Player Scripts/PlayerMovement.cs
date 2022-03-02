using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static CharacterController controller;

    public float movementSpeed = 15f;

    public static Vector3 startingPosition = new Vector3(0, 0, -85);
    public static Quaternion startingRotation = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        // Initializing the starting position, rotation, and controller of the player
        controller = GetComponent<CharacterController>();
        transform.position = startingPosition;
        transform.rotation = startingRotation;
    }

    private void Update()
    {
        if (controller.enabled)
        {
            // Gets the input of horizontal and vertical movement
            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * xMovement + transform.forward * zMovement;

            controller.Move(movement * movementSpeed * Time.deltaTime);
        }
    }

    // Respawn the player in its starting position
    public static void Respawn(GameObject player)
    {
        controller.enabled = false;
        player.transform.SetPositionAndRotation(startingPosition, startingRotation);
    }

    // Teleport the player to the other side of the portal
    public static void Teleport(GameObject player, float portalOffset)
    {
        if (player.transform.position.x < 0)
        {
            portalOffset *= -1;
        }

        controller.enabled = false;
        player.transform.position = new Vector3(-player.transform.position.x + portalOffset, player.transform.position.y, player.transform.position.z);
        controller.enabled = true;
    }
}