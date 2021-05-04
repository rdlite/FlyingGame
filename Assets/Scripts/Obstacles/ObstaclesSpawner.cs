using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObstaclesSpawner : MonoBehaviour
{
    private Obstacle.ObstacleFactory _obstacleFactory;
    private GameConfig _config;
    private LevelStartEvents _levelStartEvents;
    private GameOverEvents _gameOverEvents;

    private List<GameObject> _spawnedObstacles = new List<GameObject>();

    [Inject]
    private void Construct(Obstacle.ObstacleFactory factory)
    {
        _obstacleFactory = factory;
    }

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    [Inject]
    private void Construct(LevelStartEvents levelStartEvents)
    {
        _levelStartEvents = levelStartEvents;
    }

    [Inject]
    private void Construct(GameOverEvents gameOverEvents)
    {
        _gameOverEvents = gameOverEvents;
    }

    [SerializeField] private Transform _startYPoint, _endYPoint;

    private void Start()
    {
        _levelStartEvents.OnGameStarted += StartSpawnObstacles;
        _levelStartEvents.OnGameStarted += ClearObstacles;

        _gameOverEvents.OnGameEnded += StopSpawnObstacles;
    }

    public void StartSpawnObstacles()
    {
        StartCoroutine(ObstacleSpawning());
    }

    public void StopSpawnObstacles()
    {
        StopAllCoroutines();
    }

    private IEnumerator ObstacleSpawning()
    {
        float t = 0f;

        while (gameObject.activeSelf)
        {
            t += Time.deltaTime;

            if (t > _config.StartSpawnRate)
            {
                t = 0f;

                SpawnObstacle(Random.Range(_config.MinObstaclePositionX, _config.MaxObstaclePositionX));
            }

            yield return null;
        }
    }

    private void ClearObstacles()
    {
        foreach (GameObject item in _spawnedObstacles)
        {
            if (item != null)
            {
                Destroy(item);
            }
        }

        _spawnedObstacles.Clear();
    }

    private void SpawnObstacle(float xPosition)
    {
        GameObject newObstacle = _obstacleFactory.Create().gameObject;
        newObstacle.transform.position = new Vector3(xPosition, _startYPoint.position.y, _startYPoint.position.z);

        _spawnedObstacles.Add(newObstacle);
    }
}