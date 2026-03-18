using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
    public Transform playerTransform;
    public float cameraSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.x != transform.position.x)
        {

        }
    }
}
