using Zenject;
using UnityEngine;
using UnityEngine.UI;

public class UIPanels : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel;
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _endGamePanel;

    [SerializeField] private Text _currentScore, _highestScore, _timer, _asteroidPassedCounter;
    [SerializeField] private Text _result—urrentScore, _resultTimer, _resultAsteroidPassedCounter;

    [SerializeField] private GameObject _isBrokenHighScoreText;

    private LevelStartEvents _levelStartEvents;

    [Inject]
    private void Construct(LevelStartEvents levelStartEvents)
    {
        _levelStartEvents = levelStartEvents;
    }

    public void ShowStartGamePanel()
    {
        _startGamePanel.SetActive(true);
        _inGamePanel.SetActive(false);
        _endGamePanel.SetActive(false);
    }

    public void ShowInGamePanel()
    {
        _startGamePanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _endGamePanel.SetActive(false);
    }

    public void ShowEndGamePanel()
    {
        _startGamePanel.SetActive(false);
        _inGamePanel.SetActive(false);
        _endGamePanel.SetActive(true);
    }

    public void UpdateScore(int currentScore, int highestScore)
    {
        if (_currentScore != null)
        {
            _currentScore.text = currentScore.ToString();
        }

        if (_highestScore != null)
        {
            _highestScore.text = highestScore.ToString();
        }
    }

    public void UpdateAsteroidPassed(int counter)
    {
        if (_asteroidPassedCounter != null)
        {
            _asteroidPassedCounter.text = counter.ToString();
        }
    }

    public void UpdateTimer(float value)
    {
        if (_timer != null)
        {
            _timer.text = value.ToString();
        }
    }

    public void PlayAgainButtonPressed()
    {
        _levelStartEvents.StartNewGame();
    }

    public void SetEndResultValues(float gameTime, int currentScore, int asteroidPassed, bool isShowHighScoreBroken)
    {
        _resultTimer.text = gameTime.ToString();
        _result—urrentScore.text = currentScore.ToString();
        _resultAsteroidPassedCounter.text = asteroidPassed.ToString();

        _isBrokenHighScoreText.SetActive(isShowHighScoreBroken);
    }

    private void Start()
    {
        ShowStartGamePanel();
    }
}
