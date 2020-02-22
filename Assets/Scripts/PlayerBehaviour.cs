using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private CinemachineDollyCart _cinemachineDollyCart;
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] private float _speed = 3;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameManager _gameManager;

    private WaitForSeconds _waitForSecondsResetPlayer;
    private CinemachinePath _cinemachinePath;

    private bool _alive = true;

    private void Awake()
    {
        _waitForSecondsResetPlayer = new WaitForSeconds(1);
        _cinemachinePath = (CinemachinePath)_cinemachineDollyCart.m_Path;
    }

    private void Update()
    {
        _cinemachineDollyCart.m_Speed = IsInputDown() ? _speed : 0;
    }

    private static bool IsInputDown()
    {
        return Input.GetMouseButton(0) || Input.touchCount > 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_alive)
        {
            return;
        }
        
        if (other.gameObject.CompareTag("Obstacle"))
        {
            _audioSource.Play();
            
            _gameManager.Lose();
            
            _alive = false;
            
            Camera.main.transform.DOShakePosition(0.1f, 0.5f);
            _rigidbody.AddForce(Vector3.up * 2f, ForceMode.Impulse);
            
            _cinemachineVirtualCamera.enabled = false;
            _cinemachineDollyCart.enabled = false;

            StartCoroutine(RestartPlayer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_alive)
        {
            return;
        }
        
        if (other.gameObject.CompareTag("Goal"))
        {
            _gameManager.Win();
        }
    }

    private IEnumerator RestartPlayer()
    {
        yield return _waitForSecondsResetPlayer;

        transform.position = _cinemachinePath.m_Waypoints[0].position;
        transform.rotation = Quaternion.identity;
        
        _cinemachineDollyCart.m_Position = 0;
        _cinemachineDollyCart.enabled = true;
        _cinemachineVirtualCamera.enabled = true;

        _alive = true;

        yield return null;
    }
}
