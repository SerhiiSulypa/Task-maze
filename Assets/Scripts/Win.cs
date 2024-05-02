using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _won;
    public ChangeColors[] _objs;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void _wining(GameObject _restartText)
    { 
        _audioSource.Play();
        _restartText.SetActive(true);
        _won = true;



        foreach (ChangeColors obj in _objs)
        {
            obj._startChange();
        }
    }

    private void Update()
    {
        if (_won)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
