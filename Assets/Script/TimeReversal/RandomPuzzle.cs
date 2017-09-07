using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPuzzle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        const int mapLength = 8;
        const int maxNumb = 8;
        int[] map = new int[mapLength];
        for(int i=0; i<maxNumb; i++)
        {
            map[i] = i;
        }
        Random randNumb = new Random();
        for(int j=0; j<mapLength; j++)
        {
            int newNumb = Random.Range(0, maxNumb);
            
            //swap(&map[j], &map[Mathf.Abs((j+newNumb)-mapLength)]));
        }


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private static unsafe void swap(int* a, int* b)
    {
        int c = *a;
        *a = *b;
        *b = c;
        return;
    }
}
