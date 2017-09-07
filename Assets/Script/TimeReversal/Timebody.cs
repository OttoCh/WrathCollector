using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timebody : MonoBehaviour {

    public bool isRewinding = false;

    List<PointInTime> pointInTime;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        pointInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
        {
            StartRewind();
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            StopRewind();
        }
	}

    private void FixedUpdate()
    {
        if(isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (pointInTime.Count > 0)
        {
            transform.position = pointInTime[0].position;
            transform.rotation = pointInTime[0].rotation;
            pointInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if(pointInTime.Count > Mathf.Round(5f/Time.fixedDeltaTime))
        {
            pointInTime.RemoveAt(pointInTime.Count - 1);
        }
        pointInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    void StartRewind()
    {
        isRewinding = true;
        rb.isKinematic = true;
    }
    void StopRewind()
    {
        isRewinding = false;
        rb.isKinematic = false;
    }
}

class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
