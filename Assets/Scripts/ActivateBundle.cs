using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


public class ActivateBundle : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _assetReferences;


    private readonly Dictionary<AssetReference, List<GameObject>> _loadAssetSystems =
        new Dictionary<AssetReference, List<GameObject>>();

    /// The Queue holds requests to spawn an instanced that were made while we are already loading the asset
    /// They are spawned once the addressable is loaded, in the order requested
    /// 
    private readonly Dictionary<AssetReference, Queue<Vector3>> _queuedAssetRequests =
       new Dictionary<AssetReference, Queue<Vector3>>();

    private readonly Dictionary<AssetReference, AsyncOperationHandle<GameObject>> _asyncOperationHandles =
        new Dictionary<AssetReference, AsyncOperationHandle<GameObject>>();

   
    public void Spawn(int index)
    {
       
        if (index < 0 || index >= _assetReferences.Count)
            return;

        AssetReference assetReference = _assetReferences[index];
        if (assetReference.RuntimeKeyIsValid() == false)
        {
            
            Debug.Log("Invalid Key " + assetReference.RuntimeKey.ToString());
            return;
        }

        if (_asyncOperationHandles.ContainsKey(assetReference))
        {
            if (_asyncOperationHandles[assetReference].IsDone)
                LoadAssetFromLoadedReference(assetReference, GetAssetPosition());
            else
                EnqueueAssetForAfterInitialization(assetReference);

            return;
        }
        
        LoadAndGet(assetReference);
    }

    private void LoadAndGet(AssetReference assetReference)
    {
        
        var op = Addressables.LoadAssetAsync<GameObject>(assetReference);
        _asyncOperationHandles[assetReference] = op;
        op.Completed += (operation) =>
        {
            LoadAssetFromLoadedReference(assetReference, GetAssetPosition());
            if (_queuedAssetRequests.ContainsKey(assetReference))
            {
                while (_queuedAssetRequests[assetReference]?.Any() == true)
                {
                    var position = _queuedAssetRequests[assetReference].Dequeue();
                    LoadAssetFromLoadedReference(assetReference, position);
                }
            }
        };
    }

    private void EnqueueAssetForAfterInitialization(AssetReference assetReference)
    {
        if (_queuedAssetRequests.ContainsKey(assetReference) == false)
            _queuedAssetRequests[assetReference] = new Queue<Vector3>();
        _queuedAssetRequests[assetReference].Enqueue(GetAssetPosition());
    }

    private Vector3 GetAssetPosition()
    {
        return new Vector3();
    }

    private void LoadAssetFromLoadedReference(AssetReference assetReference, Vector3 position)
    {
        assetReference.InstantiateAsync().Completed += (asyncOperationHandle) =>
        {
            if (_loadAssetSystems.ContainsKey(assetReference) == false)
            {
                _loadAssetSystems[assetReference] = new List<GameObject>();
            }

            _loadAssetSystems[assetReference].Add(asyncOperationHandle.Result);
            
            var notify = asyncOperationHandle.Result.AddComponent<NotifyOnDestroy>();
            notify.Destroyed += Remove;
            notify.AssetReference = assetReference;
            
        };
    }

    public void Remove(AssetReference assetReference, NotifyOnDestroy obj)
    {
        Addressables.ReleaseInstance(obj.gameObject);
        _loadAssetSystems[assetReference].Remove(obj.gameObject);
        if (_loadAssetSystems[assetReference].Count == 0)
        {
            Debug.Log($"Removed all {assetReference.RuntimeKey.ToString()}");

            if (_asyncOperationHandles[assetReference].IsValid())
                Addressables.Release(_asyncOperationHandles[assetReference]);

            _asyncOperationHandles.Remove(assetReference);
        }
    }
}
