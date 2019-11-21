using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadScene : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public bool check = false;
    [SerializeField] private string address;
    void Start()
    {
        check = false;  
    }

    public void LoadNextScene() {

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject obj in allObjects)
        {
            Addressables.ReleaseInstance(obj);
        }
        StartCoroutine(LoadAsynchronously);
        check = true;
    }

   

    IEnumerator LoadAsynchronously
    {
        get
        {
            var operation = Addressables.LoadSceneAsync(address);

            loadingScreen.SetActive(true);

            while (!operation.IsDone)
            {
                float progress = Mathf.Clamp01(operation.PercentComplete / .9f);

                slider.value = progress;

                progressText.text = (progress * 100).ToString("F0") + "%";

                yield return null;

            }
        }
    }
}
