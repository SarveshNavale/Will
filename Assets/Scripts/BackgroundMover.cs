using UnityEngine;

public class BackgroundMover : MonoBehaviour
{

    public GameSpeedData speedData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(speedData.PlayerSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
