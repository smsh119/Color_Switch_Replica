using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    [SerializeField] GameObject colorCircle;
    [SerializeField] GameObject colorChanger;
    [SerializeField] Transform player;

    [SerializeField] float spawnDistance = 8f;

    float colorChangerposy = 6f;
    float colorCircleposy = 10f;

    private void Update()
    {
        if(player.position.y>colorChangerposy)
        {
            SpawnChangerAndCircle();


        }
    }

    void SpawnChangerAndCircle()
    {
        colorChangerposy += spawnDistance;
        colorCircleposy += spawnDistance;
        Vector3 pos = new Vector3(0f, colorChangerposy, 0f);
        Vector3 rot = new Vector3(0f, 0f, Random.Range(0f, 360f));
        Instantiate(colorChanger, pos, Quaternion.Euler(rot));

        pos = new Vector3(0f, colorCircleposy, 0f);
        rot = new Vector3(0f, 0f, Random.Range(0f, 360f));
        Instantiate(colorCircle, pos, Quaternion.Euler(rot));
    }
}
