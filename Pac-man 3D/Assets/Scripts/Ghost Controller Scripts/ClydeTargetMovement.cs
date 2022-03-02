using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClydeTargetMovement : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minZ;
    [SerializeField] float maxZ;

    private void Start()
    {
        transform.position = RandomizePosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Clyde")
        {
            transform.position = RandomizePosition();
        }
    }

    private Vector3 RandomizePosition()
    {
        return new Vector3(Random.Range(minX, maxX), 0, Random.Range(minZ, maxZ));
    } 
}
