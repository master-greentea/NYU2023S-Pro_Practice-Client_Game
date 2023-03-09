using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;
    // time
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] [Range(10, 60)] private int setTime = 60;
    private float currentTime;
    // game
    [SerializeField] private GameObject factsCanvas;
    [SerializeField] private GameObject failedCanvas;
    [HideInInspector] public bool isGameEnded;
    // items
    [SerializeField] private MinigameDrag[] items;

    void Awake()
    {
        Instance = this;
        currentTime = setTime;
    }
    
    void Update()
    {
        Timer();
    }

    public void OnFinishedAction()
    {
        foreach (var item in items) item.isGoodItem = false;
        int goodIndex = Random.Range(0, 4);
        items[goodIndex].isGoodItem = true;
    }

    private void Timer()
    {
        if (isGameEnded) return;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            currentTime = 0;
            EndGame(false);
        }
        var seconds = Mathf.RoundToInt(currentTime % 60f);
        timerText.text = "0:" + (seconds < 10 ? "0" : "") + seconds;
        timerText.color = currentTime < 10 ? Color.yellow : Color.white;
    }

    public void EndGame(bool isGameWon)
    {
        isGameEnded = true;
        factsCanvas.SetActive(isGameWon);
        failedCanvas.SetActive(!isGameWon);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
