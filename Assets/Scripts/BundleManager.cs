using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AssetBundles;
using UnityEngine;

public class BundlesManager
{
    private static BundlesManager _instance;
    private Dictionary<string, AssetBundle> _assetBundles;
    private Dictionary<string, Task<AssetBundle>> _loadingAssetBundles;
    private bool _init;

    private AssetBundleManager _assetBundleManager;

    private AssetBundleManager AssetBundleManager =>
        _assetBundleManager ?? (_assetBundleManager = new AssetBundleManager());

    public static BundlesManager Instance => _instance ?? (_instance = new BundlesManager());

    private async Task Init()
    {
        _assetBundleManager = new AssetBundleManager();

        if (Application.isEditor)
        {
            // _assetBundleManager.SetBaseUri(Config.Instance.AssetBundlesURL);
            _assetBundleManager.UseSimulatedUri();
        }
        else
        {
            _assetBundleManager.SetBaseUri("http://monbundle.com");
        }

     //   await _assetBundleManager.Initialize();
        _assetBundles = new Dictionary<string, AssetBundle>();
        _loadingAssetBundles = new Dictionary<string, Task<AssetBundle>>();
        _init = true;
    }

    /// <summary>
    /// Return an AssetBundle using its name
    /// </summary>
    /// <param name="assetBundleName">The name of the asset bundle to load</param>
    /// <returns></returns>
    /// <exception cref="Exception">Will throw an exception if the bundle does not exist</exception>
    public async Task<AssetBundle> GetBundle(string assetBundleName)
    {
        if (!_init) await Init();

        var lowerName = assetBundleName.ToLower();

        if (_loadingAssetBundles.ContainsKey(lowerName))
        {
            return await _loadingAssetBundles[lowerName];
        }

        if (!_assetBundles.ContainsKey(lowerName))
        {
            /*
            var loadingTask = AssetBundleManager.GetBundle(lowerName);
            _loadingAssetBundles.Add(lowerName, loadingTask);

            var bundle = await loadingTask;
            _loadingAssetBundles.Remove(lowerName);

            if (bundle == null)
            {
                throw new Exception("Failed to load AssetBundle!");
            }

            // We check again for concurrency reasons
            _assetBundles.Add(lowerName, bundle);
            */
        }

        return _assetBundles[lowerName];
    }

    public async Task<T> LoadAsset<T>(string assetBundleName, string assetName) where T : UnityEngine.Object
    {
        if (!_init) await Init();

        var bundle = await GetBundle(assetBundleName);
        var asset = bundle.LoadAsset<T>(assetName);
        if (asset == null) Debug.LogError("Failed to load Asset {0} from {1} ({2})");
        return asset;
    }
}