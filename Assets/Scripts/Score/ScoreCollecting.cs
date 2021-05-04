using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class ScoreCollecting : MonoBehaviour
{
    private UIPanels _uiPanels;
    private LevelStartEvents _levelStartEvents;
    private ScoreData _scoreData;
    private GameConfig _config;
    private GameOverEvents _gameOverEvents;

    private IEnumerator _countingÑoroutine, _uiTimerCountigh;

    private int _asteroidPassed;

    private float _totalPlayed;

    private bool _isGamePlaying;

    [Inject]
    private void Construct(UIPanels uiPanels)
    {
        _uiPanels = uiPanels;
    }

    [Inject]
    private void Construct(LevelStartEvents levelStartEvents)
    {
        _levelStartEvents = levelStartEvents;
    }

    [Inject]
    private void Construct(ScoreData scoreData)
    {
        _scoreData = scoreData;
    }

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    [Inject]
    private void Construct(GameOverEvents gameOverEvents)
    {
        _gameOverEvents = gameOverEvents;
    }

    private void Start()
    {
        _levelStartEvents.OnGameStarted += StarScoreCounter;
        _levelStartEvents.OnGameStarted += NulifyStartScore;
        _levelStartEvents.OnGameStarted += UpdateUIScore;
        _levelStartEvents.OnGameStarted += StartUITimer;
        _levelStartEvents.OnGameStarted += SetIsGamePlayingTrue;

        _gameOverEvents.OnGameEnded += StopCoroutines;
        _gameOverEvents.OnGameEnded += ShowEndResultInUI;
        _gameOverEvents.OnGameEnded += SetIsGamePlayingFalse;
    }

    private void SetIsGamePlayingTrue()
    {
        _isGamePlaying = true;
    }

    private void SetIsGamePlayingFalse()
    {
        _isGamePlaying = false;
    }

    private void StarScoreCounter()
    {
        _countingÑoroutine = ScoreCounting();
        StartCoroutine(_countingÑoroutine);
    }

    private void StartUITimer()
    {
        _uiTimerCountigh = UITimerCounting();
        StartCoroutine(_uiTimerCountigh);
    }

    private void StopCoroutines()
    {
        StopCoroutine(_countingÑoroutine);
        StopCoroutine(_uiTimerCountigh);
    }

    private IEnumerator ScoreCounting()
    {
        float timer = 0f;

        while (gameObject.activeSelf)
        {
            timer += Time.deltaTime;

            if (timer >= 1f)
            {
                timer = 0;
                AddScore(PlayerInput.IsAcceleration ? (int)_config.AccelerationMultiplying : 1);
            }

            yield return null;
        }
    }

    private IEnumerator UITimerCounting()
    {
        _totalPlayed = 0f;

        while (gameObject.activeSelf)
        {
            _totalPlayed += Time.deltaTime;

            _uiPanels.UpdateTimer((float)Math.Round(_totalPlayed, 1));

            yield return null;
        }
    }

    public void AddScore(int value)
    {
        _scoreData.CurrentScore += value;

        if (_scoreData.CurrentScore > _scoreData.HighestScore)
        {
            _scoreData.HighestScore = _scoreData.CurrentScore;
        }

        UpdateUIScore();
    }

    public void AsteroidPassed()
    {
        if (_isGamePlaying)
        {
            AddScore(_config.ScoreForPassingObstacle);

            _uiPanels.UpdateAsteroidPassed(++_asteroidPassed);
        }
    }

    private void ShowEndResultInUI()
    {
        _uiPanels.SetEndResultValues((float)Math.Round(_totalPlayed, 1), _scoreData.CurrentScore, _asteroidPassed, _scoreData.CurrentScore == _scoreData.HighestScore);
        _uiPanels.ShowEndGamePanel();

        _asteroidPassed = 0;
        _uiPanels.UpdateAsteroidPassed(0);
    }

    private void NulifyStartScore()
    {
        _scoreData.NulifyStartScore();
    }

    private void UpdateUIScore()
    {
        _uiPanels.UpdateScore(_scoreData.CurrentScore, _scoreData.HighestScore);
    }
}