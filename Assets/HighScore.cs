using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;
using System;

class HighScore : IComparable<HighScore>
{

    //Esta clase almacena las caracter�sticas de cada rank para ser le�das por el manager 

    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }

    public HighScore(int id, string name, int score)
    {
        this.Score = score;
        this.Name = name;
        this.ID = id;
    }

    //Esta funci�n ordena las puntuaciones bas�ndose en la puntuaci�n

    public int CompareTo(HighScore other)
    {
        if (other.Score < this.Score)
        {
            return -1;
        }
        if (other.Score > this.Score)
        {
            return 1;
        }
        return 0;
    }
}
