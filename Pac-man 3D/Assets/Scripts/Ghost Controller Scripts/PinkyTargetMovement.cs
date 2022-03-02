using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkyTargetMovement : MonoBehaviour
{
    [SerializeField] float targetOffset;
    [SerializeField] Transform PlayerTransform;

    void Update()
    {
        transform.position = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, PlayerTransform.position.z + targetOffset);
    }
}
