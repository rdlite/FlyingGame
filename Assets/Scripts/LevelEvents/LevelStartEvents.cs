using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class LevelStartEvents : MonoBehaviour
{
    [SerializeField] private Transform _playerStartPosition;
    [SerializeField] private GameObject _flyingParticles;
    private GameObject _player;

    private UIPanels _uiPanels;

    [Inject]
    private void Construct(UIPanels uiPanels)
    {
        _uiPanels = uiPanels;
    }

    [Inject]
    private void Construct(PlayerComponentsManager player)
    {
        _player = player.gameObject;
    }

    public event Action OnGameStarted;

    private void Start()
    {
        OnGameStarted += SetPlayerPosition;
        OnGameStarted += SetActivePlayer;
        OnGameStarted += SetActiveFlyingParticlesTrue;

        OnGameStarted += _uiPanels.ShowInGamePanel;

        StartCoroutine(WaitingForAnyKey());
    }

    private IEnumerator WaitingForAnyKey()
    {
        while (!Input.anyKeyDown)
        {
            yield return null;
        }

        StartNewGame();
    }

    public void StartNewGame()
    {
        OnGameStarted.Invoke();
    }

    private void SetActivePlayer() => _player.SetActive(true);

    private void SetPlayerPosition() => _player.transform.position = _playerStartPosition.position;

    private void SetActiveFlyingParticlesTrue() => _flyingParticles.SetActive(true);
}