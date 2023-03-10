using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
    public TextMeshProUGUI warning;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI greenPointsText;
    //
    public static GlobalGameManager Instance;
    [SerializeField] [Range(10, 100)] private int startEnergy;
    public static int energy { get; private set; }
    [SerializeField] [Range(100, 1000)] private int startGreenPoints;
    public static int greenPoints { get; private set; }
    
    void Awake()
    {
        if (Instance != null) return;
        DontDestroyOnLoad(gameObject);
        Instance = this;
        energy = startEnergy;
        greenPoints = startGreenPoints;
    }

    private void Update()
    {
        energyText.text = energy + "/100";
        greenPointsText.text = greenPoints.ToString();
    }

    public static void UseEnergy(int amount)
    {
        energy -= amount;
        if (energy <= 0) energy = 0;
    }

    public static void AddEnergy(int amount)
    {
        energy += amount;
        if (energy >= 100) energy = 100;
    }

    public static void UseGreenPoints(int amount)
    {
        greenPoints -= amount;
        if (greenPoints <= 0) greenPoints = 0;
    }

    public static void AddGreenPoints(int amount)
    {
        greenPoints += amount;
    }
    
    public IEnumerator ClearWarning()
    {
        yield return new WaitForSeconds(.5f);
        warning.text = "";
    }
}
