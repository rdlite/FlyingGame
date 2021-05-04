using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GameOverEvents : MonoBehaviour
{
    [SerializeField] private CameraTargetFollowing _cameraFollow;
    [SerializeField] private GameObject _flyingParticles;

    private GameObject _player;

    [Inject]
    private void Construct(PlayerComponentsManager player)
    {
        _player = player.gameObject;
    }
    
    private UIPanels _uiPanels;

    [Inject]
    private void Construct(UIPanels uiPanels)
    {
        _uiPanels = uiPanels;
    }

    public event Action OnGameEnded;

    public void EndGame(GameObject crushedAsteroid)
    {
        _flyingParticles.SetActive(false);
        _player.SetActive(false);

        _cameraFollow.SetCameraTarget(crushedAsteroid);

        OnGameEnded.Invoke();
    }
}