using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_choice : MonoBehaviour
{ 
    public bool competitive = true; //Check if mode is competitive or chill
    public int selecion_frame = 0;
    
    public Sprite sp1, sp2; //Switching sprites for the mode toggle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))//If this button is pressed/condition is met
        {
            GetComponent<SpriteRenderer>().sprite = sp1;//Show the sprite sp1
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<SpriteRenderer>().sprite = sp2; //Show sp2
            competitive = false;//Mode is chill
            // Console.WriteLine("The current mode is: ", competitive);
        }
        
        // if (Input.GetKeyDown(KeyCode.A))//If right button is pushed
        // {
        //     selection_frame++;
        //     
        //     // //Selection frame transfer
        //     // if (selection_frame % 5 == 1)
        //     // {
        //     //     //wants to go back
        //     // }
        //     //
        //     // if (selection_frame % 5 == 1)
        //     // {
        //     //     //in song selection
        //     // }
        //     // if (selection_frame % 5 == 2)
        //     // {
        //     //     //in difficulty selection/mode selection
        //     // }
        //     //
        //     // if (selection_frame % 5 == 4)
        //     // {
        //     //     //Ready for the game and go is pressed
        //     // }
        //
        // if (Input.GetKeyDown(KeyCode.A))//If left button is pushed
        // {
        //     selection_frame--;
        // }
        
    }
}
