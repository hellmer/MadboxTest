using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class HelpBehaviour : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _helpText;

    private void Start()
    {
        _helpText.DOFade(0f, 4f).OnComplete(() => gameObject.SetActive(false));
    }
}
