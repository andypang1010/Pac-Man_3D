using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [SerializeField] float movementSpeed = 70f;
    [SerializeField] Vector3 startingPosition = new Vector3(0, 0, -85);

    public static bool isAlive;

    void Start()
    {
        isAlive = true;
        controller = GetComponent<CharacterController>();
        transform.position = startingPosition;
    }

    void Update()
    {
        if (isAlive)
        {
            float xMovement = Input.GetAxis("Horizontal");
            float zMovement = Input.GetAxis("Vertical");

            Vector3 movement = transform.right * xMovement + transform.forward * zMovement;

            controller.Move(movement * movementSpeed * Time.deltaTime);
        }
    }
}
