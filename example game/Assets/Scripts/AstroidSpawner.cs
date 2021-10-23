using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public asteroid asteroidPrefab;
    public float SpawnRate = 2.0f;
    public int spawnAmount = 1;
    public float spawndistance = 15f;
    public float TrajectoryVarience = 15f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), SpawnRate, SpawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized*spawndistance;
            Vector3 spawnPoint =this.transform.position+spawnDirection;

            float varience = Random.Range(-TrajectoryVarience, TrajectoryVarience);

            Quaternion rotation = Quaternion.AngleAxis(varience, Vector3.forward);

            asteroid Asteroid = Instantiate(asteroidPrefab,spawnPoint, rotation);
            Asteroid.size = Random.Range(Asteroid.Minsize, Asteroid.MaxSize);
            Asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
