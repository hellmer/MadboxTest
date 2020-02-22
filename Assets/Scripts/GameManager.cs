using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _deadText;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private AudioSource _winAudioSource;
    [SerializeField] private string _nextLevel;
    
    private WaitForSeconds _waitForSecond = new WaitForSeconds(1);
    private WaitForSeconds _waitForNextLevel = new WaitForSeconds(3);

    public void Win()
    {
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        _winAudioSource.Play();
        
        _winText.gameObject.SetActive(true);

        yield return _waitForNextLevel;
        
        SceneManager.LoadScene(string.IsNullOrEmpty(_nextLevel) ? "MainScene" : _nextLevel);
    }


    public void Lose()
    {
        StartCoroutine(ShowDeadText());
    }
    
    private IEnumerator ShowDeadText()
    {
        _deadText.gameObject.SetActive(true);

        yield return _waitForSecond;
        
        _deadText.gameObject.SetActive(false);
    }
}
