using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Manager : MonoBehaviour {

    GameObject Box;

    public void createBox(GameObject box, Vector3 pos, int mode)
    {
        Create_Box CB = new Create_Box(box);
        GameObject Box = CB.createBox(pos, mode);
        Debug.Log(Box);
        StartCoroutine(checkIfBoxDestroyed(Box));
    }

    public void boxHasDestroyed()
    {
        Debug.Log("box has been destroyed");
    }

    IEnumerator checkIfBoxDestroyed(GameObject box)
    {
        yield return new WaitUntil(() => box == null);
        boxHasDestroyed();
    }
}
