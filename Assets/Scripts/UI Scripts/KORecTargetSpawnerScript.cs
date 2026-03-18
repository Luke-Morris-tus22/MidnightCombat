using UnityEngine;

public class KORecTargetSpawnerScript : MonoBehaviour
{
    public KORecoveryScript KORecoveryScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnLeft()
    {
        KORecoveryScript.SpawnLeftTarget();
    }

    public void SpawnRight()
    {
        KORecoveryScript.SpawnRightTarget();
    }
}
