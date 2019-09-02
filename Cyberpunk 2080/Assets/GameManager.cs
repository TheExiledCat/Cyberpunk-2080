using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int frames=0;
    public GameObject building;
    public static GameManager GM;
    public float BPM;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        BPM = 80;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames >= 59)
        {
            SpawnBuilding();
            frames = 0;
        }
        transform.Rotate(0, 0,-Input.GetAxis("Horizontal")* turnSpeed);
    }
    private void FixedUpdate()
    {
        
    }
    void SpawnBuilding()
    {

    }
}
