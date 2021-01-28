using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    //Aquí están las funciones de cambio de escena a las que se accede mediante botones en la interfaz
    //LoadGame cambia la escala del tiempo a 1 debido a que la pausa del juego al terminar una partida requiere ponerla a 0
    //Se accede a ScoreManager para poner la puntuación actual a 0 al principio de la ronda

    public void LoadGame()
    {
        Time.timeScale = 1;
        ScoreManager.score = 0;
        SceneManager.LoadScene("Level1");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
