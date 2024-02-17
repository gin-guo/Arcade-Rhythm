using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI obj_text;
    public TMP_InputField display;

    void start()
    {
        display.onEndEdit.AddListener(OnEndEdit);
    }

    // public void Create()
    // {
    //     obj_text.text = display.text;
    // }
    
    private void OnEndEdit(string enteredText)
    {
        if (!string.IsNullOrEmpty(enteredText))
        {
            Debug.Log("User entered: " + enteredText);
            obj_text.text = enteredText;
            display.gameObject.SetActive(false);
        }
    }
}
