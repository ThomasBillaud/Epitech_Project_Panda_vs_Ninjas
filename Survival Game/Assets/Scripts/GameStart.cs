using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameStart : MonoBehaviour
{
    public PauseMenu menu;
    static bool restart = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (menu == null)
            restart = true;
        else
        {
            if (SaveExist() == true && restart == false)
                menu.LoadGame();
            else
            {
                restart = false;
                menu.LoadStartGame();
            }
        }
    }

    bool SaveExist ()
    {
        string[] path = new string[11];

        path[0] = Application.persistentDataPath + "/player.save";
        path[1] = Application.persistentDataPath + "/bamboo.save";
        path[2] = Application.persistentDataPath + "/nb_bamboo.save";
        path[3] = Application.persistentDataPath + "/wall.save";
        path[4] = Application.persistentDataPath + "/nb_wall.save";
        path[5] = Application.persistentDataPath + "/water.save";
        path[6] = Application.persistentDataPath + "/nb_water.save";
        path[7] = Application.persistentDataPath + "/day.save";
        path[8] = Application.persistentDataPath + "/nb_day.save";
        path[9] = Application.persistentDataPath + "/ninja.save";
        path[10] = Application.persistentDataPath + "/nb_ninja.save";

        for(int i = 0; i < path.Length ; i++)
        {
            if (File.Exists(path[i]) == false)
            {
                return false;
            }
        }
        return true;
    }
}
