using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
{
    public static GameManager GM;
    private void Awake()
    {

        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if (GM != this)
        {
            Destroy(gameObject);
        }
    }
        int frames=0;
    public GameObject block;
    
   public  int points;
    public float turnSpeed;
    float maxDist = 2;
    // Start is called before the first frame update
    void Start()
    {
         
      
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 180;
        if (frames >= 59)
        {
            SpawnBuilding();
            frames = 0;
        }
        frames++;
        float z = transform.rotation.eulerAngles.z - angle;
        while (z < 0)
        {
            z += 360;
        }
        z = Mathf.Repeat(z, 360);
        z -= 180;
        z = Mathf.Clamp(z, -90, 90);
        z += 180;
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, z+angle);
        transform.Rotate(0, 0, Input.GetAxis("Horizontal") * turnSpeed);
        

        
    }
    private void FixedUpdate()
    {
        
    }


    void SpawnBuilding()
    {
        Quaternion rotation = Quaternion.AngleAxis(Mathf.Floor(Random.Range(180,270)), -Vector3.forward);

        Vector3 direction = rotation * Vector3.up;
        Vector3 position = transform.position + (direction * maxDist);
        position.z = 15;

        var floor = Instantiate(block, position, rotation);
        floor.GetComponent<Rigidbody>().velocity = Vector3.back * points;
    }
}
