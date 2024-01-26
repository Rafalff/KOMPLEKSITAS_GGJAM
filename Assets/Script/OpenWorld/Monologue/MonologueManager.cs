using TMPro;
using UnityEngine;
using System.Collections;

public class MonologueManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    [SerializeField] private bool paused;
    [SerializeField] private bool isActive;
    [SerializeField] private AudioSource sound;

    private float curAnimateCd = 0;
    private float animateCd = 0.025f;

    public TextMeshProUGUI dialogueText;
    string totalDialogueText = "";
	char[] dialogueTextArray;
	int animateIndex = 0;
    int curMonologueIndex = 0;
    MonologueData curData;

    public void StartMonologue(MonologueData data)
    {
        Show();
        StopAllCoroutines();
        CancelInvoke();
        dialogueText.color = data.color;
        dialogueText.text = "";
        curData = data;
        curMonologueIndex = 0;
        totalDialogueText = data.textList[curMonologueIndex];
        dialogueTextArray = totalDialogueText.ToCharArray();
        StartCoroutine(MonologueAnimation());
    }

    public void PlaySound()
    {
        sound.Play();
    }
    public void StopSound()
    {
        sound.Stop();
    }
    public void Show()
    {
        canvas.enabled = true;
    }
    public void Hide()
    {
        canvas.enabled = false;
    }
    private IEnumerator MonologueAnimation()
    {
        sound.PlayOneShot(curData.voiceList[curMonologueIndex]);
        Invoke("Next", curData.voiceList[curMonologueIndex].length + 1f);
        for (int i = 0; i < dialogueTextArray.Length; i++)
		{
            dialogueText.text += dialogueTextArray[i];
            yield return new WaitForSeconds(animateCd);
        }
    }

    private void Next()
    {
        StartCoroutine(NextDelay());
    }
    private IEnumerator NextDelay()
    {
        StopSound();
        yield return new WaitForSeconds(curData.delay[curMonologueIndex]);
        if (curMonologueIndex < curData.textList.Length-1)
        {
            curMonologueIndex++;
            dialogueText.text = "";
            totalDialogueText = curData.textList[curMonologueIndex];
            dialogueTextArray = totalDialogueText.ToCharArray();
            animateIndex = 0;
            StartCoroutine(MonologueAnimation());
        }
        else {
            Hide();
            isActive = false;
        }
    }
}
