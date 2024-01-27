using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    private void Awake()
    {
        Invoke("LoadScene", 12f);
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("OpenWorld");
    }
}
