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

            // ���[�h�i���ɍ��킹�ăX���C�_�[��fillAmount���X�V
            _fillImage.fillAmount = progress;

            // ���[�h�i���ɍ��킹�ĐF��ύX
            Color lerpedColor = Color.Lerp(_startColor, _endColor, progress);
            SetFillImageColor(lerpedColor);

            yield return null;
        }

        // ���[�h������ɐF��ύX����
        yield return ChangeSliderColor(_fillImage.color, _endColor, _colorChangeDuration);
    }

    IEnumerator ChangeSliderColor(Color startColor, Color endColor, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // �F��ω�������
            Color lerpedColor = Color.Lerp(startColor, endColor, elapsedTime / duration);
            SetFillImageColor(lerpedColor);

            yield return null;
        }

        // �ŏI�I�ɏI���F�ɍ��킹��
        SetFillImageColor(endColor);
    }

    // ���C���X���b�h��fillImage�̐F��ύX���邽�߂̃��\�b�h
    private void SetFillImageColor(Color color)
    {
        _fillImage.color = color;
    }
}