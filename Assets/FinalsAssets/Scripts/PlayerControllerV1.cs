using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV1 : MonoBehaviour
{
    public GameManager gm;
    public AudioClip DeathClip;
    public AudioClip FoodClip;
    public float Speed;
    public float AddGravity;
    private Rigidbody2D rb;


    float xMove;
    float yMove;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(xMove * Speed * Time.deltaTime, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, yMove * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            gm.PlaySound(DeathClip);
            Destroy(GameObject.FindWithTag("Player"));
            
        }

        if (collision.gameObject.tag == "Food")
        {
            rb.gravityScale += AddGravity;
            gm.PlaySound(FoodClip);
            Destroy(collision.gameObject);
        }
    }

}