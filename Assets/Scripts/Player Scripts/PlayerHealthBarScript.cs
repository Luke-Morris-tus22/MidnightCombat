using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour
{
    public Slider redSlider;
    public Slider whiteSlider;
    private Animator _Animator;

    public float playerHealth;
    private float _whiteHealthbar;
    public float whiteBarDelay;
    private float _timeSinceDamaged;

    public float whiteChangeRate = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Animator = GetComponent<Animator>();
        redSlider.maxValue = playerHealth;
        whiteSlider.maxValue = playerHealth;
        _whiteHealthbar = playerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceDamaged += Time.deltaTime;
        redSlider.value = playerHealth;
        whiteSlider.value = _whiteHealthbar;
        if(_timeSinceDamaged >= whiteBarDelay && _whiteHealthbar > playerHealth)
        {
            //  updateWhiteBar();
            _whiteHealthbar -= 0.125f;
        }
        // Debug.Log(_timeSinceDamaged);
        if (playerHealth == _whiteHealthbar) {
            _timeSinceDamaged = 0;
                 }
    }

    public void PlayerTakesDamage(float damage)
    {
        Debug.Log("player takes damage");
        _timeSinceDamaged = 0f;
        _Animator.SetTrigger("shake");
        playerHealth = playerHealth - damage;
    }

    //public void updateWhiteBar()
    //{
    //    Debug.Log(_whiteHealthbar);
    //    Debug.Log(playerHealth);
    //    whiteSlider.value = Mathf.Lerp(_whiteHealthbar, playerHealth, Time.deltaTime * whiteChangeRate);
    //}
}
