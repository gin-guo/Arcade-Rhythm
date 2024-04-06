using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Script1 : MonoBehaviour
{
    public InputActionAsset actions;
    public TextAsset beatmapFile;
    private string beatmapString;
    private int maxLength;
    public int[,] beats;
    public int t_index = 0;

    public float startTime;
    public AudioSource musicSource;
    public float songTime;

    [Flags] private enum ObjectTypes {
        None = 0,
        Circle = 1,         // bit 0
        Slider = 1 << 1,    // bit 1
        Combo = 1 << 2,     // bit 2
        Spinner = 1 << 3,   // bit 3
        Colour1 = 1 << 4,   // bit 4
        Colour2 = 1 << 5,   // bit 5
        Colour3 = 1 << 6,   // bit 6
        Hold = 1 << 7,      // bit 7
    }

    // Start is called before the first frame update
    void Start()
    {
        actions.FindActionMap("gameplay").FindAction("press").performed += OnPress;

        beatmapString = beatmapFile
.text;
        string[] hitSection = beatmapString.Split("[HitObjects]");
        string[] hitObjectLines = hitSection[1].Split("\n");

        int row = 0;
        maxLength = hitObjectLines.Length - 1;
        beats = new int[maxLength, 5];
        // beats -> [x, y, time, type, endTime]
        // type: 0 (hit circle) or 1 (slider) or 3 (spinner)
        
        // read beats into beat array
        for (int i = 1; i < hitObjectLines.Length; ++i)
        {    
            if (hitObjectLines[i] != "")
            {
                string[] singleObject = hitObjectLines[i].Split(",");
                int ObjectType = int.Parse(singleObject[3]);
                if (((ObjectTypes) ObjectType & ObjectTypes.Circle) != 0)
                {
                    // Debug.Log($"string<{string.Join(",", singleObject)}>string");
                    for (int j = 0; j < 3; ++j)
                    {
                        beats[row, j] = int.Parse(singleObject[j]);
                        Debug.Log($"Row: {row}; Col: {j}; Val: {singleObject[j]}");
                    }
                    beats[row, 3] = 0;
                    beats[row, 4] = 0;
                    row++;
                } else if (((ObjectTypes) ObjectType & ObjectTypes.Slider) != 0) {
                    for (int j = 0; j < 3; ++j)
                    {
                        beats[row, j] = int.Parse(singleObject[j]);
                        Debug.Log($"Row: {row}; Col: {j}; Val: {singleObject[j]}");
                    }
                    beats[row, 3] = 1;
                    beats[row, 4] = -1;
                    row++;
                } else if (((ObjectTypes) ObjectType & ObjectTypes.Spinner) != 0) {
                    for (int j = 0; j < 3; ++j)
                    {
                        beats[row, j] = int.Parse(singleObject[j]);
                        Debug.Log($"Row: {row}; Col: {j}; Val: {singleObject[j]}");
                    }
                    beats[row, 3] = 3;
                    beats[row, 4] = int.Parse(singleObject[5]);
                    row++;
                }
            }
        }

        // write endTime for sliders (currently have a sentinel value of -1)
        int buffer = 100; // buffer in ms between end of slider and start of next beat
        for (int i = 0; i < maxLength; ++i) {
            if (beats[i, 4] == -1) {
                if (beats[i + 1, 2] - beats[i, 2] > buffer) {
                    beats[i, 4] = beats[i + 1, 2] + buffer;
                } else {
                    beats[i, 4] = beats[i + 1, 2];
                }
            }
        }

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
                if (beats[t_index, 3] == 0) {
                    Debug.Log("circle beat");
                    // Color customColor = new Color(0, 1, 0.5f);
                    GetComponent<SpriteRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                    transform.position = new Vector3(beats[t_index, 0] / 100, beats[t_index, 1] / 100);
                }
                t_index++;
            }
        }
    }
    private void OnPress(InputAction.CallbackContext context)
    {
        Debug.Log("Button pressed!");
    }

    void OnEnable()
    {
        actions.FindActionMap("gameplay").Enable();
    }
    void OnDisable()
    {
        actions.FindActionMap("gameplay").Disable();
    }
}
