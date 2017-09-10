using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Box : MonoBehaviour {

    public GameObject box;
    public GameObject colorBox;

    public Create_Box(GameObject box)
    {
        this.box = box;
    }

    public GameObject createBox(Vector3 pos, int mode)
    {
        Debug.Log("mode: " + mode);
        GameObject b = Instantiate(box, pos, Quaternion.identity);
        return b;
    }

}
