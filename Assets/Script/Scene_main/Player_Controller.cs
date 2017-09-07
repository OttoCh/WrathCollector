using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    Rigidbody2D rb = new Rigidbody2D();
    public float movementSpeed;
    Player_Schema P;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Animator animator = gameObject.GetComponentInChildren<Animator>();
        SpriteRenderer sp = gameObject.GetComponentInChildren<SpriteRenderer>();
        P = new Player_Schema(200, 200, 200, animator, sp);
    }

    private void Update()
    {
        //move player
        float horizontalAxisVal = Input.GetAxis("Horizontal");
        float verticalAxisVal = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(horizontalAxisVal, verticalAxisVal);
        movePlayer(dir);

    }

    private void movePlayer(Vector2 dir)
    {
        rb.velocity = dir * movementSpeed * Time.deltaTime;
        int mode = 0;
        if (rb.velocity.x == 0 && rb.velocity.y == 0) mode=0;
        else mode = 1;
        if (rb.velocity.x < 0) P.sp.flipX = true;
        else if (rb.velocity.x > 0) P.sp.flipX = false;
        P.animator.SetInteger("mode", mode);
        return;
    }

    private void interractPlayer()
    {
        
    }

}
