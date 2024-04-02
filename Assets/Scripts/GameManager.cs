using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text bestScore;

    private void Start()
    {
        bestScore.text = "Best Score: " + DataManager.Instance.bestPlayerName + " : " + DataManager.Instance.bestScore; 
    }

    public void StartClick()
    {
        DataManager.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResetData()
    {
        //Best Score verilerini sýfýrlamak için.
        DataManager.Instance.bestScore = 0;
        DataManager.Instance.bestPlayerName = " ";
        DataManager.Instance.SaveBestScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
