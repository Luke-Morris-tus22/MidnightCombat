using UnityEngine;
using UnityEngine.InputSystem;

public class ParallaxScript : MonoBehaviour
{
    private RectTransform _RectTransform;
    public float difference;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("MouseX = " + Mouse.current.position.x.ReadValue());
        //Debug.Log("MouseY = " + Mouse.current.position.y.ReadValue());

        Vector3 MousePos = Mouse.current.position.ReadValue();
        MousePos.x -= Screen.width / 2;
        MousePos.y -= Screen.height / 2;

        //Debug.Log("MouseX = " + MousePos.x);
        //Debug.Log("MouseY = " + MousePos.y);
        MousePos.x *= difference * -0.25f;
        MousePos.y *= difference * -0.25f;

        _RectTransform.anchoredPosition = MousePos;
    }
}
