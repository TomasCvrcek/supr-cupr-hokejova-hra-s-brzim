using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public enum ScoreType
    {
        Player1Score,
        Player2Score,
        Plyer1Rounds,
        Plyer2Rounds,
    }

    public TMP_Text Player1ScoreText, Player2ScoreText, Player1RoundsText, Player2RoundsText;

    public UIManager uiManager;

    #region Scores
    public int player1Score, player2Score, player1Rounds, player2Rounds, roundsTotal = 0;
    public int MaxScore;
    #endregion

    public void Increment(ScoreType target)
    {
        if (target == ScoreType.Player1Score)
        {
            Player1ScoreText.text = (++player1Score).ToString();
        }
        else if (target == ScoreType.Player2Score)
        {
            Player2ScoreText.text = (++player2Score).ToString();
        }
    }

    public void IncrementRound(ScoreType target)
    {
        if (target == ScoreType.Plyer1Rounds)
        {
            Player1RoundsText.text = (++player1Rounds).ToString();
            Player1ScoreText.text = (player1Score = 0).ToString();
        }
        else if (target == ScoreType.Plyer2Rounds)
        {
            Player2RoundsText.text = (++player2Rounds).ToString();
            Player2ScoreText.text = (player2Score = 0).ToString();
        }
        roundsTotal++;
        Debug.Log(player1Score);
        Debug.Log(player2Score);
        if ((roundsTotal == MaxScore) || (player1Rounds >= (MaxScore/2+0.5)) || (player2Rounds >= (MaxScore / 2 + 0.5)))
        {
            if (player1Score > player2Score)
            {
                uiManager.ShowRestart(true);
            }
            else uiManager.ShowRestart(false);
            uiManager.ShowRestart(true);
        }else uiManager.ShowSwitch();
    }


    public void ResetScore()
    {
        Player1ScoreText.text = (player1Score = 0).ToString();
        Player2ScoreText.text = (player2Score = 0).ToString();
        Player1RoundsText.text = (player1Rounds = 0).ToString();
        Player2RoundsText.text = (player2Rounds = 0).ToString();
        roundsTotal = 0;
    }
}
    
    
