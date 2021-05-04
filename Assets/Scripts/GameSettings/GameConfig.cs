using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig")]
public class GameConfig : ScriptableObject
{
    [Space]
    [Header("Map Settings")]
    public float FloorScrollingSpeed;

    [Space]
    [Header("Player Settings")]
    public float MinPlayerPositionX;
    public float MaxPlayerPositionX;
    public float PlayerHorizontalMovementSpeed;
    public float TurningRotationMaxValue;
    public float PlayerShipRotationSpeed;

    [Space]
    [Header("Global Settings")]
    public float AccelerationMultiplying;

    [Space]
    [Header("Camera Settings")]
    public float DefaultFOVValue;
    public float AccelerationFOVValue;

    [Space]
    [Header("Obstacle Settings")]
    public float ObstacleMoveSpeed;
    public float RotationSpeed;
    public float StartSpawnRate;
    public float MinObstaclePositionX;
    public float MaxObstaclePositionX;

    public GameObject AsteroidPrefab;

    public int ScoreForPassingObstacle;
}
