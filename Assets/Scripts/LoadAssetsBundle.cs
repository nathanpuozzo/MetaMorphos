using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetsBundle : MonoBehaviour
{

    AssetBundle myLoadedAssetbundle;
    public string path;
    public string assetName;
    public string assetName2;

    // Start is called before the first frame update
    void Start()
    {
        LoadAssetBundle(path);
        instantiateObjectFromBundle(assetName);
        instantiateObjectFromBundle(assetName2);
    }

    // Update is called once per frame
    void LoadAssetBundle(string bundleUrl)
    {
        myLoadedAssetbundle = AssetBundle.LoadFromFile(bundleUrl);

        Debug.Log(myLoadedAssetbundle == null ? "Failed to load AssetBundle" : "AssetBundle succesfully loaded");

    }

    void instantiateObjectFromBundle(string assetName)
    {

        var prefab = myLoadedAssetbundle.LoadAsset(assetName);
        Instantiate(prefab);

    }
}
