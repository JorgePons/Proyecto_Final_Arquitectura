using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{

    //Este script contiene las funciones de victoria y derrota que se pueden llamar desde cualquier otro script
    //Simplemente activa el panel adecuado, pausa el juego y guarda el nuevo récord en caso de que el jugador haya ganado

    public static EndGameScript sharedInstance;

    public GameObject victoryPanel;
    public GameObject scorePanel;
    public GameObject defeatPanel;

    private void Awake()
    {
        sharedInstance = this;
    }

    public void Victory()
    {
        ScoreManager.NewRecord();
        victoryPanel.SetActive(true);
        scorePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Defeat()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
    }



}
