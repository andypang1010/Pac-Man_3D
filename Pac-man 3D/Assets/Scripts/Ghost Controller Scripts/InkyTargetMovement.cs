using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkyTargetMovement : MonoBehaviour
{
    [SerializeField] float pivotOffset;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] Transform BlinkyTransform;

    Vector3 pivot;

    void Update()
    {
        pivot = new Vector3(PlayerTransform.position.x, PlayerTransform.position.y, PlayerTransform.position.z + pivotOffset);
        transform.position = BlinkyTransform.position - 2 * pivot;
    }
}
