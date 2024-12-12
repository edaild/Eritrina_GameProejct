using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    // �̹��� 1�� �̹��� 2�� UI���� ������ �� �ֵ��� SerializeField�� �����մϴ�.

    [Header("Logo_image")]
    public Image image1;  // �̹���1
    public Image image2;  // �̹���2

    // ���̵� ȿ���� ���� �ð��� �̹����� ǥ�õǴ� �ð��� �����մϴ�.
    [Header("FadeTime")]
    public float fadeDuration = 1.0f;  // ���̵� ȿ���� �����ϴ� �ð�
    public float displayDuration = 2.0f; // �̹����� ǥ�õǴ� �ð�

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
            // yield : Enumerator(Iterator)��� �Ҹ��� �̷��� ����� �������� ������ �����κ��� �����͸� �ϳ��� ȣ���ڿ��� �����ִ� ������ �Ѵ�.
            // WaitForSeconds : Ư�� �ð��� �Լ� ȣ��
            // image1�� ���̵� ���մϴ� (���� 0���� 1�� ����)
            yield return StartCoroutine(FadeCanvasGroup(image1, 0f, 1f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // image1�� ���̵� �ƿ��ϰ�, image2�� ���̵� ���մϴ�
            yield return StartCoroutine(FadeCanvasGroup(image1, 1f, 0f, fadeDuration));
            yield return StartCoroutine(FadeCanvasGroup(image2, 0f, 1f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // image2�� ���̵� �ƿ��մϴ�.
            yield return StartCoroutine(FadeCanvasGroup(image2, 1f, 0f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // ���̵� �ƿ� ȿ���� �Ϸ�� �� �� ��ȯ�� �����մϴ�.
            yield return StartCoroutine(FadeOutAndLoadScene("MainScene01"));

            // ���ο� �� �ε� �� ���̵� �� ȿ���� �����մϴ�.
            yield return StartCoroutine(FadeInAfterSceneLoad());

            // ���� ������ �����մϴ�.
            break;
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // ���� ȭ���� ���̵� �ƿ� ��ŵ�ϴ�.
        yield return StartCoroutine(FadeCanvasGroup(image1, image1.color.a, 0f, fadeDuration));
        yield return StartCoroutine(FadeCanvasGroup(image2, image2.color.a, 0f, fadeDuration));

        // ���� �ε��մϴ�.
        SceneManager.LoadScene(sceneName);

        // �� �ε��� �Ϸ�� ������ ��ٸ��ϴ�.
        yield return null;
    }

    private IEnumerator FadeInAfterSceneLoad()
    {
        // ���ο� �� �ε尡 �Ϸ�� �� ���̵� �� ȿ���� �����մϴ�.
        yield return new WaitForSeconds(0.1f); // ��� ����Ͽ� ���� ������ �ε�ǵ��� �մϴ�.
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
