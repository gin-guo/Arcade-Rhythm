using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashText : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789_";
    private int currentIndex = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ConfirmSelection();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CycleNextCharacter();
        }
    }
    
    //loop through each character in the alphabet
    private void CycleNextCharacter()
    {
        //replace _ with 'a'
        char[] charArray = displayText.text.ToCharArray();
        //charArray[currentIndex];
        if (charArray[currentIndex] == '_')
        {
            charArray[currentIndex] = alphabet[0];
            displayText.text = new string(charArray);
        }

        char currentChar = displayText.text[currentIndex];
        int charIndex = alphabet.IndexOf(currentChar);

        if (charIndex != -1)
        {
            charIndex = (charIndex + 1) % alphabet.Length;
            //char[] CharArray = displayText.text.ToCharArray();
            charArray[currentIndex] = alphabet[charIndex];
            displayText.text = new string(charArray);
        }
    }

    private void ConfirmSelection()
    {
        currentIndex = (currentIndex + 1) % displayText.text.Length;
    }
}