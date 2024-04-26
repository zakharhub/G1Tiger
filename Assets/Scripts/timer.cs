using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private float time = 10f;
    [SerializeField] private Text timerText;
    [SerializeField] private int sceneIndexToLoad = 0;
    private float _timeLeft = 0f;
    private bool _isPaused = false;

    private IEnumerator StartTimer()
    {
        while (_timeLeft >= 0)
        {
            if (!_isPaused)
            {
                _timeLeft -= Time.deltaTime;
                if (_timeLeft <= 0)
                {
                    _timeLeft = 0;
                    UpdateTimeText();
                    SceneChange();
                    break;
                }
                UpdateTimeText();
            }
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        int seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00}", seconds);
    }

    private void SceneChange()
    {
        SceneManager.LoadScene(sceneIndexToLoad);
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
    }

    public void SetSceneIndex(int newIndex)
    {
        sceneIndexToLoad = newIndex;
    }
}
