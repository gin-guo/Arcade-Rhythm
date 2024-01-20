using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public beatScroller theBS;
    public static int currentScore = 0;
    public int scorePerNote = 100;
    //public Text scoreText;
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //scoreText.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");
        currentScore += scorePerNote;
        //scoreText.text = "Score: " + currentScore;
    }
    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }
}
