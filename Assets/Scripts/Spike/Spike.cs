using UnityEngine;

public class Spike : MonoBehaviour
{
    //Components Global
    public SpawnSpike spawnSpike;
    void Update()
    {
        if (spawnSpike != null && !GameManager.Instance.GetGameOver())
        {
            transform.Translate(Vector2.left * spawnSpike.GetSpeed() * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NextSpike")) spawnSpike.SpikeSpawn();

        if (collision.CompareTag("FinishSpike"))
        {
            Destroy(gameObject);
            GameManager.Instance.ScoreBySpike();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) GameManager.Instance.GameOver();
    }
}
