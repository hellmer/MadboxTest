using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 originalScale = transform.localScale;

        _title.transform.DOScale(originalScale * 0.9f, 1f).SetLoops(-1, LoopType.Yoyo);
    }


    public void PlayGameButtonPressed()
    {
        SceneManager.LoadScene("Level1");
    }
}
