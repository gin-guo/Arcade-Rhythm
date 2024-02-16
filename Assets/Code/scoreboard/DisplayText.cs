using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    public TextMeshProUGUI obj_text;
    public TMP_InputField display;

    void start()
    {
       
    }

    public void Create()
    {
        obj_text.text = display.text;
    }
}
