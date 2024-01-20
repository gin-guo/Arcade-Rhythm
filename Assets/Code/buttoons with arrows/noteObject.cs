using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{
    public static bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colourChange.mousePressed)
        {
            gameObject.SetActive(false);
        }
        
        //only the most recent arrow will be set to false
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
