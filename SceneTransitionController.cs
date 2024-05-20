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

            // Ensures all SpoutSenders are not destroyed on load
            foreach (var sender in spoutSenders)
            {
                DontDestroyOnLoad(sender.gameObject);
            }
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

        if (spoutSenders == null || spoutSenders.Count == 0)
        {
            Debug.LogError("No SpoutSenders assigned in the Inspector");
            return;
        }

        UpdateSpoutSenders();
        sceneLoopCoroutine = StartCoroutine(SceneLoop());
    }

    void UpdateSpoutSenders()
    {
        if (spoutSenders == null || spoutSenders.Count == 0)
        {
            Debug.LogError("No SpoutSenders to update");
            return;
        }

        for (int i = 0; i < spoutSenders.Count; i++)
        {
            var spoutSender = spoutSenders[i];
            if (spoutSender != null)
            {
                Debug.Log("Updating Spout Sender: " + spoutSender.name);
                spoutSender.PublicUpdate();  // Call the public method
                Debug.Log("Spout Sender Updated: " + spoutSender.name);
            }
            else
            {
                Debug.LogError("SpoutSender at index " + i + " is null, attempting to reassign.");

                // Attempt to reassign the SpoutSender
                string senderName = GetSpoutSenderName(i);
                spoutSenders[i] = GameObject.Find(senderName)?.GetComponent<SpoutSender>();
                if (spoutSenders[i] != null)
                {
                    DontDestroyOnLoad(spoutSenders[i].gameObject);
                    Debug.Log("Successfully reassigned SpoutSender: " + spoutSenders[i].name);
                }
                else
                {
                    Debug.LogError("Failed to reassign SpoutSender at index " + i);
                }
            }
        }
    }

    string GetSpoutSenderName(int index)
    {
        switch (index)
        {
            case 0: return "SpoutBack";
            case 1: return "SpoutAngle";
            case 2: return "SpoutGroundAngle";
            case 3: return "SpoutGround";
            case 4: return "SpoutRight";
            case 5: return "SpoutLeft";
            default: return null;
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
