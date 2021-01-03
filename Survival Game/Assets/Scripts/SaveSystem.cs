using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (MovePlayer player, Hunger hungerValue, Thirst thirstValue, Inventory Bamboo, Inventory Water, CountDays Days)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, hungerValue, thirstValue, Bamboo, Water, Days);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveBamboo ()
    {
        GameObject[] findBamboo = GameObject.FindGameObjectsWithTag("Food");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/bamboo.save";
        string path_nb = Application.persistentDataPath + "/nb_bamboo.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream_nb = new FileStream(path_nb, FileMode.Create);
        int nb_bamboos = findBamboo.Length;
        formatter.Serialize(stream_nb, nb_bamboos);
        BambooGrow[] bamboo = new BambooGrow[nb_bamboos];
        Bamboo[] data = new Bamboo[nb_bamboos];

        for (int i = 0; i < nb_bamboos ; i++)
        {
            bamboo[i] = findBamboo[i].GetComponent<BambooGrow>();
            data[i] = new Bamboo(bamboo[i]);
        }
        formatter.Serialize(stream, data);
        stream.Close();
        stream_nb.Close();
    }

    public static Bamboo[] LoadBamboo ()
    {
        string path = Application.persistentDataPath + "/bamboo.save";
        string path_nb = Application.persistentDataPath + "/nb_bamboo.save";

        if (File.Exists(path) && File.Exists(path_nb))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStream stream_nb = new FileStream(path_nb, FileMode.Open);
            string nbBamboos = formatter.Deserialize(stream_nb) as string;
            int x = 0;
            bool isParsable = Int32.TryParse(nbBamboos, out x);
            Bamboo[] data = new Bamboo[x];

            data = formatter.Deserialize(stream) as Bamboo[];
            stream.Close();
            stream_nb.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveWall ()
    {
        GameObject[] findWall = GameObject.FindGameObjectsWithTag("Wall");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/wall.save";
        string path_nb = Application.persistentDataPath + "/nb_wall.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream_nb = new FileStream(path_nb, FileMode.Create);
        int nb_walls = findWall.Length;
        formatter.Serialize(stream_nb, nb_walls);
        WallLife[] wall = new WallLife[nb_walls];
        Wall[] data = new Wall[nb_walls];

        for (int i = 0; i < nb_walls ; i++)
        {
            wall[i] = findWall[i].GetComponent<WallLife>();
            data[i] = new Wall(wall[i]);
        }
        formatter.Serialize(stream, data);
        stream.Close();
        stream_nb.Close();
    }

    public static Wall[] LoadWall ()
    {
        string path = Application.persistentDataPath + "/wall.save";
        string path_nb = Application.persistentDataPath + "/nb_wall.save";

        if (File.Exists(path) && File.Exists(path_nb))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStream stream_nb = new FileStream(path_nb, FileMode.Open);
            string nbWalls = formatter.Deserialize(stream_nb) as string;
            int x = 0;
            bool isParsable = Int32.TryParse(nbWalls, out x);
            Wall[] data = new Wall[x];

            data = formatter.Deserialize(stream) as Wall[];
            stream.Close();
            stream_nb.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveWater ()
    {
        GameObject[] findWater = GameObject.FindGameObjectsWithTag("Water");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/water.save";
        string path_nb = Application.persistentDataPath + "/nb_water.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream_nb = new FileStream(path_nb, FileMode.Create);
        int nb_water = findWater.Length;
        formatter.Serialize(stream_nb, nb_water);
        WaterBehaviour[] water = new WaterBehaviour[nb_water];
        Water[] data = new Water[nb_water];

        for (int i = 0; i < nb_water ; i++)
        {
            water[i] = findWater[i].GetComponent<WaterBehaviour>();
            data[i] = new Water(water[i]);
        }
        formatter.Serialize(stream, data);
        stream.Close();
        stream_nb.Close();
    }

    public static Water[] LoadWater ()
    {
        string path = Application.persistentDataPath + "/water.save";
        string path_nb = Application.persistentDataPath + "/nb_water.save";

        if (File.Exists(path) && File.Exists(path_nb))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStream stream_nb = new FileStream(path_nb, FileMode.Open);
            string nbWater = formatter.Deserialize(stream_nb) as string;
            int x = 0;
            bool isParsable = Int32.TryParse(nbWater, out x);
            Water[] data = new Water[x];

            data = formatter.Deserialize(stream) as Water[];
            stream.Close();
            stream_nb.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveDay ()
    {
        DayNightCycle[] findDay = Resources.FindObjectsOfTypeAll<DayNightCycle>();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/day.save";
        string path_nb = Application.persistentDataPath + "/nb_day.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream_nb = new FileStream(path_nb, FileMode.Create);
        int nb_day = findDay.Length;
        formatter.Serialize(stream_nb, nb_day);
        DayNightCycle[] day = new DayNightCycle[nb_day];
        Day[] data = new Day[nb_day];

        for (int i = 0; i < nb_day ; i++)
        {
            day[i] = findDay[i].GetComponent<DayNightCycle>();
            data[i] = new Day(day[i]);
        }
        formatter.Serialize(stream, data);
        stream.Close();
        stream_nb.Close();
    }

    public static Day[] LoadDay ()
    {
        string path = Application.persistentDataPath + "/day.save";
        string path_nb = Application.persistentDataPath + "/nb_day.save";

        if (File.Exists(path) && File.Exists(path_nb))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStream stream_nb = new FileStream(path_nb, FileMode.Open);
            string nbDay = formatter.Deserialize(stream_nb) as string;
            int x = 0;
            bool isParsable = Int32.TryParse(nbDay, out x);
            Day[] data = new Day[x];

            data = formatter.Deserialize(stream) as Day[];
            stream.Close();
            stream_nb.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveNinja ()
    {
        GameObject[] findNinja = GameObject.FindGameObjectsWithTag("Enemy");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ninja.save";
        string path_nb = Application.persistentDataPath + "/nb_ninja.save";
        FileStream stream = new FileStream(path, FileMode.Create);
        FileStream stream_nb = new FileStream(path_nb, FileMode.Create);
        int nb_ninja = findNinja.Length;
        formatter.Serialize(stream_nb, nb_ninja);
        NinjaMove[] ninja = new NinjaMove[nb_ninja];
        Ninja[] data = new Ninja[nb_ninja];

        for (int i = 0; i < nb_ninja ; i++)
        {
            ninja[i] = findNinja[i].GetComponent<NinjaMove>();
            data[i] = new Ninja(ninja[i]);
        }
        formatter.Serialize(stream, data);
        stream.Close();
        stream_nb.Close();
    }

    public static Ninja[] LoadNinja ()
    {
        string path = Application.persistentDataPath + "/ninja.save";
        string path_nb = Application.persistentDataPath + "/nb_ninja.save";

        if (File.Exists(path) && File.Exists(path_nb))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            FileStream stream_nb = new FileStream(path_nb, FileMode.Open);
            string nbNinja = formatter.Deserialize(stream_nb) as string;
            int x = 0;
            bool isParsable = Int32.TryParse(nbNinja, out x);
            Ninja[] data = new Ninja[x];

            data = formatter.Deserialize(stream) as Ninja[];
            stream.Close();
            stream_nb.Close();
            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
