using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteUI : MonoBehaviour
{
    public GameObject levelComplete;

    SceneController sceneController;

    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();

        levelComplete.SetActive(false);
    }

    public void ShowLevelCompleteUI()
    {
        levelComplete.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueToNextLevel()
    {
        Time.timeScale = 1;

        levelComplete.SetActive(false);

        if (sceneController != null)
        {
            sceneController.LoadNextScene();
        }
        else
        {
            Debug.Log("SceneController not found");
        }
    }
}
