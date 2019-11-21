using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;

public class LoadPrefabFromToggle : MonoBehaviour
{
    [SerializeField] private AssetReference _asset;
    [SerializeField] private String _tag;
    [SerializeField]private GameObject _gameObject;
    private Toggle toggle;


    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener((value) =>
        {
            ToggleFunction(value);
        });
    }
    public void ToggleFunction(bool value)
    {
        if (value)
        {
            Debug.Log(value);
        }
        else
        {
            Debug.Log(value);
        }
    }
        /*
        GameObject[] toSetOf = GameObject.FindGameObjectsWithTag(_tag);
        if (toSetOf != null)
        {
            foreach (var obj in toSetOf)
            {
                obj.SetActive(false);
            }
        }
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate{
            ToggleFunction(toggle);
        });
    }


    private void ToggleFunction(Toggle toggle)
    {
        if (_gameObject != null)
        {
            if (toggle.isOn == true)
            {
                _gameObject.SetActive(true);
            }
            else
            {
                _gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("i'm here");
            if (toggle.isOn == true)
            {
                StartCoroutine(LoadAndActiveGO);
            }
        }

    }
  
    private IEnumerator LoadAndActiveGO
    {
        get    
        {
            var op = Addressables.LoadAssetAsync<GameObject>(_asset);
            yield return op;
            var handle = _asset.InstantiateAsync();
            yield return handle;
            _gameObject = handle.Result;
        }
    }
   */
}
