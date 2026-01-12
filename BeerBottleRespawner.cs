using UnityEngine;

public class BeerBottleRespawner : BeerBottle
{
    [SerializeField] GameObject bottle;
    [SerializeField] Transform[] respawnPoint;

    float spawnTime = 5f;
   [SerializeField] float timer;
    float respawnDelay = 0.2f;

    private void Awake()
    {
        timer = spawnTime;
    }

    void Update()
    {
        timer -= Time.deltaTime +respawnDelay;
        if (timer < 0)
        {
            if (serviceBottle.CountValue() < 5)
            {

            timer = spawnTime;
            RespawnerBottle();
            }
        }
    }

    private void RespawnerBottle()
    {
        //throw new NotImplementedException();
        int randomPoint = UnityEngine.Random.Range(0, respawnPoint.Length);
        Vector3 spawnerPoint = respawnPoint[randomPoint].position;
        GameObject newbottle = Instantiate(bottle, spawnerPoint, Quaternion.identity);
    }
}
