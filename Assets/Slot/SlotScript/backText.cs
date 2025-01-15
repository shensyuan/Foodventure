using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using TMPro;

public class backText :  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // public Transform arrow;
    // public Transform target;
    public TextMeshProUGUI text;

    private bool isTextVisible = false;

    void Start()
    {
        text.text = "Press C to back to main map";
        Color textColor = text.color;
        textColor.a = 0f;
        text.color = textColor;
    }

    void Update()
    {
        // if (arrow != null && target != null)
        // {
        //     // 檢查箭頭是否在目標位置附近
        //     float distance = Vector3.Distance(arrow.position, target.position);

        //     if (distance <= detectionRadius && !isTextVisible)
        //     {
        //         isTextVisible = true;
        //     }
        //     else if (distance > detectionRadius && isTextVisible)
        //     {
        //         // 隱藏文字
        //         StartCoroutine(FadeText(0f)); // 淡出文字
        //         isTextVisible = false;
        //     }
        // }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("pointin");
        if (!isTextVisible)
        {
            StartCoroutine(FadeText(1f,0.5f)); // 淡入文字
            isTextVisible = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isTextVisible)
        {
            StartCoroutine(FadeText(0f,2f)); // 淡出文字
            isTextVisible = false;
        }
    }

    private IEnumerator FadeText(float targetAlpha, float fadeDuration)
    {
        if (text == null) yield break;

        float elapsedTime = 0f;
        Color originalColor = text.color;
        float startAlpha = originalColor.a;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
    }
}
