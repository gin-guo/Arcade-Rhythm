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
    
    private List<string[]> hitObjects;
    private int index;
    
    private float startTime;
    
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
            while ((row = reader.ReadLine()) != null)
            {
                if (row.StartsWith("[HitObjects]"))
                {
                    string[] hitObjectArray = row.Split(',');
                    hitObjects.Add(hitObjectArray);
                }
            }
        }

        return hitObjects;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        string songname = "bad_apple";
        hitObjects = ParseSong(songname);
        
        // Format line components
        origin = GameObject.Find("origin").transform;;
        line = GetComponent<LineRenderer>();
        line.startWidth = 3f;
        line.endWidth = 3f;
        
        // TODO: set tempo & beat duration using .osu file configs
        dur = 50f; // let 50 be the duration of a single beat?
        speed = 70f; // these should correspond to the song's tempo
        
        // Start time
        startTime = Time.time;
        index = 0;
    }
    
    // Update is called once per frame
    // Read beatmap file, call for the line animation
    void Update()
    {   
        // Read HitObject by location and timing
        int elapsedTimeMillis = (int)((Time.time - startTime) * 1000);
        
        if (index >= hitObjects.Count || hitObjects[index] == null)
        {
            SceneManager.LoadScene("score-page");
            return;
        }

        int nextBeat = int.Parse(hitObjects[index][2]);
        if (nextBeat < elapsedTimeMillis)
        {
            index++;
            
            // set button based on x-y position
            int x = int.Parse(hitObjects[index][0]);
            int y = int.Parse(hitObjects[index][1]);
            
            destination = GameObject.Find(ButtonMapper(x, y)).transform;
            MakeLine(elapsedTimeMillis);
            
            // TODO: check for user response
            
            // TODO: add other control types
        }
        
    }
}
