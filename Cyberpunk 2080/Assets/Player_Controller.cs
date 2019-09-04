using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Controller : MonoBehaviour
{
    public AudioClip death;
    public AudioClip pickup;
    public AudioClip shield;
     AudioSource source;
    private void Update()
    {
        source = GameObject.Find("Video Player").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Block")){
            if (other.gameObject.GetComponent<CubeScript>().type == "Green") { GameManager.GM.points += 1000; Debug.Log("Points");source.PlayOneShot(pickup); }
            if (other.gameObject.GetComponent<CubeScript>().type == "Red") { if (!GameManager.GM.shield) { source.PlayOneShot(death,0.2f); gameObject.SetActive(false); GameManager.GM.Gameover(true); Invoke("Restart",3); GameManager.GM.points = 0; GameManager.GM.shield = false; } else GameManager.GM.shield = false; Debug.Log("dead"); }
            if (other.gameObject.GetComponent<CubeScript>().type == "Blue") { GameManager.GM.shield = true; Debug.Log("SHield"); source.PlayOneShot(shield); }
           
            GameManager.GM.points += 10;
            GameManager.GM.SpawnBuilding();
            Destroy(other.gameObject);
        }
    }
    void Restart()
    {
        GameManager.GM.Gameover(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.GM.transform.rotation = Quaternion.identity;
        gameObject.SetActive(true);
    }
}
