using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClinicManager : MonoBehaviour
{
    [SerializeField] private GameObject globalGameManager;
    void Start()
    {
        if (GlobalGameManager.Instance != null) return;
        Instantiate(globalGameManager);
    }

    public void ToMinigameScene()
    {
        if (GlobalGameManager.energy >= 15)
        {
            GlobalGameManager.UseEnergy(15);
            SceneManager.LoadScene("Minigame");
        }
        else
        {
            GlobalGameManager.Instance.warning.text = "Low Energy!";
            StartCoroutine(GlobalGameManager.Instance.ClearWarning());
        }
    }

    public void ToGardenScene()
    {
        SceneManager.LoadScene("Garden");
    }
}
