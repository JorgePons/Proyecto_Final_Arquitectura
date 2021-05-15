using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class SaveStateManager : MonoBehaviour
{

    string json;
    string saveStatePath;

    //Clase que contiene la información del jugador
    public class SaveInfo
    {
        public float[] pos;
        public float hp;
    }

    public SaveInfo saveInfo;

    private void Start()
    {
        //Ruta de guardado
        saveStatePath = Application.dataPath + "/savestateJSON.sav";
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs para llamar a las funciones de guardado y cargado
        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    
    private void Save()
    {
        //Se accede a la ruta de guardado
        StreamWriter sw = new StreamWriter(saveStatePath);
        SaveInfo saveInfo = new SaveInfo();

        //Se guarda la información del estado actual del jugador en las variables de la clase
        saveInfo.pos = new float[] { transform.position.x, transform.position.y, transform.position.z };
        saveInfo.hp = FindObjectOfType<PlayerStats>().hp;

        sw.WriteLine(JsonConvert.SerializeObject(saveInfo));
        sw.Close();
    }

    private void Load()
    {
        //Se accede a la ruta de guardado
        StreamReader sr = new StreamReader(saveStatePath);
        json = sr.ReadLine();
        saveInfo = JsonConvert.DeserializeObject<SaveInfo>(json);

        //Se aplica la información del JSON al jugador en medio de la partida
        transform.position = new Vector3(saveInfo.pos[0], saveInfo.pos[1], saveInfo.pos[2]);
        FindObjectOfType<PlayerStats>().hp = saveInfo.hp;

        sr.Close();

    }




}
