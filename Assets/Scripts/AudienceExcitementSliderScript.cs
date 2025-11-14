using UnityEngine;
using UnityEngine.UI;

public class AudienceExcitementSliderScript : MonoBehaviour
{
    public GameObject audienceGO;
    public Slider slider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sliderUpdated()
    {
        audienceGO.GetComponent<AudienceShakeScript>().updateAudienceExcitement(slider.value);
    }
}
