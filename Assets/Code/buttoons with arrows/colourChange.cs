using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    public SpriteRenderer square;
    public static bool mousePressed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        square = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (noteObject.canBePressed)
        {
            square.color = Color.green;
            GameManager.instance.NoteHit();
        }
        else
        {
            square.color = Color.red;
            GameManager.instance.NoteMissed();
        }
        print("Changed");
        //arrow.ChangeBehavior();
        mousePressed = true;
    }
    
    private void OnMouseUp()
    {
        square.color = Color.white;
    }
}