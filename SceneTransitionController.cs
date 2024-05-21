using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using Klak.Spout;

public class SceneTransitionController : MonoBehaviour
{
    public static SceneTransitionController Instance { get; private set; }
    public List<SpoutSender> spoutSenders = new List<SpoutSender>();
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
        Application.targetFrameRate = 60; // Ensure stable frame rate
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
            yield return TransitionToScene("Scene02", 5);
            yield return TransitionToScene("Scene03", 3);
            yield return TransitionToScene("Scene04", 15);
            yield return TransitionToScene("Scene05", 3);
            yield return TransitionToScene("Scene06", 15);
            yield return TransitionToScene("Scene07", 3);
            yield return TransitionToScene("Scene08", 15);
            yield return TransitionToScene("Scene09", 3);
            yield return TransitionToScene("Scene01", 15);
        }
    }

    private IEnumerator TransitionToScene(string sceneName, float waitTime)
    {
        Debug.Log("Transitioning to " + sceneName);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(1);  // Give some time for the scene to load
        UpdateSpoutSenders();
    }
}
