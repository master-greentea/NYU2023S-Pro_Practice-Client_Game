using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager Instance;
    // time
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] [Range(10, 60)] private int setTime = 60;
    private float currentTime;
    // countdown
    [SerializeField] private TextMeshProUGUI countdownText;
    [HideInInspector] public bool isGameStarted;
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
        timerText.text = "0:" + currentTime;
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1f);
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);
        countdownText.GetComponent<Animator>().Play("CountdownFinish");
        countdownText.text = "Go!";
        isGameStarted = true;
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
        if (isGameEnded || !isGameStarted)
        {
            timerText.color = Color.gray;
            return;
        }
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
        GlobalGameManager.AddGreenPoints(isGameWon ? 100 : 0);
        factsCanvas.SetActive(isGameWon);
        failedCanvas.SetActive(!isGameWon);
    }

    public void RestartLevel()
    {
        if (GlobalGameManager.energy >= 15)
        {
            GlobalGameManager.UseEnergy(15);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            GlobalGameManager.Instance.warning.text = "Low Energy!";
            StartCoroutine(GlobalGameManager.Instance.ClearWarning());
        }
    }

    public void ToClinic()
    {
        SceneManager.LoadScene("Clinic");
    }
}
