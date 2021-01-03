using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Controls;
    public MovePlayer player;
    public Hunger hunger;
    public Thirst thirst;
    public Inventory stockBamboo;
    public Inventory stockWater;
    public CountDays Days;
    public GameObject Bamboo;
    public GameObject Wall;
    public GameObject Water;
    public GameObject Ninja;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
    }

    public void QuitGame()
    {
        SaveSystem.SavePlayer(player, hunger, thirst, stockBamboo, stockWater, Days);
        SaveSystem.SaveBamboo();
        SaveSystem.SaveWall();
        SaveSystem.SaveWater();
        SaveSystem.SaveDay();
        SaveSystem.SaveNinja();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        Bamboo[] bambooData = SaveSystem.LoadBamboo();
        Wall[] wallData = SaveSystem.LoadWall();
        Water[] waterData = SaveSystem.LoadWater();
        Day[] dayData = SaveSystem.LoadDay();
        Ninja[] ninjaData = SaveSystem.LoadNinja();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
        hunger.stockFillAmount = data.hunger;
        thirst.stockFillAmount = data.thirst;
        stockBamboo.stock = data.invBamboo;
        stockWater.stock = data.invWater;
        Days.Days = data.days;
        LoadBamboo(bambooData);
        LoadWall(wallData);
        LoadWater(waterData);
        LoadDay(dayData);
        LoadNinja(ninjaData);
    }

    public void LoadStartGame()
    {
        Vector3 position = new Vector3(0, -2.9f, 0);

        player.transform.position = position;
        hunger.stockFillAmount = 1;
        thirst.stockFillAmount = 1;
        stockBamboo.stock = 0;
        stockWater.stock = 0;
        Instantiate(Bamboo, new Vector3(7, -1.85f, 0), Quaternion.identity);
        Instantiate(Wall, new Vector3(10, -1.8f, 0), Quaternion.identity);
        Instantiate(Wall, new Vector3(-10, -1.8f, 0), Quaternion.identity);
        Instantiate(Water, new Vector3(-6, -4, 0), Quaternion.identity);
    }

    public void LoadBamboo(Bamboo[] bambooData)
    {
        BambooGrow bamboo;

        for (int i = 0; i < bambooData.Length; i++)
        {
            Vector3 v = new Vector3(bambooData[i].position[0], bambooData[i].position[1], bambooData[i].position[2]);
            bamboo = Instantiate(Bamboo, v, Quaternion.identity).GetComponent<BambooGrow>();
            bamboo.stockBamboo = bambooData[i].stockBamboo;
            bamboo.growingTime = bambooData[i].growingTime;
            bamboo.phase = bambooData[i].phase;
            bamboo.divideStock = bambooData[i].divideStock;
            bamboo.tmpStock = bambooData[i].tmpStock;
            bamboo.speed = bambooData[i].speed;
        }
    }

    public void LoadWall(Wall[] wallData)
    {
        WallLife wall;

        for(int i = 0; i < wallData.Length; i++)
        {
            Vector3 v = new Vector3(wallData[i].position[0], wallData[i].position[1], wallData[i].position[2]);
            wall = Instantiate(Wall, v, Quaternion.identity).GetComponent<WallLife>();
            wall.health = wallData[i].wallLife;
        }
    }

    public void LoadWater(Water[] waterData)
    {
        WaterBehaviour water;

        for(int i = 0; i < waterData.Length; i++)
        {
            Vector3 v = new Vector3(waterData[i].position[0], waterData[i].position[1], waterData[i].position[2]);
            water = Instantiate(Water, v, Quaternion.identity).GetComponent<WaterBehaviour>();
            water.stockWater = waterData[i].stockWater;
            water.maxSize = waterData[i].maxSize;
            water.ThisDay = waterData[i].ThisDay;
        }
    }

    public void LoadDay(Day[] dayData)
    {
        DayNightCycle[] day = Resources.FindObjectsOfTypeAll<DayNightCycle>();

        for(int i = 0; i < day.Length; i++)
        {
            day[i].DayTime = dayData[i].DayTime;
            day[i].NightTime = dayData[i].NightTime;
            day[i].StartCycle = dayData[i].StartCycle;
            day[i].alphaLevel = dayData[i].alphaLevel;
            day[i].IsDawn = dayData[i].IsDawn;
            day[i].IsDay = dayData[i].IsDay;
        }
    }

    public void LoadNinja(Ninja[] ninjaData)
    {
        NinjaMove ninja;

        for (int i = 0; i < ninjaData.Length ; i++)
        {
            Vector3 v = new Vector3(ninjaData[i].position[0], ninjaData[i].position[1], ninjaData[i].position[2]);
            ninja = Instantiate(Ninja, v, Quaternion.identity).GetComponent<NinjaMove>();
            ninja.speed = ninjaData[i].speed;
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && Controls.activeInHierarchy == false) {
            if (Pause.activeInHierarchy == false)
                PauseGame();
            else
                RestartGame();
        }
    }
}
