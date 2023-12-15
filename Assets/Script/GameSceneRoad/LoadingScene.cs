using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillImage;

    private Color _startColor = Color.white;
    private Color _endColor = Color.blue;
    private float _colorChangeDuration = 2f;

    void Start()
    {
        _loadingUI.SetActive(true);
        StartCoroutine(LoadNextSceneAfterDelay(2f));
    }

    IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        AsyncOperation async = SceneManager.LoadSceneAsync("SampleScene");

        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            _slider.value = progress;

            // ロード進捗に合わせてスライダーのfillAmountを更新
            _fillImage.fillAmount = progress;

            // ロード進捗に合わせて色を変更
            Color lerpedColor = Color.Lerp(_startColor, _endColor, progress);
            SetFillImageColor(lerpedColor);

            yield return null;
        }

        // ロード完了後に色を変更する
        yield return ChangeSliderColor(_fillImage.color, _endColor, _colorChangeDuration);
    }

    IEnumerator ChangeSliderColor(Color startColor, Color endColor, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // 色を変化させる
            Color lerpedColor = Color.Lerp(startColor, endColor, elapsedTime / duration);
            SetFillImageColor(lerpedColor);

            yield return null;
        }

        // 最終的に終了色に合わせる
        SetFillImageColor(endColor);
    }

    // メインスレッドでfillImageの色を変更するためのメソッド
    private void SetFillImageColor(Color color)
    {
        _fillImage.color = color;
    }
}