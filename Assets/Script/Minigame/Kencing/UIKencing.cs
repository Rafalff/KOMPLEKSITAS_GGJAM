using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class UIKencing : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject battlePanel;

    [SerializeField] private GameObject buttonFinish;
    [SerializeField] private GameObject buttonRestart;

    [SerializeField] private TextMeshProUGUI delayBeforeStartText;
    [SerializeField] private Slider kencingTimerSlider;
    [SerializeField] private TextMeshProUGUI kencingTimerText;
    [SerializeField] private RectTransform tutorialText;

    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private CanvasGroup transition;
    private float startSliderTime;

    private bool isDelayActive = false;

    private void Awake()
    {
        KencingManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void Start()
    {
        startSliderTime = KencingManager.instance.kencingTimer;
        StartAnimation();
    }



    private void OnDestroy()
    {
        KencingManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void Update()
    {
        if (isDelayActive == true && KencingManager.instance.delayBeforeStart >= 0) {
            KencingManager.instance.delayBeforeStart -= Time.deltaTime;
            delayBeforeStartText.SetText(KencingManager.instance.delayBeforeStart.ToString("F1"));
        }
        
        if(KencingManager.instance.delayBeforeStart <= 0 && KencingManager.instance.kencingTimer >= 0)
        {
            KencingManager.instance.kencingTimer -= Time.deltaTime;
            UpdateSliderUI();
            delayBeforeStartText.gameObject.SetActive(false);

            if(KencingManager.instance.kencingTimer <= 0)
            {
                ChangeStateToGameover();
            }
        }
    }

    void UpdateSliderUI()
    {
        kencingTimerSlider.value = KencingManager.instance.kencingTimer / startSliderTime;
        kencingTimerText.text = KencingManager.instance.kencingTimer.ToString("F1"); // Format to one decimal place
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        startButton.SetActive(state == GameState.WAIT);

        //battlePanel.SetActive(state == GameState.GAMEPLAY);

        restartPanel.SetActive(state == GameState.GAMEOVER);

        if (KencingManager.instance.targetDoneCount >= KencingManager.instance.maxTarget)
        {
            buttonFinish.SetActive(true);
            buttonRestart.SetActive(false);

            panelWin.DOFade(1f, 1f)
                    .From(0f)
                    .SetEase(Ease.OutSine);
        }

    }

    public void StartButtonClicked()
    {
        isDelayActive = true;
        delayBeforeStartText.gameObject.SetActive(true);
        Invoke(nameof(ChangeStateToGameplay), KencingManager.instance.delayBeforeStart);
    }
    public void ChangeStateToGameplay()
    {
        KencingManager.instance.UpdateGameState(GameState.GAMEPLAY);
    }

    public void ChangeStateToGameover()
    {
        KencingManager.instance.UpdateGameState(GameState.GAMEOVER);
    }

    public void RestartButtonClicked()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void FinishQuest()
    {
        GlobalGameManager.Instance.ClearSayur();
    }

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void StartAnimation()
    {
        RectTransform rtButton = startButton.gameObject.GetComponent<RectTransform>();
        RectTransform rtTimer = kencingTimerSlider.gameObject.GetComponent<RectTransform>();


        rtButton.DOScale(1f, 1f)
                .From(0f)
                .SetEase(Ease.OutSine);

        rtTimer.DOScaleX(1f, 2f)
                .From(0f)
                .SetEase(Ease.OutSine);

        tutorialText.DOAnchorPosX(465f, 1f)
                .From(new Vector2(-300f,tutorialText.anchoredPosition.y))
                .SetEase(Ease.OutSine);

        transition.DOFade(0f, 0.5f)
                    .From(1f)
                    .SetEase(Ease.OutSine);
    }
}
