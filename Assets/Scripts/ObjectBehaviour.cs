using System;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 15f;
    float currentLife;
    [SerializeField]
    int damageValue = -1;

    private void Start()
    {
        currentLife = Time.time;
    }

    private void Update()
    {
        if (Time.time >= currentLife + lifeTime)
        {
            Destroy(gameObject);
        }        
        if (transform.position.y < -1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TouchGround hitGround = other.GetComponent<TouchGround>();
        if (hitGround != null)
        {
            Destroy(gameObject);
        }
        ScoreZone hitScoreZone = other.GetComponent<ScoreZone>();
        if (hitScoreZone != null)
        {
            hitScoreZone.UpdateScore(damageValue);
            Destroy(gameObject);
            Debug.Log(hitScoreZone.score);
        }
    }
}
