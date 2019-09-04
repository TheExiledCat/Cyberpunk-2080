using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager :MonoBehaviour
{
    public GameObject GO;
    public GameObject shieldBody;
    public float maxSpeed;
    float speed =10;
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
        SpawnBuilding();
    }
        int frames=0;
    public GameObject block;
    public bool shield = false;
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
        if (frames >= 179)
        {
            frames = 0;
            if(maxSpeed<25)
            maxSpeed += 1;

        }
        frames++;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            shield = false;
            points = 0;
        }
        if (shield)
        {
            shieldBody.SetActive(true);
        }else
        {
            shieldBody.SetActive(false);
        }
        float angle = 180;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Cursor.visible = false;
        }
        else
            Cursor.visible = true;

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

    public void Gameover(bool value)
    {
        GO.SetActive(value);
    }
    public void SpawnBuilding()
    {
        Quaternion rotation = Quaternion.AngleAxis(Mathf.Floor(Random.Range(180,270)), -Vector3.forward);

        Vector3 direction = rotation * Vector3.up;
        Vector3 position = transform.position + (direction * maxDist);
        position.z = 20;
       
        
        var floor = Instantiate(block, position, rotation);
       // var decay = points * 0.5f;
        //if (decay > maxSpeed) decay = maxSpeed;
        floor.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-maxSpeed-10);// decay;
    }
}
