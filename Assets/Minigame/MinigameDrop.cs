using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MinigameDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject feedbackTextPrefab;
    [SerializeField] private Slider healthSlider;
    private TextMeshProUGUI feedbackText;
    private Image _image;
    
    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnDrop(PointerEventData ctx)
    {
        if (MinigameManager.Instance.isGameEnded) return;
        MinigameDrag item = ctx.pointerDrag.GetComponent<MinigameDrag>();
        Feedback(item.isGoodItem);
    }

    void Feedback(bool isPositive)
    {
        MinigameManager.Instance.OnFinishedAction();
        // change color
        _image.color = isPositive ? Color.green : Color.red;
        if (_activeRoutine != null) StopCoroutine(_activeRoutine);
        _activeRoutine = StartCoroutine(FeedbackRoutine());
        // show feedback text
        var feedbackObject = Instantiate(feedbackTextPrefab, transform);
        feedbackText = feedbackObject.GetComponent<TextMeshProUGUI>();
        feedbackText.text = isPositive ? "Good!" : "Bad!";
        Destroy(feedbackObject, 1f);
        // show health bar
        if (!isPositive) healthSlider.value--;
        if (healthSlider.value == 0) MinigameManager.Instance.EndGame(false);
    }

    private Coroutine _activeRoutine;
    IEnumerator FeedbackRoutine()
    {
        var timer = 0f;
        while (timer < .5f)
        {
            _image.color = Color.Lerp(_image.color, new Color(31/255, 31/255, 31/255), timer / .5f);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
