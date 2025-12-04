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
        Vector3 MousePos = Mouse.current.position.ReadValue();
        _RectTransform.position = MousePos*difference;
    }
}
