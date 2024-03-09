using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script1 : MonoBehaviour
{
    public InputActionAsset actions;
    private InputAction moveAction;
    public TextAsset bad_apple;
    private string beatmapString;
    private int maxLength;
    public int[,] beats;
    public int t_index = 0;

    public float startTime;
    public AudioSource musicSource;
    public float songTime;

    // Start is called before the first frame update
    void Start()
    {
        /*
        Color customColor = new Color(1, 1, 0);
        GetComponent<SpriteRenderer>().material.SetColor("_Color", customColor);
        */

        beatmapString = bad_apple.text;
        string[] hitSection = beatmapString.Split("[HitObjects]");
        string[] hitObjectLines = hitSection[1].Split("\n");

        int row = 0;
        maxLength = hitObjectLines.Length - 1;
        beats = new int[maxLength, 6];
        
        for (int i = 1; i < hitObjectLines.Length; ++i)
        {    
            if (hitObjectLines[i] != "")
            {
                string[] singleObject = hitObjectLines[i].Split(",");
                if (singleObject[3] == "1" || singleObject[3] == "5")
                {
                    // Debug.Log($"string<{string.Join(",", singleObject)}>string");
                    for (int j = 0; j < singleObject.Length; ++j)
                    {
                        beats[row, j] = int.Parse(singleObject[j]);
                        // Debug.Log($"Row: {row}; Col: {j}; Val: {singleObject[j]}");
                    }
                    row++;
                }
            }
        }

/*
        foreach (var i in beats)
        {
            Debug.Log(i);
        }

        foreach (var hitObject in hitObjectLines)
        {
            string[] singleObject =  hitObjectLines.Split(,);
            if (singleObject.Length < 6)
            {
                foreach (var value in singleObject)
                {
                    singleObject;
                }
            }
            // Debug.Log(hitObject);
        }
        */

        musicSource = GetComponent<AudioSource>();
        startTime = (float) AudioSettings.dspTime;
        musicSource.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        songTime = (int) (1000 * (float)(AudioSettings.dspTime - startTime));
        // Debug.Log(songTime);
        if (beats[t_index, 2] != 0) {
            if (songTime >= beats[t_index, 2]) {
                Debug.Log("beat");
                // Color customColor = new Color(0, 1, 0.5f);
                GetComponent<SpriteRenderer>().material.SetColor("_Color", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                t_index++;
            }
        }
        
    }
}
