using UnityEngine;

public class MapCameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        transform.position = new Vector3(playerPosition.x, 150, playerPosition.z);
    }
}
