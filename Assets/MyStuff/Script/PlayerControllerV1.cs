using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerV1 : MonoBehaviour
{
    public LayerMask ground;
    public float speed;
    private Rigidbody2D rb;

    float xMove;
    float yMove;
    public float distanceCheckAmount = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //   Debug.Log(GetSum("six", "138"));
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
        /*
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            //rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            //rb.AddForce(Vector2.right * speed * Time.deltaTime);
        }

    */

        rb.velocity = new Vector2(xMove * speed * Time.deltaTime, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, yMove * speed * Time.deltaTime);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public bool GroundCheck()
    {
        bool onGround = Physics2D.Raycast(transform.position, Vector2.down, distanceCheckAmount, ground);

        return onGround;
    }
}