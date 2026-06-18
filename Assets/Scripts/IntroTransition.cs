using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTransition : MonoBehaviour
{
    [Header("Raw Images")]
    public RawImage image1;
    public RawImage image2;

    [Header("Times")]
    public float fadeTime = 1.5f;
    public float holdTime = 2f;

    [Header("Next Scene")]
    public string nextScene = "MainScene";

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        // Mostrar primera imagen
        SetAlpha(image1, 1f);
        SetAlpha(image2, 0f);

        yield return new WaitForSeconds(holdTime);

        // Transición suave
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;

            float a = Mathf.Clamp01(t / fadeTime);

            SetAlpha(image1, 1f - a);
            SetAlpha(image2, a);

            yield return null;
        }

        SetAlpha(image1, 0f);
        SetAlpha(image2, 1f);

        yield return new WaitForSeconds(holdTime);

        SceneManager.LoadScene(nextScene);
    }

    void SetAlpha(RawImage img, float alpha)
    {
        Color c = img.color;
        c.a = alpha;
        img.color = c;
    }
}