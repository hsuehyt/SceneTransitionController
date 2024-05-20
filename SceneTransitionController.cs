using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Klak.Spout; // Use the correct namespace for SpoutSender

public class SceneTransitionController : MonoBehaviour
{
    private SpoutSender spoutBack;
    private SpoutSender spoutAngle;
    private SpoutSender spoutGroundAngle;
    private SpoutSender spoutGround;
    private SpoutSender spoutRight;
    private SpoutSender spoutLeft;
    private bool isPaused = false;
    private Coroutine sceneLoopCoroutine;

    void Start()
    {
        // Prevent this GameObject from being destroyed when loading a new scene
        DontDestroyOnLoad(this.gameObject);

        // Update Spout Senders for the initial scene
        UpdateSpoutSenders();

        // Start the scene transitions coroutine
        sceneLoopCoroutine = StartCoroutine(SceneLoop());
    }

    void Update()
    {
        // Toggle pause/resume when the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void UpdateSpoutSenders()
    {
        // Find and update all Spout Senders in the current scene
        spoutBack = GameObject.Find("SpoutBack")?.GetComponent<SpoutSender>();
        spoutAngle = GameObject.Find("SpoutAngle")?.GetComponent<SpoutSender>();
        spoutGroundAngle = GameObject.Find("SpoutGroundAngle")?.GetComponent<SpoutSender>();
        spoutGround = GameObject.Find("SpoutGround")?.GetComponent<SpoutSender>();
        spoutRight = GameObject.Find("SpoutRight")?.GetComponent<SpoutSender>();
        spoutLeft = GameObject.Find("SpoutLeft")?.GetComponent<SpoutSender>();
    }

    private IEnumerator SceneLoop()
    {
        // Loop forever
        while (true)
        {
            yield return new WaitForSeconds(5);  // Scene01 duration
            SceneManager.LoadScene("Scene02");
            yield return null; // Wait for the scene to load
            UpdateSpoutSenders();

            yield return new WaitForSeconds(3);  // Scene02 duration
            SceneManager.LoadScene("Scene03");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(15); // Scene03 duration
            SceneManager.LoadScene("Scene04");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(3);  // Scene04 duration
            SceneManager.LoadScene("Scene05");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(15); // Scene05 duration
            SceneManager.LoadScene("Scene06");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(3);  // Scene06 duration
            SceneManager.LoadScene("Scene07");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(15); // Scene07 duration
            SceneManager.LoadScene("Scene08");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(3);  // Scene08 duration
            SceneManager.LoadScene("Scene09");
            yield return null;
            UpdateSpoutSenders();

            yield return new WaitForSeconds(15); // Scene09 duration
            SceneManager.LoadScene("Scene01");  // Loop back to Scene01
            yield return null;
            UpdateSpoutSenders();
        }
    }

    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (sceneLoopCoroutine != null)
        {
            StopCoroutine(sceneLoopCoroutine);
        }
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        sceneLoopCoroutine = StartCoroutine(SceneLoop());
    }
}
