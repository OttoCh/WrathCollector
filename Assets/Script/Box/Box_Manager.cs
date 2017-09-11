using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Manager : Box_Property {

    public void createBox(GameObject box, Vector3 pos, int mode)
    {
        //Create_Box CB = new Create_Box(box)
        this.mode = mode;
        createtheBox CB = new createtheBox();
        GameObject Box = CB.createBox(pos, mode, box);
        //make player unable to move
        Player_Controller pc = player.GetComponent<Player_Controller>();
        pc.enablePlayerMove(false);
        StartCoroutine(checkIfBoxDestroyed(Box));
    }

    public void boxHasDestroyed()
    {
        Player_Controller pc = player.GetComponent<Player_Controller>();
        pc.enablePlayerMove(true);
    }

    IEnumerator checkIfBoxDestroyed(GameObject box)
    {
        yield return new WaitUntil(() => box == null);
        boxHasDestroyed();
    }
}

class createtheBox : MonoBehaviour
{
    public GameObject createBox(Vector3 pos, int mode, GameObject box)
    {
        GameObject b = Instantiate(box, pos, Quaternion.identity);
        return b;
    }
}
