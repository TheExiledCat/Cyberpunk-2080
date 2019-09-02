using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int frames=0;
    public GameObject building;
    public static GameManager GM;
    public float BPM;
    float beatS;
    public float turnSpeed;
    float maxDist=50;
    // Start is called before the first frame update
    void Start()
    {
         
        BPM = 110;
        beatS = BPM / 60 / 2 / 60;
        for (int i = 0; i < 30; i++)
        {

            
             Quaternion rotation; 
            if(i>0)
                rotation =Quaternion.AngleAxis(Mathf.Floor(Random.Range(-361, 0)), -Vector3.forward);
            else rotation =Quaternion.AngleAxis(180, -Vector3.forward);
            Vector3 direction = rotation * Vector3.up;
            Vector3 position = transform.position + (direction * maxDist);
            position.z = i * 200;

            var floor = Instantiate(building, position, rotation, gameObject.transform);
            floor.GetComponent<Rigidbody>().velocity = Vector3.back * 200;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (frames >= 59)
        {
            SpawnBuilding();
            frames = 0;
        }
        frames++;
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
        position.z = 673;

        var floor = Instantiate(building, position, rotation,gameObject.transform);
        floor.GetComponent<Rigidbody>().velocity = Vector3.back * 200; 
    }
}
