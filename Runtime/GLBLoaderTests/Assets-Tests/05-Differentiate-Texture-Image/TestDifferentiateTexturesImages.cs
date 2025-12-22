
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestDifferentiateTexturesImages : GLBLoaderTest
{

    object[] expectedObjectAndMainTextureProperties =
    {
        new object[] { "Trilinear", FilterMode.Trilinear, TextureWrapMode.Clamp, TextureWrapMode.Mirror },
        new object[] { "Nearest", FilterMode.Point, TextureWrapMode.Repeat, TextureWrapMode.Repeat },
        new object[] { "Default", FilterMode.Bilinear, TextureWrapMode.Repeat, TextureWrapMode.Repeat }
    };

    const int nameIndex = 0;
    const int filterModeIndex = 1;
    const int wrapSIndex = 2;
    const int wrapTIndex = 3;

    const string mainTexName = "briques_albedo";

    void CheckRootNode(Transform rootNodeTransform, object[] expectedNameAndMainTexProperties)
    {
        string expectedName = (string)expectedNameAndMainTexProperties[nameIndex];
        FilterMode filterMode = (FilterMode)expectedNameAndMainTexProperties[filterModeIndex];
        TextureWrapMode wrapSMode = (TextureWrapMode)expectedNameAndMainTexProperties[wrapSIndex];
        TextureWrapMode wrapTMode = (TextureWrapMode)expectedNameAndMainTexProperties[wrapTIndex];

        Assert(rootNodeTransform != null, $"Expected the root node {expectedName} to not be null");
        GameObject rootNode = rootNodeTransform.gameObject;

        Assert(rootNode.name == expectedName, $"Expected this root node to be named {expectedName} (actual {rootNode.name})");

        MeshRenderer renderer = rootNode.GetComponent<MeshRenderer>();
        Assert(renderer != null, "Expecting a Mesh Renderer to be present on this node");

        Material[] materials = renderer.sharedMaterials;
        Assert(materials != null, "Expecting materials set on this Mesh");
        Assert(materials.Length == 1, $"Expecting exactly 1 material on this Mesh (actual {materials.Length})");

        Material mainMat = materials[0];
        Texture mainTex = mainMat.GetTexture("_MainTex");

        Assert(mainTex != null, "Expecting a main texture on the first material");
        Assert(mainTex.name == mainTexName, $"Expecting the main texture to be named {mainTexName} (Actual : {mainTex.name})");

        Assert(mainTex.filterMode == filterMode, $"Expecting the Filtering mode to be {filterMode} (Actual : {mainTex.filterMode})");
        Assert(mainTex.wrapModeU == wrapSMode, $"Expecting the Wrap Mode for the 'U' axis to be {wrapSMode} (Actual : {mainTex.wrapModeU})");
        Assert(mainTex.wrapModeV == wrapTMode, $"Expecting the Wrap Mode for the 'V' axis to be {wrapTMode} (Actual : {mainTex.wrapModeV})");
    }

    public override void Test()
    {
        Debug.Log("<color=pink>Test 1</color>");
        Transform rootTransform = loader.mainParent;
        Assert(rootTransform.childCount == 3, "Three root nodes should be present");

        int nExpectedObjects = expectedObjectAndMainTextureProperties.Length;
        for (int o = 0; o < nExpectedObjects; o++)
        {
            CheckRootNode(rootTransform.GetChild(o), (object[])expectedObjectAndMainTextureProperties[o]);
        }
        
    }
}
