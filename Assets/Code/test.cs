using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private LineRenderer line;
    private float dist;
    private float speed = 70f;
    private float dur = 50f;

    private Transform origin;
    private Transform destination;
    int elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.Find("origin").transform;
        destination = GameObject.Find("button-left").transform;

        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        line.SetWidth(3f, 3f);

        dist = Vector3.Distance(origin.position, destination.position);
    }

    // Create draw line animation to be called upon at every button-press for duration dur 
    void MakeLine(int elapsedTime)
    {
        float len = elapsedTime * speed;
        Vector3 a = origin.position;
        Vector3 b = destination.position;

        if (len <= dist + dur)
        {
            Vector3 leadingPoint = Mathf.Clamp(len, 0, dist) * Vector3.Normalize(b - a) + a;
            Vector3 trailingPoint = Mathf.Clamp(len - dur, 0, dist) * Vector3.Normalize(b - a) + a;

            if (len <= dist) { line.SetPosition(1, leadingPoint); }

            if (len >= dur) { line.SetPosition(0, trailingPoint); }
        }
    }

    // Update is called once per frame
    // Read beatmap file, call for the line animation
    void Update()
    {   
        elapsedTime = (int)Time.time;
        MakeLine(elapsedTime);
    }
}