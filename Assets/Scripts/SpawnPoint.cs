using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int level = 0;
    GameObject sword, axe, dagger;
    GameObject healingPotion;
    List<GameObject> weapons, potions;
    List<string> types;
    float lastSpawn;
    float spawnDelay = 1f;

    void Start()
    {
        sword = (GameObject)Resources.Load("Prefabs/Sword Scale");
        axe = (GameObject)Resources.Load("Prefabs/Axe Wood");
        dagger = (GameObject)Resources.Load("Prefabs/Dagger Metal");
        healingPotion = (GameObject)Resources.Load("Prefabs/Alchemy Flask Nature");
        weapons = new List<GameObject>()
        {
            sword, axe, dagger
        };
        potions = new List<GameObject>()
        {
            healingPotion
        };
        types = new List<string>() // weighted toward weapons
        {
            "weapons", "weapons", "weapons", "potions"
        };
        lastSpawn = Time.time;
    }

    void Update()
    {
        if (Time.time >= lastSpawn)
        {
            SpawnObject(types[Random.Range(0, 4)]);
            lastSpawn = Time.time + spawnDelay;
        }
    }

    public void SpawnObject(string type)
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.value * 2.5f - 1.25f, transform.position.y, transform.position.z + Random.value * 2.5f - 1.25f);
        if (type == "weapons")
        {
            Quaternion weaponRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180, transform.rotation.w);
            if (level == 0)
            {
                Instantiate(weapons[0], spawnPos, weaponRot); // only drop swords
            }
            else if (level == 1)
            {
                Instantiate(weapons[Random.Range(0, 2)], spawnPos, weaponRot); // drop swords or axes
            }
            else if (level == 2)
            {
                Instantiate(weapons[Random.Range(0, 3)], spawnPos, weaponRot); // drop any weapon
            }
        }
        else if (type == "potions")
        {
            Instantiate(potions[Random.Range(0, 1)], spawnPos, transform.rotation);
        }
    }
}
