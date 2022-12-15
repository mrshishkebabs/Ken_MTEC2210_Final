using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV1 : MonoBehaviour
{
    public LayerMask ground;
    public AudioClip deathclip;
    public AudioClip foodclip;
    public float speed;
    public float addGrav;
    private Rigidbody2D rb;

    public GameManager gm;
    float xMove;
    float yMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");
        yMove = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, yMove * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            gm.PlaySound(deathclip);
            Destroy(GameObject.FindWithTag("Player"));
            
        }

        if (collision.gameObject.tag == "Food")
        {
            rb.gravityScale += addGrav;
            gm.PlaySound(foodclip);
            Destroy(collision.gameObject);
        }
    }

}