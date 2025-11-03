using UnityEngine;

public class EventScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public bool BoxColour;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightPunchHit()
    {
        Debug.Log("Right Punch Hit");

        BoxColour = !BoxColour;
        if (BoxColour)
        {
            spriteRenderer.color = Color.red;
        } else {
            spriteRenderer.color = Color.white;
        }
        

    }


}
