using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Klak.Spout;

[System.Serializable]
public class SceneTransition
{
    [Tooltip("The name of the scene to transition to. Make sure the scene is added to the build settings.")]
    public string sceneName; // Use string to store scene name

    [Tooltip("The duration (in seconds) to display the scene before transitioning.")]
    public float duration; // Duration in seconds
}

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance { get; private set; }

    public List<SpoutSender> spoutSenders = new List<SpoutSender>();

    [Tooltip("List of scene transitions with respective durations (in seconds).")]
    public List<SceneTransition> sceneTransitions = new List<SceneTransition>();

    private Coroutine sceneLoopCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 24; // Set frame rate to 24 fps
        Debug.Log("SceneTransitionController started on " + gameObject.name);

        UpdateSpoutSenders();
        sceneLoopCoroutine = StartCoroutine(SceneLoop());
    }

    void UpdateSpoutSenders()
    {
        string[] spoutSenderNames = new string[] { "SpoutBack", "SpoutAngle", "SpoutGroundAngle", "SpoutGround", "SpoutRight", "SpoutLeft" };

        spoutSenders.Clear();

        foreach (string name in spoutSenderNames)
        {
            SpoutSender sender = GameObject.Find(name)?.GetComponent<SpoutSender>();
            if (sender != null)
            {
                spoutSenders.Add(sender);
                DontDestroyOnLoad(sender.gameObject);
                Debug.Log("Found and assigned SpoutSender: " + name);
            }
            else
            {
                Debug.LogError("SpoutSender not found: " + name);
            }
        }
    }

    private IEnumerator SceneLoop()
    {
        while (true)
        {
            foreach (var transition in sceneTransitions)
            {
                if (!string.IsNullOrEmpty(transition.sceneName))
                {
                    yield return StartCoroutine(TransitionToScene(transition.sceneName, transition.duration));
                }
                else
                {
                    Debug.LogError("Scene name not assigned in SceneTransition.");
                }
            }
        }
    }

    private IEnumerator TransitionToScene(string sceneName, float waitTime)
    {
        Debug.Log("Transitioning to " + sceneName);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(1);  // Give some time for the scene to load
        UpdateSpoutSenders();
        yield return new WaitForSeconds(waitTime);
    }
}
