using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransitionController : MonoBehaviour
{
    void Start()
    {
        // Prevent this GameObject from being destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);

        // Start the scene transitions coroutine
        StartCoroutine(SceneLoop());
    }

    private IEnumerator SceneLoop()
    {
        // Loop forever
        while (true)
        {
            yield return new WaitForSeconds(5);  // Scene01 duration
            SceneManager.LoadScene("Scene02");

            yield return new WaitForSeconds(3);  // Scene02 duration
            SceneManager.LoadScene("Scene03");

            yield return new WaitForSeconds(15); // Scene03 duration
            SceneManager.LoadScene("Scene04");

            yield return new WaitForSeconds(3);  // Scene04 duration
            SceneManager.LoadScene("Scene05");

            yield return new WaitForSeconds(15); // Scene05 duration
            SceneManager.LoadScene("Scene06");

            yield return new WaitForSeconds(3);  // Scene06 duration
            SceneManager.LoadScene("Scene07");

            yield return new WaitForSeconds(15); // Scene07 duration
            SceneManager.LoadScene("Scene08");

            yield return new WaitForSeconds(3);  // Scene08 duration
            SceneManager.LoadScene("Scene09");

            yield return new WaitForSeconds(15); // Scene09 duration
            SceneManager.LoadScene("Scene01");  // Loop back to Scene01
        }
    }
}
