
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitionAnimator;

    private bool isTransitioning = false;

    public void LoadNextScene()
    {
        if (!isTransitioning)
        {
            StartCoroutine(Transition());
        }
    }

    private IEnumerator Transition()
    {
        isTransitioning = true;

        // Play the fade-to-black animation.
        transitionAnimator.Play("FadeOut", 0, 0f);

        // Wait for the animation to finish.
        yield return new WaitForSeconds(1f);

        // Get the current scene index.
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        // Switch between Scene1 and Scene2.
        int nextScene = currentScene == 0 ? 1 : 0;

        SceneManager.LoadScene(nextScene);
    }
}
