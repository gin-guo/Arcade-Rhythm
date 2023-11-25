using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    public SpriteRenderer square;
    //public beatScroller arrow;
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
        square.color = Random.ColorHSV();
        print("Changed");
        //arrow.ChangeBehavior();
        mousePressed = true;
    }
}