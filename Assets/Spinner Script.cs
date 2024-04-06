using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpinnerScript : MonoBehaviour
{
    public Script1 referenceScript;
    public int[,] beats;
    public float songTime;
    public int t_index = 0;
    // Start is called before the first frame update
    void Start()
    {   
        referenceScript = GetComponent<Script1>();
        beats = referenceScript.beats;
        songTime = referenceScript.songTime;
        t_index = referenceScript.t_index;
    }

    // Update is called once per frame
    void Update()
    {
        if (beats[t_index, 2] != 0 && songTime >= beats[t_index, 2]) {
            if (beats[t_index, 3] == 3 && songTime < beats[t_index, 4]) {
                Debug.Log("spinner beat");
                // Color customColor = new Color(0, 1, 0.5f);
                GetComponent<SpriteRenderer>().material.SetColor("_Color", UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));
                transform.position = new Vector3(beats[t_index, 0] / 100, beats[t_index, 1] / 100);
                transform.Rotate(0, 0, 5);
            }
            t_index++;
        }
    }
}
