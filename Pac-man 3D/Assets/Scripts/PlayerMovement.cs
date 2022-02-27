using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static CharacterController controller;

    [SerializeField] float movementSpeed = 15f;

    public static Vector3 startingPosition = new Vector3(0, 0, -85);
    public static Quaternion startingRotation = new Quaternion(0, 0, 0, 0);

    public static bool movable;

    void Start()
    {
        // Initializing the starting position, rotation, and controller of the player
        movable = true;
        controller = GetComponent<CharacterController>();
        transform.position = startingPosition;
        transform.rotation = startingRotation;
    }

    void Update()
    {
        if (movable && controller.enabled)
        {
            // Gets the input of horizontal and vertical movement
            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * xMovement + transform.forward * zMovement;

            controller.Move(movement * movementSpeed * Time.deltaTime);
        }
    }
}
