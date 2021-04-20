using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode KeytoPresss;
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeytoPresss))
        {
            theSR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(KeytoPresss))
        {
            theSR.sprite = defaultImage;
        }
    }
}
