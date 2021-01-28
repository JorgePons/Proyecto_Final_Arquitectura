using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTextScript : MonoBehaviour
{

    //Accede al componente PlayerStats del jugador para mostrar su HP en un texto

    Text text;
    PlayerStats playerStats;

    private void Start()
    {
        text = GetComponent<Text>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Update()
    {
        text.text = ("HP: " + playerStats.hp);
    }


}
