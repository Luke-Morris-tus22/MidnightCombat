using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class AudienceShakeScript : MonoBehaviour
{
    public float shakeSpeed = 1;
    public float shakeAmplittude = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, Random.insideUnitCircle * shakeAmplittude, shakeSpeed * Time.deltaTime);
    }
}
