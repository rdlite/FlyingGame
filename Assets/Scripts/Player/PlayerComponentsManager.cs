using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerOnTriggersEvents))]
public class PlayerComponentsManager : MonoBehaviour
{
    private GameConfig _config;

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _playerMovement.MovePlayer(_playerInput.GetInput(), _config.PlayerHorizontalMovementSpeed);
        _playerMovement.ClampPlayerPosition(_config.MinPlayerPositionX, _config.MaxPlayerPositionX);
        _playerMovement.RotatePlayerByMovement(_playerInput.GetInput(), _config.TurningRotationMaxValue, _config.PlayerShipRotationSpeed);

        _playerInput.SetIsBoost();
    }
}