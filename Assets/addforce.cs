using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addforce : MonoBehaviour {

    public float force;
    public float vel;
    ConstantForce2D cb;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        cb = gameObject.GetComponent<ConstantForce2D>();

        //start move by force 
        //rb.AddForce(new Vector2(force, 0.0f));
        //StartCoroutine(waitandstop());

        //start move by velocity
        rb.velocity = new Vector2(vel, 0);
        StartCoroutine(waitandstop());
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(rb.velocity);
        //add negative force to stop this


    }

    IEnumerator waitandstop()
    {
        //stop by force
        yield return new WaitForSeconds(1.0f);
        cb.force = new Vector2(0, 0);
        rb.AddForce(new Vector2(-(rb.velocity.x/0.02f)*(5f/7f), 0.0f));

    }
}
