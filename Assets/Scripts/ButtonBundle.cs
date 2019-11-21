using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ButtonBundle : MonoBehaviour
{
    [SerializeField] private AssetReference _asset;
    private GameObject _gameObject;
    private AsyncOperationHandle<GameObject> _currentPrefabOperationHandle;

    public void StartLoading()
    {
        if (_gameObject != null) { _gameObject.SetActive(true); }
        else {StartCoroutine(LoadAndGetAddressable); }
        
        
    }

    private IEnumerator LoadAndGetAddressable
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

    public void Deactive()
    {
        if (_gameObject != null) { _gameObject.SetActive(false); }
         
    }

    

   
}
