using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GloveCursorScript : MonoBehaviour
{
    public bool hideCursor;
    public bool hideGloveOnStart;

    private RectTransform _cursorTransform;

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        image = GetComponent<Image>();  
        if (hideCursor)
        {
            Cursor.visible = false;
        } else
        {
            Cursor.visible = true;
        }

        if (hideGloveOnStart)
        {
            hideGlove();
        }
        else
        {
            showGlove();
        }
        _cursorTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        _cursorTransform.position = MousePos;
    }

    public void hideGlove()
    {
        image.color = Color.clear;
    }

    public void showGlove()
    {
        image.color = Color.white;
    }
}
