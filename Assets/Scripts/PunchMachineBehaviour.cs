using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PunchMachineBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _punchTransform;
    [SerializeField] private float _punchInterval;
    [SerializeField] private float _punchDistance;
    
    private Vector3 _punchOriginalPosition;
    private Vector3 _punchEndPosition;
    private WaitForSeconds _waitForSeconds;
    private WaitForSeconds _randomInitTime;
    private Sequence _punchSequence;
    
    private void Awake()
    {
        _punchOriginalPosition = _punchTransform.position;
        _punchEndPosition = new Vector3(_punchOriginalPosition.x + _punchDistance, _punchOriginalPosition.y,
            _punchOriginalPosition.z);
        
        _waitForSeconds = new WaitForSeconds(_punchInterval);
        _randomInitTime = new WaitForSeconds(Random.Range(0f, 5f));

        _punchSequence = DOTween.Sequence();
        _punchSequence.Append(_punchTransform.DOMove(_punchEndPosition, 0.2f))
            .Append(_punchTransform.DOMove(_punchOriginalPosition, 0.5f))
            .SetAutoKill(false)
            .Pause();
    }

    private void Start()
    {
        StartCoroutine(PunchCoroutine());
    }

    private IEnumerator PunchCoroutine()
    {
        yield return _randomInitTime;
        
        while (gameObject.activeInHierarchy)
        {
            _punchSequence.Restart();
            
            yield return _waitForSeconds;
            
            _punchSequence.Play();
        }
    }
}
