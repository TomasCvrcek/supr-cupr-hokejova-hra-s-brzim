using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{

    public float speed = 10f;
    public puck PuckScript;
    public float speedIncreaseFactor = 50f;
    AudioManager audioManager;


    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleScoring();
        LookAtPuck();
    }


    private void HandleScoring()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PuckScript != null)
        {
            if (PuckScript.IsTouchingDefender)
            {
                Debug.Log("Bžžžžžžžžum");
                PuckScript.ScoreForDefender();
            }
        }
    }

    public void ResetPosition()
    {
        rb.velocity = rb.position = new Vector2(0, 74);
    }


    private void HandleMovement()
    {
        float MoveX = 0f;
        float MoveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            MoveY = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveX = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveY = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveX = +1f;
        }

        Vector2 movement = new Vector2(MoveX, MoveY).normalized;
        rb.MovePosition(rb.position + speed * Time.fixedDeltaTime * movement);
    }

    private void LookAtPuck()
    {
        if (PuckScript != null)
        {
            Vector2 direction = PuckScript.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
        }
    }
}

