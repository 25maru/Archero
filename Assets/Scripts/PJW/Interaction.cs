using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SpriteChanger
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public void ApplySprite()
    {
        spriteRenderer.sprite = sprite;
    }
}

public class Interaction : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform interactHint;
    [SerializeField] private float offset = -25f;
    [SerializeField] private float duration = 0.4f;
    [SerializeField] private float feedbackDuration = 0.1f;

    [Space(5f)]
    [SerializeField] private List<SpriteChanger> sprites;
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private bool disableCollider;
    [SerializeField] private GameObject popupUI;
    [SerializeField] private string sceneName;

    private Coroutine coroutine;
    private Vector2 targetPosition;
    private Vector2 startPosition;
    private bool isInRange;
    private bool isQueuedAnimation = false; // 대기 중인 애니메이션 여부
    private bool isSceneChanging = false;   // 씬 전환 중인지 체크
    private bool isProcessing = false;
    private bool isAnimating = false;


    private void Start()
    {
        if (canvasGroup != null && interactHint != null)
        {
            targetPosition = interactHint.anchoredPosition;
            startPosition = targetPosition + new Vector2(0, offset);
        }
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F) && !isSceneChanging && !isProcessing)
        {
            StartCoroutine(ExecuteWithFeedback());
        }
    }

    /// <summary>
    /// F 키를 눌렀을 때 피드백을 주고 코드 실행
    /// </summary>
    private IEnumerator ExecuteWithFeedback()
    {
        isProcessing = true;

        yield return new WaitUntil(() => !isAnimating);

        if (canvasGroup != null && interactHint != null)
        {
            float elapsedTime = 0f;
            float originalAlpha = canvasGroup.alpha;
            float targetAlpha = 0.5f;

            while (elapsedTime < feedbackDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / feedbackDuration;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, targetAlpha, t);
                yield return null;
            }

            yield return new WaitForSeconds(0.05f);

            elapsedTime = 0f;

            while (elapsedTime < feedbackDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / feedbackDuration;
                canvasGroup.alpha = Mathf.Lerp(targetAlpha, 1f, t);
                yield return null;
            }
        }

        // 코드 실행
        if (!string.IsNullOrEmpty(sceneName))
        {
            isSceneChanging = true;
            StopAllCoroutines();
            SceneManager.LoadScene(sceneName);
        }

        foreach (SpriteChanger sprite in sprites)
        {
            sprite.ApplySprite();
        }

        if (disableCollider)
        {
            GetComponent<Collider2D>().enabled = false;
        }

        if (audioClips.Count != 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, audioClips.Count);
            AudioClip clip = audioClips[randomIndex];
            AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        }

        isProcessing = false; // 입력 처리 완료
    }

    private void PlayHintAnimation(bool isActive)
    {
        if (isSceneChanging || !isActiveAndEnabled) return;

        // 현재 실행 중인 애니메이션이 있다면, 새로운 애니메이션을 대기 상태로 등록
        if (coroutine != null)
        {
            isQueuedAnimation = true;
            return;
        }

        // 새로운 애니메이션 실행
        coroutine = StartCoroutine(AnimateHint(isActive));
    }

    private IEnumerator AnimateHint(bool isActive)
    {
        isAnimating = true;

        float elapsedTime = 0f;
        Vector2 start = isActive ? startPosition : targetPosition;
        Vector2 end = isActive ? targetPosition : startPosition;
        float startAlpha = isActive ? 0 : 1;
        float endAlpha = isActive ? 1 : 0;

        while (elapsedTime < duration)
        {
            if (isSceneChanging || !isActiveAndEnabled) yield break;

            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = EaseOutCubic(t);

            interactHint.anchoredPosition = Vector2.Lerp(start, end, t);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            yield return null;
        }

        interactHint.anchoredPosition = end;
        canvasGroup.alpha = endAlpha;

        // 애니메이션이 끝난 후, 대기 중인 애니메이션이 있다면 실행
        coroutine = null;
        isAnimating = false;

        if (isQueuedAnimation)
        {
            isQueuedAnimation = false; // 대기 중인 애니메이션 해제
            PlayHintAnimation(!isActive); // 반대 상태의 애니메이션 실행
        }
    }

    /// <summary>
    /// EaseOutCubic 공식 (t 값이 변함에 따라 초반에는 빠르고, 끝에서 느려짐)
    /// </summary>
    /// <param name="t">0-1 사이의 값</param>
    /// <returns></returns>
    private float EaseOutCubic(float t)
    {
        return 1 - Mathf.Pow(1 - t, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canvasGroup != null && interactHint != null)
        {
            isInRange = true;
            PlayHintAnimation(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canvasGroup != null && interactHint != null)
        {
            isInRange = false;
            PlayHintAnimation(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canvasGroup != null && interactHint != null)
        {
            isInRange = true;
            PlayHintAnimation(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canvasGroup != null && interactHint != null)
        {
            isInRange = false;
            PlayHintAnimation(false);
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
