using UnityEngine;
using Zenject;

[RequireComponent(typeof(Camera))]
public class CameraFOVAccreleration : MonoBehaviour
{
    private GameConfig _config;

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    private Camera _camera;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, PlayerInput.IsAcceleration ? _config.AccelerationFOVValue : _config.DefaultFOVValue, .01f);
    }
}
