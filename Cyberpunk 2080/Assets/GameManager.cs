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
         
       
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 180;
        float z = transform.rotation.eulerAngles.z - angle;
        while (z < 0) z += 360;
        z = Mathf.Repeat(z, 360);
        if (frames >= 59)
        {

            frames = 0;
        }
        frames++;
        z -= 180;
        z = Mathf.Clamp(z, -90, 90);
        z += 180;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, z + angle);

        transform.Rotate(0, 0,Input.GetAxis("Horizontal")* turnSpeed);
    }
    private void FixedUpdate()
    {
        
    }
    //void SpawnBuilding()
    //{
    //    Quaternion rotation = Quaternion.AngleAxis(Mathf.Floor(Random.Range(-361, 0)),-Vector3.forward);

    //    Vector3 direction = rotation * Vector3.up;
    //    Vector3 position = transform.position + (direction * maxDist);
    //    position.z = 673;

    //    var floor = Instantiate(building, position, rotation,gameObject.transform);
    //    floor.GetComponent<Rigidbody>().velocity = Vector3.back * 200; 
    //}
}
