using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colourChange : MonoBehaviour
{
    //public SpriteRenderer _spriteRenderer;
    public static bool mousePressed = false;

    private Material _spriteMaterial;
    private Color objectColor;

    void Start()
    {
        _spriteMaterial = GetComponent<Renderer>().material;
        objectColor = _spriteMaterial.color;
    }

    void Update()
    {
        // Example hexadecimal color value (replace with your desired color)
        string hexadecimalColor = "#F1C658";

        // Convert the hexadecimal color string to a Color object
        Color newColor = HexToColor(hexadecimalColor);

        // Change the color when the 'A' key is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
			if (_spriteMaterial.color != newColor)
			{
				_spriteMaterial.color = newColor;
			}

            else if (_spriteMaterial.color == newColor)
			{
				_spriteMaterial.color = objectColor;
			}
        }
	}

	private Color HexToColor(string hex)
    {
        Color color = Color.clear;
        if (ColorUtility.TryParseHtmlString(hex, out color))
        {
            return color;
        }
        return Color.clear;
    }

    /*private void OnMouseDown()
    {
        if (noteObject.canBePressed)
        {
            _spriteRenderer.color = Color.green;
            GameManager.instance.NoteHit();
        }
        else
        {
            _spriteRenderer.color = Color.red;
            GameManager.instance.NoteMissed();
        }
        print("Changed");
        //arrow.ChangeBehavior();
        mousePressed = true;
    }
    
    private void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
    }*/

}