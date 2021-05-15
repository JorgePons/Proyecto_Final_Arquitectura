using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class HighScoreDBManager : MonoBehaviour
{

    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scorePrefab;
    public Transform rankParent;
    public int topPlayers;
    public Text enterName;

    // Start is called before the first frame update
    void Start()
    {
        //Búsqueda de la ruta donde se guarda el archivo 

        connectionString = "URI=file:" + Application.dataPath + "/RankingDB.sqlite";
        //GetScores();

        ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < 1000; i++)
        //{
        //    DeleteScore(i);
        //}
    }

    //Recibiendo variables string y float para el nombre y la puntuación, esta función inserta una nueva fila en la tabla

    private void InsertScore(string name, float newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("INSERT INTO Ranking(Name,Score) VALUES(\"{0}\",\"{1}\")",name,newScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();


            }

        }
    }


    //Se lee la tabla y se llama a la función que la ordena

    private void GetScores()
    {

        highScores.Clear();

        using(IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using(IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM Ranking";
                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.Log(reader.GetInt32(0) + " - " + reader.GetString(1) + " - " + reader.GetInt32(2));
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    }

                    dbConnection.Close();
                    reader.Close();

                }
            }

        }

        highScores.Sort();

    }


    //Función encargada de borrar filas de la tabla correspondientes a la ID que se introduzca

    private void DeleteScore(int id)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM Ranking WHERE PlayerID =\"{0}\"", id);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();


            }

        }



    }

    //Instancia el top 10 de las puntuaciones además de borrar lo que ya hay en pantalla para evitar que se dupliquen

    private void ShowScores()
    {
        GetScores();

        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Rank"))
        {
            Destroy(score);
        }


        //foreach (GameObject score in gameobj)
        //{

        //}

        for (int i = 0; i < topPlayers; i++)
        {
            GameObject tmpObject = Instantiate(scorePrefab);
            HighScore tmpSCore = highScores[i];
            tmpObject.GetComponent<HighScoreScript>().SetScore(tmpSCore.Name, "#" + (i + 1).ToString(), tmpSCore.Score.ToString());
            tmpObject.transform.SetParent(rankParent);
            tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    //Se introduce el nombre y se le asocia la puntuación del final de la ronda actual

    public void EnterName()
    {
        if (enterName.text != string.Empty)
        {
            float score = ScoreManager.score;
            InsertScore(enterName.text, score);
            enterName.text = string.Empty;
            ShowScores();
        }
    }






}
