using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] Color powerColor = new Color(0, 255, 203);
    [SerializeField] Color lostColor = new Color(0, 0, 0);


    private void Update()
    {
        if (PlayerCollision.hasPower)
        {
            SetColorText("Power Up!", powerColor);
        }
        else if (PlayerCollision.winGame)
        {
            SetColorText("You've won!", powerColor);
        }
        else if (PlayerCollision.loseGame)
        {
            SetColorText("You've lost...", lostColor);
        }
        else
        {
            SetColorText("Lives: " + PlayerCollision.lives, Color.white);
        }
    }

    private void SetColorText(string life, Color color)
    {
        scoreText.SetText("Score: " + PlayerCollision.score);
        lifeText.SetText(life);

        scoreText.color = color;
        lifeText.color = color;
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
