using UnityEngine;
using TMPro;
public class PlayerScore : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    void Update()
    {
        text.SetText("Score: " + PlayerCollision.score);
    }
}
