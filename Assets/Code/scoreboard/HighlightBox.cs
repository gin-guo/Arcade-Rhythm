using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighlightBox : MonoBehaviour
{
    public SpriteRenderer backbox;
    public SpriteRenderer leaderboardbox;
    private int currentIndex = 0;
    private List<SpriteRenderer> boxArrayList;
    
    // Start is called before the first frame update
    private void Start()
    {
        boxArrayList = new List<SpriteRenderer>();
        boxArrayList.Add(backbox);
        boxArrayList.Add(leaderboardbox);
    }

    // Update is called once per frame
    private void Update()
    {
        //go to the next box
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentIndex + 1 < boxArrayList.Count)
            {
                currentIndex = currentIndex + 1;
            }
            else
            {
                Debug.Log("No further buttons can be selected on the right, please press left arrow key to go to the previous button");
            }
        }
        
        //go back to the last box
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentIndex - 1 >= 0)
            {
                currentIndex = currentIndex - 1;
            }
            else
            {
                Debug.Log("No further buttons can be selected on the left, please press right arrow key to go to the next button");
            }
        }
        
        //confirm highlight selection
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //back to song selection
            if (currentIndex == 0)
            {
                SceneManager.LoadScene("song_selection");
            }
            
            else if (currentIndex == 1)
            {
                FlashText flashTextInstance = GameObject.Find("Flashing").GetComponent<FlashText>();
            }
        }
        
        Highlight();
    }
    
    private void Highlight()
    {
        
    }
}
