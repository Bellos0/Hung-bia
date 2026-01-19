using UnityEngine;

public class BeerBottleRespawner : BeerBottle
{
    [SerializeField] GameObject bottle;
    [SerializeField] Transform[] respawnPoint;

    float spawnTime = 3.5f;
    [SerializeField] float timer;
    float respawnDelay = 0.2f;

    protected override void Awake()
    {

        timer = spawnTime;
    }


    private void Start()
    {
        RespawnerBottle(true);
    }

    void Update()
    {
        timer -= Time.deltaTime + respawnDelay;
        if (timer < 0)
        {
            if (logical.count < 10 && logical.beerBreak == false)
            {


                timer = spawnTime;
                RespawnerBottle(true);
            }
            else
                RespawnerBottle(false);

        }
    }

    void RespawnerBottle(bool enable)
    {
        if (enable == true)
        {

            int randomPoint = UnityEngine.Random.Range(0, respawnPoint.Length);
            Vector3 spawnerPoint = respawnPoint[randomPoint].position;
            GameObject newbottle = Instantiate(bottle, spawnerPoint, Quaternion.identity);
        }
        else
            return;

    }
}
