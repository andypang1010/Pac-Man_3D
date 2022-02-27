using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] Color powerColor = new Color(0, 255, 203);

    void Update()
    {
        if (!PlayerCollision.winGame)
        {
            if (PlayerCollision.fruitPower)
            {
                ShowPowerUp();
            }

            else if (PlayerCollision.lostGame)
            {
                SetColorText("You've lost...", Color.red);
            }

            else
            {
                ShowDefaultText();
            }
        }
        else
        {
            SetColorText("You've won!", powerColor);
        }

    }

    void ShowPowerUp()
    {
        SetColorText("Power Up!", powerColor);
        Invoke("ShowDefaultText", 14f);
    }

    void SetColorText(string life, Color color)
    {
        scoreText.SetText("Score: " + PlayerCollision.score);
        lifeText.SetText(life);

        scoreText.color = color;
        lifeText.color = color;
    }

    void ShowDefaultText()
    {
        SetColorText("Lives: " + PlayerCollision.lives, Color.white);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }
}
