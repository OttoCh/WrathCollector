using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour {

    public GameObject boxManager_obj;
    public GameObject box;
    public int mode;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 pos = collision.gameObject.transform.position;
            Box_Manager bm = boxManager_obj.GetComponent<Box_Manager>();
            bm.createBox(box, pos, mode);
            //Box_Manager bm = new Box_Manager(box, mode, pos);
            TriggerArea ta = gameObject.GetComponent<TriggerArea>();
            Destroy(ta);
        }
    }
}
