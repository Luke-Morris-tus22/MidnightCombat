using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class AudienceShakeScript : MonoBehaviour
{
    public float shakeSpeed = 1;
    public float shakeAmplittude = 0.5f;
    public Vector2 Offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 tempPos = transform.position;
        transform.position = Vector2.Lerp((tempPos+Offset), ((Random.insideUnitCircle * shakeAmplittude)+Offset), shakeSpeed * Time.deltaTime);
        Debug.Log(transform.position);
    }
}
