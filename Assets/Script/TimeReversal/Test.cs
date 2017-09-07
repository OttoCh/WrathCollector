using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private int mass;
    private int importance;
    private string name;

    public Test(string name)
    {
        this.name = name;
        mass = 1;
        importance = 3;
    }

	// Use this for initialization
	void Start () {
        Body body = new Body();
        body.showName();

        Debug.Log(mass);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public string myName()
    {
        return name;
    }

    public int changeMassValue(int newMass)
    {
        changeMass(newMass);
        return mass;
    }

    private void changeMass(int newMass)
    {
        mass = newMass;
        return;
    }

    private void changeImportance(int newImportance)
    {
        importance = newImportance;
        return;
    }
}

public class Body
{
    public string name;

    public Body()
    {
        name = "unknown";
    }

    public void showName()
    {
        Debug.Log(name);
    }
}

