using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SpawnPoint is a script on the spawn point that sits above players and handles instantiating weapons and potions.
/// Rates of objects falling and which types of objects fall are set here.
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    public static int level = 0;
    public static float spawnDelay = 2f;
    float lastSpawn;
    GameObject sword, axe, dagger;
    GameObject healingPotion;
    List<GameObject> swordPool, axePool, daggerPool, potionPool;
    List<List<GameObject>> weapons;
    [SerializeField] int poolSize = 20;
    Quaternion weaponRot;

    void Start()
    {
        spawnDelay = 2f;
        sword = (GameObject)Resources.Load("Prefabs/Sword Scale");
        swordPool = CreateObjectPool(sword, poolSize);
        axe = (GameObject)Resources.Load("Prefabs/Axe Wood");
        axePool = CreateObjectPool(axe, poolSize);
        dagger = (GameObject)Resources.Load("Prefabs/Dagger Metal");
        daggerPool = CreateObjectPool(dagger, poolSize);
        healingPotion = (GameObject)Resources.Load("Prefabs/Alchemy Flask Nature");
        potionPool = CreateObjectPool(healingPotion, poolSize);
        weapons = new List<List<GameObject>>
        {
            swordPool, axePool, daggerPool
        };
        lastSpawn = Time.time;
        weaponRot = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180, transform.rotation.w);
    }

    void Update()
    {
        if (Time.time >= lastSpawn)
        {
            SpawnObject();
            lastSpawn = Time.time + spawnDelay;
        }
    }

    List<GameObject> CreateObjectPool(GameObject objectType, int poolSize)
    {
        List<GameObject> pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectType, Vector3.zero, weaponRot);
            obj.SetActive(false);
            pool.Add(obj);
        }
        return pool;
    }

    Vector3 RandomPointOnCircle(Vector3 center, float radius)
    {
        float angle = Random.value * 360f;
        float x = center.x + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = center.z + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, center.y, z);
    }

    GameObject ActivateObject(List<GameObject> pool, Vector3 position)
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].transform.SetPositionAndRotation(position, weaponRot); // reset all details back to default before respawning
                pool[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                pool[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        pool[0].transform.SetPositionAndRotation(position, weaponRot); // if pool is exhausted, respawn first item in pool
        pool[0].GetComponent<Rigidbody>().velocity = Vector3.zero;
        pool[0].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        return pool[0];
    }

    void SpawnObject()
    {
        // Vector3 spawnPos = new Vector3(transform.position.x + Random.value * 1f - 0.5f, transform.position.y, transform.position.z + Random.value * 1f - 0.5f);
        Vector3 spawnPos = RandomPointOnCircle(transform.position, 0.75f);
        float random = Random.value;
        if (random < 0.75f)
        {
            if (level == 0)
            {
                GameObject sword = ActivateObject(swordPool, spawnPos); // only drop swords
                DeactivateAfterTime(sword, sword.GetComponent<ObjectBehaviour>().lifeTime);
            }
            else if (level == 1)
            {
                GameObject weapon = ActivateObject(weapons[Random.Range(0, 2)], spawnPos); // drop swords or axes
                DeactivateAfterTime(weapon, weapon.GetComponent<ObjectBehaviour>().lifeTime);
            }
            else if (level == 2)
            {
                GameObject weapon = ActivateObject(weapons[Random.Range(0, weapons.Count)], spawnPos); // drop any weapon
                DeactivateAfterTime(weapon, weapon.GetComponent<ObjectBehaviour>().lifeTime);
            }
        }
        else if (random < 0.95f && level == 2)
        {
            GameObject weapon = ActivateObject(weapons[Random.Range(0, weapons.Count)], spawnPos); // drop any weapon
            DeactivateAfterTime(weapon, weapon.GetComponent<ObjectBehaviour>().lifeTime);
        }
        else
        {
            GameObject potion = ActivateObject(potionPool, spawnPos); // drop a potion
            DeactivateAfterTime(potion, potion.GetComponent<ObjectBehaviour>().lifeTime);
        }
    }

    IEnumerator DeactivateAfterTime(GameObject obj, float time) // deactivate spawned object after lifetime of object
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
