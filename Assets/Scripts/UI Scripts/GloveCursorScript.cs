using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GloveCursorScript : MonoBehaviour
{
    public bool hideCursor;
    public bool hideGloveOnStart;

    private RectTransform _cursorTransform;

    public Image image;
    public GameObject starterButton;
    public bool cursorInCorner = false;

    private Vector2 oldMousePos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        oldMousePos = Mouse.current.position.ReadValue();
        image = GetComponent<Image>();  
        if (hideCursor || cursorInCorner)
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
        if (oldMousePos != Mouse.current.position.ReadValue())
        {
            cursorInCorner = false;
            if (starterButton != null)
            {
                EventSystem.current.SetSelectedGameObject(starterButton);
            }
        }
        Vector3 MousePos = Mouse.current.position.ReadValue();
        _cursorTransform.position = MousePos;
        oldMousePos = Mouse.current.position.ReadValue();

    }

    public void hideGlove()
    {
        image.color = Color.clear;
    }

    public void showGlove()
    {
        image.color = Color.white;
    }

    public void moveCursor()
    {
        Mouse.current.WarpCursorPosition(new Vector2(1920, 1080));
        cursorInCorner = true;
        oldMousePos = Mouse.current.position.ReadValue();

    }
}
