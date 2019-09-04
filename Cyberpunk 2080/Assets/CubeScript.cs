using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public string type;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) < 3) { type = "Blue";GetComponent<Renderer>().material.color = Color.blue; }
        else if (Random.Range(0, 100) < 10) { type = "Green"; GetComponent<Renderer>().material.color = Color.green; }
        else if (Random.Range(0, 100) < 100) { type = "Red"; GetComponent<Renderer>().material.color = Color.red; }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < 2)
        {
            GameManager.GM.points += 10;
            GameManager.GM.SpawnBuilding();
            Destroy(gameObject);
        }
    }
}
