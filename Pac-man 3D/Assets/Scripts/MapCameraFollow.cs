using UnityEngine;

public class MapCameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float offsetDistance = 150f;

    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        transform.position = new Vector3(playerPosition.x, offsetDistance, playerPosition.z);
    }
}
