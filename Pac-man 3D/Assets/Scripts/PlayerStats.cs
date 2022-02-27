using UnityEngine;
using TMPro;
public class PlayerStats : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] Color powerColor = new Color(0, 255, 203);

    void Update()
    {
        if (!PlayerCollision.winGame)
        {
            scoreText.SetText("Score: " + PlayerCollision.score);

            if (PlayerCollision.fruitPower)
            {
                lifeText.SetText("Power Up!");

                scoreText.color = powerColor;
                lifeText.color = powerColor;
            }

            else
            {
                lifeText.SetText("Live: " + PlayerCollision.lives);

                scoreText.color = Color.white;
                lifeText.color = Color.white;
            }
        }
        else
        {
            lifeText.SetText("You've Won!");
        }

    }
}
