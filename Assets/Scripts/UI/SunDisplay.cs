using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SunDisplay : MonoBehaviour
{
    [SerializeField] Text sunAmountText;
    [SerializeField] float minSpeed = 300f;
    [SerializeField] float maxSpeed = 3000f;
    [SerializeField] float speedCurvePower = 0.6f;

    private int currentSunAmount;
    private Coroutine sunLerpCoroutine;
    private Coroutine flashCoroutine;

    public void SetSunAmount(int newAmount)
    {
        if (sunLerpCoroutine != null)
            StopCoroutine(sunLerpCoroutine);

        sunLerpCoroutine = StartCoroutine(SmoothUpdateSunAmount(newAmount));
    }

    private IEnumerator SmoothUpdateSunAmount(int targetAmount)
    {
        while (currentSunAmount != targetAmount)
        {
            int difference = Mathf.Abs(targetAmount - currentSunAmount);
            int direction = (int)Mathf.Sign(targetAmount - currentSunAmount);

            // Dynamically calculate speed based on distance (curved)
            float t = Mathf.Pow((float)difference / 5000f, speedCurvePower); // normalize and curve
            float dynamicSpeed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.Clamp01(t));
            int delta = Mathf.CeilToInt(dynamicSpeed * Time.deltaTime);

            if (difference < delta)
                currentSunAmount = targetAmount;
            else
                currentSunAmount += delta * direction;

            sunAmountText.text = currentSunAmount.ToString();
            yield return null;
        }
    }

    // --------------------------------------------------------------------------------------------

    public void ShowNotEnoughSun()
    {
        if (flashCoroutine != null)
            StopCoroutine(flashCoroutine);

        flashCoroutine = StartCoroutine(FlashRedTwiceCoroutine());
    }

    private IEnumerator FlashRedTwiceCoroutine()
    {
        Color originalColor = Color.white;
        Color flashColor = Color.red;
        float flashDuration = 0.15f;

        for (int i = 0; i < 2; i++)
        {
            // Fade to red
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / flashDuration;
                sunAmountText.color = Color.Lerp(originalColor, flashColor, t);
                yield return null;
            }

            // Fade back to white
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / flashDuration;
                sunAmountText.color = Color.Lerp(flashColor, originalColor, t);
                yield return null;
            }
        }

        sunAmountText.color = originalColor;
        flashCoroutine = null;
    }
}
