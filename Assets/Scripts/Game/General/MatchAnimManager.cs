using DG.Tweening;
using System.Collections;
using UnityEngine;

public class MatchAnimManager : MonoBehaviour
{
    [SerializeField] private RectTransform kickOffBanner;
    [SerializeField] private CanvasGroup kickOffCanvas;

    private Tween currentTween;

    public virtual IEnumerator PlayKickOffAnimation()
    {
        yield return PlayBanner(kickOffCanvas, kickOffBanner);
    }

    private IEnumerator PlayBanner(CanvasGroup bannerCanvas, RectTransform banner)
    {
        banner.gameObject.SetActive(true);

        currentTween?.Kill();

        bannerCanvas.alpha = 1;

        Vector2 center = Vector2.zero;

        Vector2 start =
            new Vector2(
        -Screen.width,
                0);
        banner.anchoredPosition = start;

        banner.localScale = Vector3.zero;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(
            banner.DOAnchorPos(center, .35f)
                .SetEase(Ease.OutBack));
        sequence.Join(
            banner.DOScale(1f, .35f)
                .SetEase(Ease.OutBack));

        sequence.AppendInterval(.5f);
        sequence.Append(
            banner.DOScale(.65f, .45f)
                .SetEase(Ease.InBack));

        sequence.Join(
            bannerCanvas.DOFade(0, .45f));

        yield return sequence.WaitForCompletion();

        banner.gameObject.SetActive(false);
    }
}