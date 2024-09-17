using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    // 이미지 1과 이미지 2를 UI에서 설정할 수 있도록 SerializeField로 선언합니다.
    [SerializeField]
    public Image image1;  // 이미지1
    public Image image2;  // 이미지2

    // 페이드 효과의 지속 시간과 이미지가 표시되는 시간을 설정합니다.
    public float fadeDuration = 1.0f;  // 페이드 효과를 지속하는 시간
    public float displayDuration = 1.0f; // 이미지가 표시되는 시간

    private void Start()
    {
        // FadeInOut 코루틴을 시작하여 이미지의 페이드 효과를 반복합니다.
        StartCoroutine(FadeInOut());
    }

    private IEnumerator FadeInOut()
    {
        // 무한 루프를 사용하여 이미지의 페이드 효과를 반복합니다.
        while (true)
        {
            // image1을 페이드 인합니다 (투명도 0에서 1로 변경)
            yield return StartCoroutine(FadeCanvasGroup(image1, 0f, 1f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // image1을 페이드 아웃하고, image2를 페이드 인합니다
            yield return StartCoroutine(FadeCanvasGroup(image1, 1f, 0f, fadeDuration));
            yield return StartCoroutine(FadeCanvasGroup(image2, 0f, 1f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // image2를 페이드 아웃합니다.
            yield return StartCoroutine(FadeCanvasGroup(image2, 1f, 0f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);

            // 페이드 아웃 효과가 완료된 후 씬 전환을 시작합니다.
            yield return StartCoroutine(FadeOutAndLoadScene("MainScene"));

            // 새로운 씬 로드 후 페이드 인 효과를 적용합니다.
            yield return StartCoroutine(FadeInAfterSceneLoad());

            // 무한 루프를 종료합니다.
            break;
        }
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        // 현재 화면을 페이드 아웃 시킵니다.
        yield return StartCoroutine(FadeCanvasGroup(image1, image1.color.a, 0f, fadeDuration));
        yield return StartCoroutine(FadeCanvasGroup(image2, image2.color.a, 0f, fadeDuration));

        // 씬을 로드합니다.
        SceneManager.LoadScene(sceneName);

        // 씬 로딩이 완료될 때까지 기다립니다.
        yield return null;
    }

    private IEnumerator FadeInAfterSceneLoad()
    {
        // 새로운 씬 로드가 완료된 후 페이드 인 효과를 적용합니다.
        yield return new WaitForSeconds(0.1f); // 잠시 대기하여 씬이 완전히 로드되도록 합니다.

        // 새 씬의 UI 이미지가 있을 경우 페이드 인을 적용합니다.
        if (image1 != null)
            yield return StartCoroutine(FadeCanvasGroup(image1, 0f, 1f, fadeDuration));
        if (image2 != null)
            yield return StartCoroutine(FadeCanvasGroup(image2, 0f, 1f, fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(Image image, float startAlpha, float endAlpha, float duration)
    {
        // 페이드 효과를 적용하기 위한 경과 시간을 추적합니다.
        float elapsedTime = 0f;

        // 지정된 기간 동안 페이드 효과를 적용합니다.
        while (elapsedTime < duration)
        {
            // 시간에 따라 알파 값을 선형 보간하여 페이드 효과를 계산합니다.
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);

            // Image 컴포넌트의 알파 값을 설정합니다.
            Color color = image.color;
            color.a = alpha;
            image.color = color;

            // 경과 시간을 업데이트합니다.
            elapsedTime += Time.deltaTime;

            // 다음 프레임까지 대기합니다.
            yield return null;
        }

        // 페이드 효과가 완료되면 최종 알파 값을 설정합니다.
        Color finalColor = image.color;
        finalColor.a = endAlpha;
        image.color = finalColor;
    }
}
