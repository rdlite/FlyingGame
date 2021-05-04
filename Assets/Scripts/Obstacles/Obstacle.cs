using UnityEngine;
using Zenject;

public abstract class Obstacle : MonoBehaviour
{
    protected GameConfig _config;

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    protected ScoreCollecting _scoreCollecting;

    [Inject]
    private void Construct(ScoreCollecting scoreCollecting)
    {
        _scoreCollecting = scoreCollecting;
    }

    private GameOverEvents _gameOverEvents;

    [Inject]
    private void Construct(GameOverEvents gameOverEvents)
    {
        _gameOverEvents = gameOverEvents;
    }

    private bool _isCanMove = true;

    protected virtual void Movement()
    {
        if (_isCanMove)
        {
            float acceleration = PlayerInput.IsAcceleration ? _config.AccelerationMultiplying : 1f;

            transform.position -= new Vector3(0f, 0f, _config.ObstacleMoveSpeed * acceleration * Time.deltaTime);
        }
    }

    protected virtual void Rotation()
    {
        transform.rotation *= Quaternion.Euler(0f, _config.RotationSpeed * Time.deltaTime, 0f);
    }

    public void CountObstacle()
    {
        _scoreCollecting.AsteroidPassed();
    }

    public void DestroyObstacle()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        _gameOverEvents.OnGameEnded += StopMovement;
    }

    private void OnDisable()
    {
        _gameOverEvents.OnGameEnded -= StopMovement;
    }

    private void StopMovement()
    {
        _isCanMove = false;
    }

    public class ObstacleFactory : PlaceholderFactory<Obstacle> { }
}