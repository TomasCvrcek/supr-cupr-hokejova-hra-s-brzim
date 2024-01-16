
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
    public GameObject CanvasGameOptions;
    public GameObject CanvasSwitch;

    public GameObject Player1WinText;
    public GameObject Player2WinText;

    public Score scoreScript;
    public puck PuckScript;
    public MoveWASD DefenderScript;
    public Player AttackerScript;

    public void ShowRestart(bool didPlayer1Win)
    {
        Time.timeScale = 0;
        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);
        if(didPlayer1Win)
        {
            Player1WinText.SetActive(true);
            Player2WinText.SetActive(false);
        }
        else
        {
            Player1WinText.SetActive(false);
            Player2WinText.SetActive(true);
        }
    }

    public void ShowSettings()
    {
        Time.timeScale = 0;
        CanvasGameOptions.SetActive(true);
        CanvasGame.SetActive(false);
    }

    public void CloseSettings()
    {
        Time.timeScale = 1;
        CanvasGameOptions.SetActive(false);
        CanvasGame.SetActive(true);
    }

    public void ShowSwitch()
    {
        Time.timeScale = 0;
        CanvasSwitch.SetActive(true);
        CanvasGame.SetActive(false);
    }

    public void CloseSwitch()
    {
        Time.timeScale = 1;
        CanvasSwitch.SetActive(false);
        CanvasGame.SetActive(true);
    }



    public void RestartGame()
    {
        Time.timeScale = 1;
        CanvasGame.SetActive(true);
        CanvasRestart.SetActive(false);
        scoreScript.ResetScore();
    }
}

