
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestAssetInfo : GLBLoaderTest
{
    public override void Test()
    {
        Debug.Log("<color=pink>Test 1</color>");
        Transform rootTransform = loader.mainParent;
        Assert(rootTransform.childCount == 1, "One child should be spawned");

        Transform firstChildTransform = rootTransform.GetChild(0);
        Assert(firstChildTransform.name == "Cube", "The first child should be the root node, 'Cube'");

        GLTFAsset gltfAssetInfo = loader.assetInfoObject;

        string expectedVersion = "2.0";
        string expectedCopyright = "A very smart Hamster";
        string expectedMinVersion = "1.0";
        string expectedGenerator = "Blender !!!/!\\";

        Assert(gltfAssetInfo.version == expectedVersion,       $"The version should be {expectedVersion} (Actual : {gltfAssetInfo.version})");        
        Assert(gltfAssetInfo.minVersion == expectedMinVersion, $"The min version should be {expectedMinVersion} (Actual : {gltfAssetInfo.minVersion})");
        Assert(gltfAssetInfo.copyright == expectedCopyright,   $"The copyright should be {expectedCopyright} (Actual : {gltfAssetInfo.copyright})");
        Assert(gltfAssetInfo.generator == expectedGenerator,   $"The generator should be {expectedGenerator} (Actual : {gltfAssetInfo.generator})");

    }
}
