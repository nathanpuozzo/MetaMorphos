using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class PrefabManager : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _prefabsAssets;

    private AsyncOperationHandle<GameObject> _currentPrefabOperationHandle;
    private GameObject newGameObject;

    public void SetPrefab(int prefabIndex)
    {
        StartCoroutine(SetPrefabInternal(prefabIndex));
    }

    private IEnumerator SetPrefabInternal(int prefabIndex)
    {
        if (_currentPrefabOperationHandle.IsValid())
        {
            Addressables.Release(_currentPrefabOperationHandle);
        }

            var prefabReference = _prefabsAssets[prefabIndex];
            _currentPrefabOperationHandle = prefabReference.LoadAssetAsync<GameObject>();
            yield return _currentPrefabOperationHandle;
            var handle = prefabReference.InstantiateAsync();
            yield return handle;
            newGameObject = handle.Result;
            newGameObject.SetActive(true);
       
    }
//TODO : Release & Delete instance OnPointerExit
    public void DeleteAsset()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject obj in allObjects)
        {
            Addressables.ReleaseInstance(obj);
        }
    }

}
