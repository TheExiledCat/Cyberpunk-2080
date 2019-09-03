using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Controller : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block")){
            if (other.gameObject.GetComponent<CubeScript>().type == "Green") { GameManager.GM.points += 1000; Debug.Log("Points"); }
            if (other.gameObject.GetComponent<CubeScript>().type == "Red") { if (!GameManager.GM.shield) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); else GameManager.GM.shield = false; Debug.Log("dead"); }
            if (other.gameObject.GetComponent<CubeScript>().type == "Blue") { GameManager.GM.shield = true; Debug.Log("SHield"); }
        }
    }
}
