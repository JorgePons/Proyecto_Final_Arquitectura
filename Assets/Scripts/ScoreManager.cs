using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager
{
    
    //A esta clase estática se puede acceder desde cualquier script en cualquier punto del juego
    //Se utiliza para almacenar globalmente la puntuación, sin importar el cambio de escena
    //La función NewRecord se llama cuando el jugador gana una partida, en esta se comprueba si se ha superado el record y se establece en ese csao

    public static float score;
    public static float highScore;

    public static void NewRecord()
    {
        if (score >= highScore)
        {
            highScore = score;
        }
    }

}
