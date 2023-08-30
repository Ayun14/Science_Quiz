using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int quizCount = 0;

    [SerializeField] private TextMeshProUGUI quizText = null;

    [SerializeField] private GameObject startPanel = null;
    [SerializeField] private GameObject introducePanel = null;

    [SerializeField] private GameObject oImage;
    [SerializeField] private GameObject xImage;

    private void Start()
    {
        oImage.SetActive(false);
        xImage.SetActive(false);

        introducePanel.SetActive(false);
        startPanel.SetActive(true);

        quizCount = 0;
    }

    public void StartButtonClick()
    {
        oImage.SetActive(true);
        xImage.SetActive(true);

        introducePanel.SetActive(false);
    }

    public void IntroduceButtonClick()
    {
        introducePanel.SetActive(true);
        startPanel.SetActive(false);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    IEnumerator StageChange()
    {
        yield return null;
    }
}
