using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyButton : MonoBehaviour
{
    private SpriteRenderer btn;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode KeyToPressed;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPressed))
        {
         
            btn.sprite = pressedImage;
            Debug.Log("Pressed");
        }
        if (Input.GetKeyUp(KeyToPressed))
        {
            btn.sprite = defaultImage;
            Debug.Log("Up");
        }
    }
}
