using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpawnPoint is a script on the spawn point that sits above players and handles instantiating weapons and potions.
/// Rates of objects falling and which types of objects fall are set here.
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    public static int level = 0;
    GameObject sword, axe, dagger;
    GameObject healingPotion;
    List<GameObject> weapons, potions;
    float lastSpawn;
    public static float spawnDelay;

    void Start()
    {
        spawnDelay = 2f;
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
        lastSpawn = Time.time;
    }

    void Update()
    {
        if (Time.time >= lastSpawn)
        {
            SpawnObject();
            lastSpawn = Time.time + spawnDelay;            
        }
    }

    public void SpawnObject()
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.value * 1f - 0.5f, transform.position.y, transform.position.z + Random.value * 1f - 0.5f);
        Quaternion weaponRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180, transform.rotation.w);
        float random = Random.value;
        if (random < 0.75f)
        {
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
        else if (random < 0.95f && level == 2)
        {
            Instantiate(weapons[Random.Range(0, 3)], spawnPos, weaponRot); // drop any weapon
        }
        else
        {
            Instantiate(potions[0], spawnPos, transform.rotation);
        }
    }
}
