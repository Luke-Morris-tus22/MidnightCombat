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

    private bool _healing;
    private float _healingTarget;
    public float healingSpeed;

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
            _whiteHealthbar -= 0.125f;
        }
        if (Health == _whiteHealthbar) {
            _timeSinceDamaged = 0;
                 }

        if (_healing)
        {
            _Animator.SetBool("Healing", true);
            if (Health < _healingTarget)
            {
                Health += healingSpeed * Time.deltaTime;
                _whiteHealthbar = _healingTarget;
            }
            else
            {
                Health = _healingTarget;
                _healing = false;
            }
        }
        else
        {
            _Animator.SetBool("Healing", false);
        }
    }

    public void TakesDamage(float damage)
    {
        _timeSinceDamaged = 0f;
        _Animator.SetTrigger("shake");
        Health = Health - damage;
    }

    public void Heal(float TargetHealth)
    {
        _healing = true;
        _healingTarget = TargetHealth;
    }
}
