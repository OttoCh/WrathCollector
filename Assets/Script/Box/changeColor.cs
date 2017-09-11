using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

    int c = 0;
    int k = 0;

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Renderer r = gameObject.GetComponent<Renderer>();
            Material m = r.material;
            if (c == 0) m.color = Color.blue;
            else if (c == 1) m.color = Color.red;
            else if (c == 2) m.color = Color.green;
            c++;
            if (c == 3)
            {
                c = 0;
                k++;
            }
            if (k == 1)
            {
                //tellManager_destroyed tm = new tellManager_destroyed();
                Destroy(gameObject);
            }
        }
    }

}