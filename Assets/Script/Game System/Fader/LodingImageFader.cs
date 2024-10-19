using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LodingImageFader : MonoBehaviour
{
    [SerializeField]
    public Image image1;

    public float fadeDuration = 1.0f;  // ���̵� ȿ���� �����ϴ� �ð�
    public float displayDuration = 1.0f; // �̹����� ǥ�õǴ� �ð�

    private void Start()
    {
        // FadeInOut �ڷ�ƾ�� �����Ͽ� �̹����� ���̵� ȿ���� �ݺ��մϴ�.
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        // ���� ������ ����Ͽ� �̹����� ���̵� ȿ���� �ݺ��մϴ�.
        while (true)
        {
            // image1�� ���̵� �ƿ��մϴ� (���� 1���� 0�� ����)
            yield return StartCoroutine(FadeCanvasGroup(image1, 1f, 0f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);        

            // ���� ������ �����մϴ�.
            break;
        }
    }

    private IEnumerator FadeCanvasGroup(Image image, float startAlpha, float endAlpha, float duration)
    {
        // ���̵� ȿ���� �����ϱ� ���� ��� �ð��� �����մϴ�.
        float elapsedTime = 0f;

        // ������ �Ⱓ ���� ���̵� ȿ���� �����մϴ�.
        while (elapsedTime < duration)
        {
            // �ð��� ���� ���� ���� ���� �����Ͽ� ���̵� ȿ���� ����մϴ�.
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);

            // Image ������Ʈ�� ���� ���� �����մϴ�.
            Color color = image.color;
            color.a = alpha;
            image.color = color;

            // ��� �ð��� ������Ʈ�մϴ�.
            elapsedTime += Time.deltaTime;

            // ���� �����ӱ��� ����մϴ�.
            yield return null;
        }

        // ���̵� ȿ���� �Ϸ�Ǹ� ���� ���� ���� �����մϴ�.
        Color finalColor = image.color;
        finalColor.a = endAlpha;
        image.color = finalColor;
    }
}
