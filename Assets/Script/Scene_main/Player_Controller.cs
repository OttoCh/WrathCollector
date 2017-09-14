using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public Rigidbody2D rb = new Rigidbody2D();
    public float movementSpeed;
    public int jump_power;
    public int dash_power;
    public float additionalLinearDrag;
    private bool enableMove = true;
    Character_Move cm;
    Player_Schema P;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Animator animator = gameObject.GetComponentInChildren<Animator>();
        SpriteRenderer sp = gameObject.GetComponentInChildren<SpriteRenderer>();
        P = new Player_Schema(200, 200, 200, jump_power, dash_power, animator, sp);
        cm = new Character_Move(rb, movementSpeed, additionalLinearDrag);
    }

    private void Update()
    {
        //Debug.Log(rb.velocity);
        if (enableMove)
        {
            //move player

            Vector2 dir = cm.moveManager();
            changePlayerAnimation();
            changePlayerSpriteDirrection();
        }
    }

    private void changePlayerAnimation()
    {
        int mode;
        if(Mathf.Abs(rb.velocity.x) >= 0.5f)
        {
            //walk
            mode = 1;
        }
        else
        {
            //stand
            mode = 0;
        }
        P.changeAnimationState(mode);
    }

    private void changePlayerSpriteDirrection()
    {
        if (rb.velocity.x < 0) P.changeSpriteDirrection(true);
        else if (rb.velocity.x > 0) P.changeSpriteDirrection(false);
    }

    public bool enablePlayerMove(bool enableMove)
    {
        this.enableMove = enableMove;
        return enableMove;
    }

}

class Character_Move : Player_Controller
{
    bool stopMove = true;

    public Character_Move(Rigidbody2D rb, float movementSpeed, float additionalLinearDrag)
    {
        this.rb = rb;
        this.movementSpeed = movementSpeed;
        if (additionalLinearDrag >= 1.0f) additionalLinearDrag = 1.0f;
        this.additionalLinearDrag = additionalLinearDrag;
    }

    public Vector2 moveManager()
    {
        Debug.Log(stopMove);
        float horizontalAxisVal = Input.GetAxis("Horizontal");
        if(Mathf.Abs(horizontalAxisVal) >= 0.01f)
        {
            stopMove = false;
            Debug.Log("has false " + stopMove);
            player_move(new Vector2(horizontalAxisVal, 0.0f)); 
        }
        if (Mathf.Abs(horizontalAxisVal) <= 0.01f && this.stopMove == false)
        {
            //Debug.Log("stop player");
            player_stop();
            this.stopMove = true;
        }
        Vector2 dir = new Vector2();
        return dir;
    }

    private void player_move(Vector2 dir)
    {
        rb.velocity = new Vector2(movementSpeed * dir.x * Time.deltaTime, rb.velocity.y);
    }

    private void player_stop()
    {
        if (rb.velocity.x != 0.0f)
        {
            rb.AddForce(new Vector2(-(rb.velocity.x / 0.02f) * (additionalLinearDrag), 0.0f));
        }
    }
}
class Character_Jump : Player_Controller {

    public Character_Jump(int jump_power, Rigidbody2D rb)
    {
        this.jump_power = jump_power;
        this.rb = rb;
    }

    public void jump()
    {
        Vector2 jumpVector = new Vector2(0, jump_power)*100;
        rb.AddForce(jumpVector);
    }
}

class Character_Dash : Player_Controller
{

    public Character_Dash(int dash_power, Rigidbody2D rb)
    {
        this.dash_power = dash_power;
        this.rb = rb;
    }

    public void dash()
    {
        Vector2 dashVector = new Vector2(dash_power, 0);
        rb.AddForce(dashVector, ForceMode2D.Impulse);
    }

}