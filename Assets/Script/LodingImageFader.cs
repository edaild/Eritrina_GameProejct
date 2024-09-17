using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LodingImageFader : MonoBehaviour
{
    [SerializeField]
    public Image image1;

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
            // image1을 페이드 아웃합니다 (투명도 1에서 0로 변경)
            yield return StartCoroutine(FadeCanvasGroup(image1, 1f, 0f, fadeDuration));
            yield return new WaitForSeconds(displayDuration);        

            // 무한 루프를 종료합니다.
            break;
        }
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
