using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Points : MonoBehaviour
{
    public AudioSource source;
    public TextMeshProUGUI scroll;
    public TextMeshProUGUI points;
    public TextMeshProUGUI shield;
    private void Update()
    {
        scroll.text="  Currently Playing: "+ source.clip.name;
        points.text = GameManager.GM.points.ToString("0000000");
        if (GameManager.GM.shield) shield.text = "Shield Status: Shield Ready";
        if (!GameManager.GM.shield) shield.text = "Shield Status: Shield Not Ready";
    }
}
