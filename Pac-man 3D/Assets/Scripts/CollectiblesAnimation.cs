using UnityEngine;

public class CollectiblesAnimation : MonoBehaviour
{
    [SerializeField] float floatFrequency = 1f;
    [SerializeField] float floatAmplitude = 0.1f;

    Vector3 offset = new Vector3();
    Vector3 currentPosition = new Vector3();

    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        // Make collectible float up and down with a float frequency
        currentPosition = offset;
        currentPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFrequency) * floatAmplitude;

        transform.position = currentPosition;
    }
}
