using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MakeTrail : MonoBehaviour
{

    private LineRenderer line;
    private float counter;
    private float dist;
    private float speed;
    private float dur;
    
    private string button;
    private Transform origin;
    private Transform destination;
    private Transform buttonTransform;
    private Dictionary<string, Transform> buttonTransforms;
    
    private List<string[]> hitObjects;
    private int index;
    private int startTime;
    
    private int nextBeat;
    
    // Create draw line animation to be called upon at every button-press for duration dur 
    void MakeLine(int elapsedTimeMillis)
    {
        dist = Vector3.Distance(origin.position, destination.position);
        if (counter < dist + dur) 
        {
            // counter += .1f / speed;
            // float len = Mathf.Lerp(0, dist + dur, counter);
            counter = elapsedTimeMillis * speed;
            float progress = counter / ((dist + dur) * speed);
            float len = Mathf.Lerp(0, dist + dur, progress);
            Vector3 a = origin.position;
            Vector3 b = destination.position;
            Vector3 leadingPoint = len * Vector3.Normalize(b - a) + a;
            Vector3 trailingPoint = (len - dur) * Vector3.Normalize(b - a) + a;

            if (len <= dist) { line.SetPosition(1, leadingPoint); }

            if (len >= dur) { line.SetPosition(0, trailingPoint); }
        }
        
        // TODO: add origin and button circles animation
    }
    
    // Translate location of .osu beatmap to button-display format
    string ButtonMapper(int x, int y)
    {
        switch ((x, y))
        {
            case var t when t.x <= 180 && t.y <= 240:
                button = "button-left";
                break;
            case var t when t.x > 180 && t.x <= 360 && t.y <= 240:
                button = "button-top-left";
                break;
            case var t when t.x > 360 && t.x <= 540 && t.y <= 240:
                button = "button-top";
                break;
            case var t when t.x > 360 && t.y <= 240:
                button = "button-top-right";
                break;
            case var t when t.x > 180 && t.x <= 360 && t.y > 240:
                button = "button-right";
                break;
            case var t when t.x > 360 && t.x <= 540 && t.y > 240:
                button = "button-bot-right";
                break;
            case var t when t.x > 360 && t.y > 240:
                button = "button-bot";
                break;
            default:
                button = "button-bot-left";
                break;
        }
        Debug.Log("BUTTON: " + button);
        return button;
    }
    
    // Parse beatmap file, save [HitObjects] to list of arrays
    List<string[]> ParseSong(string songname)
    {
        string filePath = "Assets/Code/" + songname + ".txt";

        using (StreamReader reader = new StreamReader(filePath))
        {
            hitObjects = new List<string[]>();

            string row;
            bool hitObjectsSection = false;
            while ((row = reader.ReadLine()) != null)
            {
                if (hitObjectsSection)
                {
                    string[] hitObjectArray = row.Split(',');
                    hitObjects.Add(hitObjectArray);
                }
                else if (row.StartsWith("[HitObjects]"))
                {
                    hitObjectsSection = true;
                }
            }
        }

        return hitObjects;
    }
    
    void CacheButtonReferences()
    {
        string[] buttonNames = { "button-left", "button-top-left", "button-top", "button-top-right", 
            "button-right", "button-bot-right", "button-bot", "button-bot-left" };
        foreach (string buttonName in buttonNames)
        {
            buttonTransform = GameObject.Find(buttonName).transform;
            buttonTransforms.Add(buttonName, buttonTransform);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        string songname = "bad_apple";
        hitObjects = ParseSong(songname);
        
        // Format unity components
        buttonTransforms = new Dictionary<string, Transform>();
        CacheButtonReferences(); // Cache references to buttons
        origin = GameObject.Find("origin").transform;
        line = GetComponent<LineRenderer>();
        line.startWidth = 3f;
        line.endWidth = 3f;
        
        // TODO: set tempo & beat duration using .osu file configs
        dur = 50f; // let 50 be the duration of a single beat?
        speed = 70f; // these should correspond to the song's tempo

        startTime = (int)Time.time;
        index = 0;
    }
    
    // Update is called once per frame
    // Read beatmap file, call for the line animation
    void Update()
    {   
        // End condition
        if (index >= hitObjects.Count)
        {
            SceneManager.LoadScene("score-page");
            return;
        }
        
        // Read [HitObject] for location and timing, set animation
        int elapsedTimeMillis = (int)(Time.time) - startTime;
        nextBeat = int.Parse(hitObjects[index][2]);
        
        if (nextBeat < elapsedTimeMillis * 1000)
        {
            index++;
            Debug.Log("index: " + index);
            int x = int.Parse(hitObjects[index][0]); // set button based on x-y position
            int y = int.Parse(hitObjects[index][1]);
            
            destination = buttonTransforms[ButtonMapper(x, y)];
            MakeLine(elapsedTimeMillis);
            
            // TODO: check for user response
            
            // TODO: add other control types
        }
        
    }
}
