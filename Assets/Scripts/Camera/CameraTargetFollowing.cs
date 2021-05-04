using UnityEngine;
using Zenject;

public class CameraTargetFollowing : MonoBehaviour
{
    private GameObject _player;
    private GameObject _target;

    [Inject]
    private void Construct(PlayerComponentsManager player)
    {
        _player = player.gameObject;
        _target = _player;
    }

    private LevelStartEvents _levelStartEvents;

    [Inject]
    private void Construct(LevelStartEvents levelStartEvents)
    {
        _levelStartEvents = levelStartEvents;
    }

    public void SetCameraTarget(GameObject target)
    {
        _target = target;
    }

    public void SetCameraPlayerFollowing()
    {
        _target = _player;
    }

    private void Start()
    {
        _levelStartEvents.OnGameStarted += SetCameraPlayerFollowing;
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }

        MoveCamera();
    }

    private void MoveCamera()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, transform.position.z);
    }
}
