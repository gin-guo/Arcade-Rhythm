using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObjec : MonoBehaviour
{
    public bool canBePressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colourChange.mousePressed)
        {
            // if (canBePressed)
            // {
            //     gameObject.SetActive(false);
            // }
            gameObject.SetActive(false);
        }
        
        //if touches edges of square, also false
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
