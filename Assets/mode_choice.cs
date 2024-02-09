using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode_choice : MonoBehaviour
{
    public Sprite sp1, sp2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<SpriteRenderer>().sprite = sp1;
        if (Input.GetKeyDown(KeyCode.D))
            GetComponent<SpriteRenderer>().sprite = sp2;
    }
}
