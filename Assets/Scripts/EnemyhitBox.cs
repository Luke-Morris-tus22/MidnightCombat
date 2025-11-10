using UnityEngine;

public class EnemyhitBox : MonoBehaviour
{
    public GameObject hitbox;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitbox.transform.position = new Vector3(0,12,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveHitbox()
    {
        hitbox.transform.position = Vector3.zero;
    }

    public void resetHitbox()
    {
        hitbox.transform.position = new Vector3(0, 12, 0);
    }
}
