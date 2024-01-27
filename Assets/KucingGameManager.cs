using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KucingGameManager : MonoBehaviour
{
    public static KucingGameManager instance;

    public int taiCounter;
    private int taiStartCount;

    public float timer;
    private float timerStart;

    public TextMeshProUGUI timerText;

    public GameObject restartPanel;
    public GameObject winPanel;

    [SerializeField] private CanvasGroup transition;


    private void Start()
    {
        instance = this;
        StartAnimation();
    }

    private void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;

            timerText.SetText(timer.ToString("F1"));
        }

        if(timer <= 0)
        {
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void AddTai()
    {
        taiCounter++;
        if(taiCounter >= 3)
        {
            Debug.Log("GameOver");
            restartPanel.SetActive(true);

            Time.timeScale = 0f;


        }
    }

    public void RestartButtonClicked()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void FinishButtonClicked()
    {
        SceneManager.LoadScene("OpenWorld");
        GlobalGameManager.Instance.KucingClearBerak();
    }

    public void StartAnimation()
    {
        transition.DOFade(0f, 0.5f)
                    .From(1f)
                    .SetEase(Ease.OutSine);
    }
}
