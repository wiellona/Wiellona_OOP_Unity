using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton
public class LevelManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Awake()
    {
        animator.enabled = false;
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        animator.enabled = true;

        animator.SetTrigger("StartTransition");

        yield return new WaitForSeconds(1);

        SceneManager.LoadSceneAsync(sceneName);

        animator.SetTrigger("EndTransition");

        Player.Instance.transform.position = new(0, -4.5f);
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }
}
