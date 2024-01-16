using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 mousePos;
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
    void FixedUpdate()
    {
        HandleMovement();
        RotateWithMouse();
    }

    private void HandleMovement()
    {
        float MoveX = 0f;
        float MoveY = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveY = +1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveX = -1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveY = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveX = +1f;
        }

        Vector2 movement = new Vector2(MoveX, MoveY).normalized;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void ResetPosition()
    {
        rb.velocity = rb.position = new Vector2(0, -5);
    }



    void RotateWithMouse()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

      
        //angle -= 180f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;
    }
}