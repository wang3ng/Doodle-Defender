
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class UIEffectManager : MonoBehaviour
{

    public static UIEffectManager Instance;


    public float fadeTime = 1f;
    public CanvasGroup targetObject;
    public RectTransform rectTransform;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void FadeIn()
    {
        targetObject.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic,0f,1.2f);
        targetObject.DOFade(1, fadeTime);
    }

    public void FadeOut()
    {
        targetObject.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint,0f,1.2f);
        targetObject.DOFade(0, fadeTime);
    }



}
