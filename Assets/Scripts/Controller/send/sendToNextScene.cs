using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sendToNextScene : MonoBehaviour
{
    public string NextSceneName;
    private bool hasLoadedScene = false;
    public Image image;
    private void Start()
    {
        image.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.tag == "Player" && hasLoadedScene == false &&Input.GetKeyDown(KeyCode.E))
        { 
            hasLoadedScene = true;
            StartCoroutine(LoadSceneAsync(NextSceneName));
        }
    }

    public void OnClicked() {
        StartCoroutine(LoadSceneAsync(NextSceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        image.gameObject.SetActive(true);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            image.color = new Color(0, 0, 0, 1-progress);
            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
            {
                asyncLoad.allowSceneActivation = true; 
            }
            image.gameObject.SetActive(false);
            yield return null;
        }
    }
}



