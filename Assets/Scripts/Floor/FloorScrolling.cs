using System.Collections;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(MeshRenderer))]
public class FloorScrolling : MonoBehaviour
{
    private GameConfig _config;

    private IEnumerator _floorMovementCoroutine;

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    private GameOverEvents _gameOverEvents;

    [Inject]
    private void Construct(GameOverEvents gameOverEvents)
    {
        _gameOverEvents = gameOverEvents;
    }

    private LevelStartEvents _levelStartEvents;

    [Inject]
    private void Construct(LevelStartEvents levelStartEvents)
    {
        _levelStartEvents = levelStartEvents;
    }

    private Renderer _planeRenderer;

    private void Start()
    {
        _planeRenderer = GetComponent<MeshRenderer>();

        _floorMovementCoroutine = FloorMovement();

        _levelStartEvents.OnGameStarted += StartMoveFloor;
        _gameOverEvents.OnGameEnded += StopMoveFloor;
    }

    private void StartMoveFloor()
    {
        StartCoroutine(_floorMovementCoroutine);
    }

    private void StopMoveFloor()
    {
        StopCoroutine(_floorMovementCoroutine);
    }

    private IEnumerator FloorMovement()
    {
        while (gameObject.activeSelf)
        {
            SetTextureOffset();

            yield return null;
        }
    }

    private void SetTextureOffset()
    {
        Vector2 textureOffset = new Vector2(0, Time.time * _config.FloorScrollingSpeed * (PlayerInput.IsAcceleration ? _config.AccelerationMultiplying : 1));
        _planeRenderer.material.mainTextureOffset = textureOffset;
    }
}