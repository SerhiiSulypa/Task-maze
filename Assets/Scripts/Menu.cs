using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public Timer _timer;
    public GameObject _player, _cam;
    private void Start()
    {
        _player.SetActive(false);
        _cam.SetActive(false);
    }
    public void _setDifficulty(int seconds)
    {
        _timer.currentTime = seconds;
        _timer.UpdateTimerText();
        _timer.isRunning = true;

        _player.SetActive(true);
        _cam.SetActive(true);

        Destroy(gameObject);
    }
}
