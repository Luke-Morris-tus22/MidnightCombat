using Unity.VisualScripting;
using UnityEngine;

public class KORecTargetScript : MonoBehaviour
{
    public float speed = 100;
    RectTransform rectTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y - (speed * Time.deltaTime), rectTransform.position.z);
        if (rectTransform.position.y < -520)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KORecHit"))
        {
            float distance = Mathf.Abs(collision.GetComponent<RectTransform>().position.y - rectTransform.position.y);
            if (distance <= 15)
            {
                Debug.Log("Perfect");
            }
            else if (distance <= 30)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("Bad");
            }
            Destroy(gameObject);
        }
    }
}
