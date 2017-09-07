using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    public float radius;
    public float power;

	// Use this for initialization
	void Start () {
        SphereCollider collider = GetComponent<SphereCollider>();
        radius = collider.radius;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("Start explosion");
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if(rb != null)
                {
                    Debug.Log(hit.name);
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f);    
                }
            }
        }
	}
}
