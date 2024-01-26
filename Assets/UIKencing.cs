using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIKencing : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject restartPanel;
    [SerializeField] private GameObject battlePanel;


    [SerializeField] private TextMeshProUGUI delayBeforeStartText;
    private bool isDelayActive = false;

    private void Awake()
    {
        KencingManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        KencingManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void Update()
    {
        if (isDelayActive == true && KencingManager.instance.delayBeforeStart >= 0) {
            KencingManager.instance.delayBeforeStart -= Time.deltaTime;
            delayBeforeStartText.SetText(KencingManager.instance.delayBeforeStart.ToString("#.00"));
        }
        
        if(KencingManager.instance.delayBeforeStart <= 0)
        {
            delayBeforeStartText.gameObject.SetActive(false);
        }
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        startButton.SetActive(state == GameState.WAIT);

        battlePanel.SetActive(state == GameState.GAMEPLAY);

        restartPanel.SetActive(state == GameState.GAMEOVER);

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
}
