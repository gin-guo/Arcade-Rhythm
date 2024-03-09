//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class FlashText : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789_";
    private int currentIndex = 0;
    private float flashInterval = 0.5f;
    private float flashTimer;
    private bool isFlashing = true;
    private char store = ' ';
    private bool stop = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(!stop)
            HandleFlashing();
        //go to next position
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            char currentChar = displayText.text[currentIndex];
            if (currentChar != ' ')
                stop = true;
        }
        else if (!stop && Input.GetKeyDown(KeyCode.RightArrow))
        {
            ConfirmSelection();
        }
        //go to previous position
        else if (!stop && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GoBackSelection();
        }
        //go to next character
        else if (!stop && Input.GetKeyDown(KeyCode.DownArrow))
        {
            CycleNextCharacter();
        }
        //go to previous character
        else if (!stop && Input.GetKeyDown(KeyCode.UpArrow))
        {
            CycleLastCharacter();
        }
    }
    
    //loop through each character in the alphabet
    private void CycleNextCharacter()
    {
        //replace _ with 'a'
        char[] charArray = displayText.text.ToCharArray();
        char currentChar = displayText.text[currentIndex];
        if (currentChar == ' ')
            currentChar = store;
        int charIndex = alphabet.IndexOf(currentChar);
        if (charIndex != -1)
        {
            charIndex = (charIndex + 1) % alphabet.Length;
            //char[] CharArray = displayText.text.ToCharArray();
            charArray[currentIndex] = alphabet[charIndex];
            displayText.text = new string(charArray);
        }
        
    }

    private void CycleLastCharacter()
    {
        char[] charArray = displayText.text.ToCharArray();
        char currentChar = displayText.text[currentIndex];
        if (currentChar == ' ')
            currentChar = store;
        int charIndex = alphabet.IndexOf(currentChar);

        if (charIndex != -1)
        {
            if (charIndex == 0)
                charIndex = alphabet.Length - 1;
            else
                charIndex = (charIndex - 1) % alphabet.Length;
            //char[] CharArray = displayText.text.ToCharArray();
            charArray[currentIndex] = alphabet[charIndex];
            displayText.text = new string(charArray);
        }
    }

    private void GoBackSelection()
    {
        char[] charArray = displayText.text.ToCharArray();
        char currentCharacter = charArray[currentIndex];
        if (currentCharacter == ' ')
            return;
        // Stop flashing and move to the next character
        isFlashing = false;
        if (currentIndex == 0)
            currentIndex = displayText.text.Length - 1;
        else
            currentIndex = (currentIndex - 1) % displayText.text.Length;
        isFlashing = true;
        flashTimer = 0f;
    }

    private void ConfirmSelection()
    {
        char[] charArray = displayText.text.ToCharArray();
        char currentCharacter = charArray[currentIndex];
        if (currentCharacter == ' ')
            return;
        // Stop flashing and move to the next character
        isFlashing = false;
        currentIndex = (currentIndex + 1) % displayText.text.Length;
        isFlashing = true;
        flashTimer = 0f;
    }
    
    private void HandleFlashing()
    {
        // Check if the current character is selected or flashing during cycling
        if (isFlashing)
        {
            flashTimer += Time.deltaTime;

            // Toggle character visibility based on the flash interval
            if (flashTimer >= flashInterval)
            {
                ToggleCharacterVisibility();
                flashTimer = 0f;
            }
        }
    }

    private void ToggleCharacterVisibility()
    {
        char[] charArray = displayText.text.ToCharArray();
        Debug.Log("current char array : " + charArray);
        
        // Toggle the visibility of the current character
        char currentCharacter = charArray[currentIndex];
        if(currentCharacter != ' ')
            store = currentCharacter;
        for (int i = 0; i < alphabet.Length; i++)
        {
            if (charArray[currentIndex] == alphabet[i])
            {
                //currentCharacter = alphabet[i];
                charArray[currentIndex] = (charArray[currentIndex] == currentCharacter) ? ' ' : currentCharacter;
                displayText.text = new string(charArray);
                return;
            }
        }
        charArray[currentIndex] = (charArray[currentIndex] == ' ') ? store : ' ';
        // Debug.Log("Current Character: " + currentCharacter);
        // charArray[currentIndex] = (charArray[currentIndex] == currentCharacter) ? ' ' : currentCharacter;

        // Update the display text
        displayText.text = new string(charArray);
    }
}