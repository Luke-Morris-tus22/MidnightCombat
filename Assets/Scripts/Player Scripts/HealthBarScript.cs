using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider redSlider;
    public Slider whiteSlider;
    private Animator _Animator;

    public float Health;
    private float _whiteHealthbar;
    public float whiteBarDelay;
    private float _timeSinceDamaged;

    public float whiteChangeRate = 10f;

    void Start()
    {
        _Animator = GetComponent<Animator>();
        redSlider.maxValue = Health;
        whiteSlider.maxValue = Health;
        _whiteHealthbar = Health;
    }

    void Update()
    {
        _timeSinceDamaged += Time.deltaTime;
        redSlider.value = Health;
        whiteSlider.value = _whiteHealthbar;
        if(_timeSinceDamaged >= whiteBarDelay && _whiteHealthbar > Health)
        {
            //  updateWhiteBar();
            _whiteHealthbar -= 0.125f;
        }
        // Debug.Log(_timeSinceDamaged);
        if (Health == _whiteHealthbar) {
            _timeSinceDamaged = 0;
                 }
    }

    public void TakesDamage(float damage)
    {
        Debug.Log("takes damage");
        _timeSinceDamaged = 0f;
        _Animator.SetTrigger("shake");
        Health = Health - damage;
    }

    //public void updateWhiteBar()
    //{
    //    Debug.Log(_whiteHealthbar);
    //    Debug.Log(playerHealth);
    //    whiteSlider.value = Mathf.Lerp(_whiteHealthbar, playerHealth, Time.deltaTime * whiteChangeRate);
    //}
}
