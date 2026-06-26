using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string GameplayScene;
    [Header("Loading Scene Transition")]
    [SerializeField] private CanvasGroup CG_FadeLoading;
    [SerializeField] private float CG_FadingSpeed = 1;
    [Header("Temp Audio")]
    [SerializeField] private AudioSource AS_Temp;
    [SerializeField] private AudioClip SFX_BtnClick;
    public void Play_OnClick()
    {
        StartCoroutine(AnimatedLoading());
        AS_Temp.PlayOneShot(SFX_BtnClick);
    }
    IEnumerator AnimatedLoading()
    {
        CG_FadeLoading.gameObject.SetActive(true);
        CG_FadeLoading.alpha = 0;
        while (CG_FadeLoading.alpha < 1)
        {
            CG_FadeLoading.alpha += Time.deltaTime* CG_FadingSpeed;
            yield return null;
        }
        SceneManager.LoadSceneAsync(GameplayScene);

    }
    public void Exit_OnClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
