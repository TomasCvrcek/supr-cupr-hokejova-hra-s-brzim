using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class puck : MonoBehaviour
{
    // Start is called before the first frame update

    public Score ScoreInstance;
    AudioManager audioManager;
    public Transform DefenderTransform;
    public Transform AttackerTransform;
    public float speedIncreaseFactor = 2f;
    public float speed = 10f;
    public bool IsTouchingDefender { get; private set; }
    public static bool IsAttacker { get; private set; }
    public static bool WasGoal { get; private set; }
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal= false;
        IsAttacker= true;
        //Points = 0;
    }

    private void Awake()
    {
        audioManager= GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (!WasGoal && IsAttacker == true)
        {
            

            if (collision.CompareTag("GoalCollider"))
            {
                audioManager.PlaySFX(audioManager.goal);
                ScoreInstance.Increment(Score.ScoreType.Player1Score);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }else if (!WasGoal && !IsAttacker)
        {
            
            if (collision.CompareTag("GoalCollider"))
            {
                audioManager.PlaySFX(audioManager.goal);
                ScoreInstance.Increment(Score.ScoreType.Player2Score);
                WasGoal = true;
                StartCoroutine(ResetPuck());
            }
        }
        CheckScore();


    }


    public void CheckScore()
    {
        if (ScoreInstance.player1Score == 10)
        {
            ScoreInstance.IncrementRound(Score.ScoreType.Plyer1Rounds);
            if (IsAttacker)
            {
                IsAttacker = false;
            }
            else IsAttacker = true;


        }
        else if (ScoreInstance.player2Score == 10)
        {
            ScoreInstance.IncrementRound(Score.ScoreType.Plyer2Rounds);
            if (IsAttacker)
            {
                IsAttacker = false;
            }
            else IsAttacker = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("defender"))
        {
            IsTouchingDefender = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("defender"))
        {
            IsTouchingDefender = false;
        }else if (collision.gameObject.CompareTag("attacker")) rb.velocity *= speedIncreaseFactor;

    }


    public void ScoreForDefender()
    {
        if (IsAttacker)
        {
            ScoreInstance.Increment(Score.ScoreType.Player2Score);
            StartCoroutine(ResetPuck());
        }
        else
        {
            ScoreInstance.Increment(Score.ScoreType.Player1Score);
            StartCoroutine(ResetPuck());
        }
        CheckScore();
    }


    private IEnumerator ResetPuck()
    {
        rb.velocity = new Vector2(0, 0);
        rb.position = new Vector2(1, 9);
        WasGoal= false;
        if (DefenderTransform != null)
        {
            DefenderTransform.position = new Vector2(0, 74);
        }
        else
        {
            Debug.LogWarning("DefenderTransform not set in the inspector.");
        }
        if (AttackerTransform != null)
        {
            AttackerTransform.position = new Vector2(1, 0);
        }
        else
        {
            Debug.LogWarning("AttackerTransform not set in the inspector.");
        }
        yield return new WaitForSecondsRealtime(3);
    }
}



