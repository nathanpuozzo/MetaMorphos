using UnityEngine;

namespace AssetBundles
{
    public class Example1 : MonoBehaviour
    {
        private AssetBundleManager abm;

        private void Start()
        {
            abm = new AssetBundleManager();
            abm.UseSimulatedUri();
            abm.Initialize(OnAssetBundleManagerInitialized);
        }

        private void OnAssetBundleManagerInitialized(bool success)
        {
            if (success) {
                abm.GetBundle("mouchescene", OnAssetBundleDownloaded);
            } else {
                Debug.LogError("Error initializing ABM.");
            }
        }

        private void OnAssetBundleDownloaded(AssetBundle bundle)
        {
            if (bundle != null) {
                // Do something with the bundle
                abm.UnloadBundle(bundle);
            }

            abm.Dispose();
        }
    }
}