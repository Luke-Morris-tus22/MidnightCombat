using UnityEngine;
using UnityEngine.InputSystem;

public class GloveCursorScript : MonoBehaviour
{
    public bool hideCursor;

    private RectTransform _cursorTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (hideCursor)
        {
            Cursor.visible = false;
        } else
        {
            Cursor.visible = true;
        }
        _cursorTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Mouse.current.position.ReadValue();
        _cursorTransform.position = MousePos;
    }
}
