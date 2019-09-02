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
    float maxDist=50;
    // Start is called before the first frame update
    void Start()
    {
        BPM = 110;
    }

    // Update is called once per frame
    void Update()
    {
        frames++;
        if (frames >= (BPM/60)*2/60)
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
        Quaternion rotation = Quaternion.AngleAxis(Mathf.Floor(Random.Range(-361, 0)),-Vector3.forward);

        Vector3 direction = rotation * Vector3.up;
        Vector3 position = transform.position + (direction * maxDist);
        
        Instantiate(building, position, rotation);
    }
}
