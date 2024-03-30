using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////////////////////////////////////////*Remmember to create button selection sounds and highlight effects!!*///////////////////////////////////////
//implement user right-left movement script
//Implement song data script

public class mode_choice : MonoBehaviour
{ 
    public bool mode = true; //Check if mode is competitive or chill
    public int selection_frame = 0;
    public int page_num = 1;
    
    
    public Sprite sp1, sp2; //Switching sprites for the mode toggle

    private void Update()//update function that constantly loops
    {
        // if (Input.GetKeyDown(KeyCode.W))//If this button is pressed/condition is met
        // {
        //     GetComponent<SpriteRenderer>().sprite = sp2;//Show the sprite sp1
        // }
        //
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     GetComponent<SpriteRenderer>().sprite = sp1; //Show sp2
        // }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) //If right button is pushed
        {
            selection_frame++;
        }

        action();
            
        //Selection frame transfer
        if (selection_frame % 4 == 0)
        {
            //wants to go back
            page_num--;//goes back to menu page
        }
        
        if (selection_frame % 4 == 1)
        {
            //in song selection
            //detect for up and down keys
        }
        
        if (selection_frame % 4 == 2)
        {
            //in difficulty selection/mode selection
            //detect for up and down
        }
        
        if (selection_frame % 4 == 1)
        {
            //Ready for the game and go is pressed
            page_num++; //goes to game page
        }
//Instead of detecting for key input, detect for variable condition
//Switch case to determine mode and song selection

        
        
        
    }
    private void action()
    {
        //Selection frame transfer
        switch (selection_frame % 4)
        {
            case 0:
                //wants to go back
                page_num--; //goes back to menu page
                break;

            case 1:
                //in song selection
                //scroll bar work
                //create loop function that breaks until user makes song choice, and if select key again loop again
                break;

            case 2:
                //in mode selection
                //create boolean loop function that detects mode
                mode = isCompetitive();

                break; 
            
            case 3:
                //completed song selection process and ready to go (set default settings so if unselected, moves on)
                
                break;
            
        }
    }

    private bool isCompetitive()//function that returns the mode choice according to user's selection
    {
        //
        return true;//default as competitive
    }
    
}
