using UnityEngine;
using System.Collections;


public class ButtonColourMapper : MonoBehaviour
{
    public KeyCode key;
    
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(ChangeColorBriefly());
        }
    }
    
    IEnumerator ChangeColorBriefly()
    {
        Color originalColor = spriteRenderer.color;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        spriteRenderer.color = originalColor;
    }
}
