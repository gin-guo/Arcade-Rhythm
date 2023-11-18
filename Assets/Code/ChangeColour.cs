using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _spriteRenderer.color = Color.white;
        }
    }
}
