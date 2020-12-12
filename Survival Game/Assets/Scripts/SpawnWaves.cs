using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    public DayNightCycle DayCycle;
    public GameObject Ninja;
    bool thisNight = false;
    GameObject[] listWalls;
    public CountDays Days;
    int[] walls = new int[2] {0, 0};

    // Start is called before the first frame update
    void Start()
    {
        DayCycle.GetComponent<DayNightCycle>();
        listWalls = GameObject.FindGameObjectsWithTag("Wall");
    }

    // Update is called once per frame
    void Update()
    {
        if (DayCycle.IsDay == true)
        {
            thisNight = false;
        }
        SpawnNinja();
    }

    void SpawnNinja()
    {
        if (DayCycle.IsDay == false && thisNight == false) {
            thisNight = true;
            StartCoroutine(InstantiateNinja());
        }
    }

    IEnumerator InstantiateNinja()
    {
        Vector3[] v;

        FindFarthestWall();
        v = FillVector();
        for(int i = 0; i < Days.Days; i++)
        {
            Instantiate(Ninja, v[0], Quaternion.identity);
            Instantiate(Ninja, v[1], Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }

    void FindFarthestWall()
    {
        for (int i = 0; i < listWalls.Length; i++)
        {
            float distance = listWalls[i].transform.position.magnitude;
            if (distance < walls[0])
            {
                walls[0] = i;
            }
            else if (distance > walls[1])
            {
                walls[1] = i;
            }
        }
    }

    Vector3[] FillVector()
    {
        Vector3[] v = new Vector3[2];

        if (Mathf.Abs(listWalls[0].transform.position.x) > Mathf.Abs(Camera.main.transform.position.x - 10))
        {
            v[0] = new Vector3(listWalls[0].transform.position.x - 10, -3.65f, 0);
        } else
        {
            v[0] = new Vector3(Camera.main.transform.position.x - 15, -3.65f, 0);
        }
        if (Mathf.Abs(listWalls[1].transform.position.x + 10) > Mathf.Abs(Camera.main.transform.position.x + 10))
        {
            v[1] = new Vector3(listWalls[1].transform.position.x + 10, -3.65f, 0);
        } else
        {
            v[1] = new Vector3(Camera.main.transform.position.x + 15, -3.65f, 0);
        }
        return v;
    }
}
