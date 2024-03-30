using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private LineRenderer line;
    private float counter;
    private float dist;
    private float speed = 70f;

    public Transform origin;
    public Transform destination;
    
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, origin.position);
        line.SetWidth(3f, 3f);

        dist = Vector3.Distance(origin.position, destination.position);
    }
    
    // Create draw line animation to be called upon at every button-press for duration dur 
    void MakeLine(int dur)
    {
        if (counter < dist + dur) 
        {
            counter += .1f / speed;
            float len = Mathf.Lerp(0, dist + dur, counter);
            Vector3 a = origin.position;
            Vector3 b = destination.position;
            Vector3 leadingPoint = len * Vector3.Normalize(b - a) + a;
            Vector3 trailingPoint = (len - dur) * Vector3.Normalize(b - a) + a;

            if (len <= dist) { line.SetPosition(1, leadingPoint); }

            if (len >= dur) { line.SetPosition(0, trailingPoint); }
        }
    }
    
    // Update is called once per frame
    // Read beatmap file, call for the line animation
    void Update()
    {
        int dur = 50; // let 50 be the duration of a single beat?
        MakeLine(dur);
    }
}