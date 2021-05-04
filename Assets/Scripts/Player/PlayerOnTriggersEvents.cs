using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerOnTriggersEvents : MonoBehaviour
{
    private GameOverEvents _gameOverEvents;

    [Inject]
    private void Construct(GameOverEvents gameOverEvents)
    {
        _gameOverEvents = gameOverEvents;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Obstacle>() != null)
        {
            _gameOverEvents.EndGame(other.gameObject);
        }
    }
}
