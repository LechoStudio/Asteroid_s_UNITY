using UnityEngine;

public class AsteroidSpawner_CS : MonoBehaviour
{
    public Asteroid_CS asteroidObj;
    public float trajectoryVariance = 15.0f;
    public float spawnRate = 2.0f;
    public float spawnAmmount = 1;
    public float spawnDist = 15.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }
    private void Spawn()
    {
        for (int i = 0; i < spawnAmmount; i++)
        {
            Vector3 SpawnDir = Random.insideUnitCircle.normalized * this.spawnDist;
            Vector3 spawnPoint = this.transform.position + SpawnDir;
            float variance = Random.Range(-trajectoryVariance,trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid_CS asteroid = Instantiate(this.asteroidObj, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -SpawnDir);
        }
    }
}
