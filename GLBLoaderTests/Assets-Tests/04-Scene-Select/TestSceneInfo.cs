
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestSceneInfo : GLBLoaderTest
{
    readonly string[] expectedRootNodesNames = { "01-Cube", "02-Sphere", "03-Icosphere", "04-Cone" };
    readonly object[] expectedScenes =
    {
        new object[]
        {
            "Cube only", new string[] { "01-Cube" }
        },
        new object[]
        {
            "Spheres only", new string[] { "02-Sphere", "03-Icosphere" }
        },
        new object[]
        {
            "The Pyramid and Cube", new string[] { "01-Cube", "04-Cone" }
        },
        new object[]
        {
            "Everything", new string[] { "01-Cube", "02-Sphere", "03-Icosphere", "04-Cone" }
        }
    };

    const int expectedSceneNameIndex = 0;
    const int expectedSceneNodeNamesIndex = 1;

    void CheckScene(Transform gltfSceneTransform, object[] expectedSceneData, int sceneIndex)
    {
        GameObject gltfSceneGo = gltfSceneTransform.gameObject;

        GLTFScene checkScene = gltfSceneGo.GetComponent<GLTFScene>();
        Assert(checkScene != null, $"The gameobject representing the Scene {sceneIndex} should have a GLTFScene component");


        string expectedName = (string)expectedSceneData[expectedSceneNameIndex];
        string[] sceneNodesNames = (string[])expectedSceneData[expectedSceneNodeNamesIndex];
        GameObject[] definedNodes = checkScene.nodes;

        Assert(checkScene.sceneName != null, $"Scene {sceneIndex} name should be {expectedName} (Actual : {checkScene.sceneName})");
        int nNodesExpected = sceneNodesNames.Length;
        int nNodesDefined = definedNodes.Length;
        Assert(nNodesExpected == nNodesDefined, $"Scene {sceneIndex} should have {nNodesExpected} nodes defined (Actual : {nNodesDefined})");
        for (int n = 0; n < nNodesExpected; n++)
        {
            string expectedNodeName = sceneNodesNames[n];
            GameObject referencedNode = definedNodes[n];
            Assert(referencedNode != null, $"The node Scene {sceneIndex}.nodes[{n}] must not be null");

            string referencedNodeName = referencedNode.name;
            Assert(referencedNodeName == expectedNodeName, $"Scene {sceneIndex}.nodes[{n}] name should be {expectedNodeName} (Actual: {referencedNodeName})");
        }
    }

    public override void Test()
    {
        Debug.Log("<color=pink>Test 1</color>");
        Transform rootTransform = loader.mainParent;
        Assert(rootTransform.childCount == expectedRootNodesNames.Length, "One child should be spawned");

        int nExpectedNodes = expectedRootNodesNames.Length;
        for (int n = 0; n < nExpectedNodes; n++)
        {
            Transform rootNode = rootTransform.GetChild(n);
            string expectedRootNodeName = expectedRootNodesNames[n];
            Assert(rootNode.name == expectedRootNodeName, $"Root node {n} name should be {expectedRootNodeName} (Actual : {rootNode.name})");
        }

        Transform scenesInfoRoot = loader.scenesInfoRoot;
        Assert(scenesInfoRoot != null, "The Scenes Info root transform must be defined");

        int nScenes = scenesInfoRoot.childCount;
        Assert(nScenes == 4, $"4 scenes defined in this GLB. The loader defined {nScenes} scenes");

        for (int s = 0; s < nScenes; s++)
        {
            CheckScene(scenesInfoRoot.GetChild(s), (object[])expectedScenes[s], s);
        }

    }
}
