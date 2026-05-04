using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public Transform[] startPoints;
    public int levelsPerScene = 2;

    private int currentLevelIndex = 0;

    SceneController sceneController;
    BallController ballController;
    TimerController timerController;
    void Start()
    {
        sceneController = FindObjectOfType<SceneController>();
        ballController = FindObjectOfType<BallController>();
        timerController = FindObjectOfType<TimerController>();

        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == currentLevelIndex);
        }

        //SetBallToStartPosition();
    }

    public void LoadNextLevel()
    {
        levels[currentLevelIndex].SetActive(false);
        currentLevelIndex++;

        if (currentLevelIndex >= levelsPerScene)
        {
            sceneController.LoadNextScene();
        }
        else if (currentLevelIndex < levels.Length)
        {
            levels[currentLevelIndex].SetActive(true);

            //SetBallToStartPosition();

            timerController.ResetTimer();
            timerController.StartTimer();
            ballController.ResetForNewLevel();
        }
        else
        {
            //Perhaps a option to load main menu
            Debug.Log("No more levels in this scene.");
        }
    }

    //void SetBallToStartPosition()
    //{
    //    if (currentLevelIndex < levels.Length)
    //    {
    //        Transform startPoint = startPoints[currentLevelIndex];
    //        if (startPoint != null)
    //        {
    //            Debug.Log("StartPoint found at position: " + startPoint.position);
    //            ballController.transform.position = startPoint.position;
    //            ballController.ResetVelocity();
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Start Point not found in " + levels[currentLevelIndex].name);
    //        }
    //    }
    //    else
    //    {
    //        Debug.Log("No more levels");
    //    }
    //}
}
