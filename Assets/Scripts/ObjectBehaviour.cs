using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField]
    float lifeTime = 15f;
    float currentLife;
    [SerializeField]
    int damageValue = -1;
    int scoreValue = 1;

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
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        TouchGround hitGround = other.GetComponent<TouchGround>();
        if (hitGround != null) // if object touches ground outside scorezone, increase score
        {
            hitGround.UpdateScore(scoreValue);
            hitGround.UpdateScoreDisplay();
            Destroy(gameObject);
        }
        ScoreZone hitScoreZone = other.GetComponent<ScoreZone>();
        if (hitScoreZone != null) // if object lands in scorezone, reduce health
        {
            hitScoreZone.UpdateHealth(damageValue);
            hitScoreZone.UpdateHealthDisplay();
            Destroy(gameObject);
        }
    }
}
