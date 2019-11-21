using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAssetsBundle : MonoBehaviour
{
    [SerializeField] private AssetReference _asset;
    private GameObject _gameObject;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAssetBundle);       
    }

    private IEnumerator LoadAssetBundle
    {
        get
        {
            loadingScreen.SetActive(true);
            var op = Addressables.LoadAssetAsync<GameObject>(_asset);
            while (!op.IsDone)
            {
                float progress = Mathf.Clamp01(op.PercentComplete / .9f);

                slider.value = progress;

                progressText.text = (progress * 100).ToString("F0") + "%";

                yield return null;

            }
            loadingScreen.SetActive(false);
            yield return op;
            var handle = _asset.InstantiateAsync();
            yield return handle;
            _gameObject = handle.Result;
            yield return null;
        }
    }
}
