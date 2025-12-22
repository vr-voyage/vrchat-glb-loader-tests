
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestBlenderDefaultCube : GLBLoaderTest
{
    public override void Test()
    {
        Debug.Log("<color=pink>Test 1</color>");
        Transform rootTransform = loader.mainParent;
        Assert(rootTransform.childCount == 1, "One child should be spawned");

        Transform firstChildTransform = rootTransform.GetChild(0);
        Assert(firstChildTransform.name == "Cube", "The first child should be the root node, 'Cube'");

        GameObject cube = firstChildTransform.gameObject;
        MeshRenderer renderer = cube.GetComponent<MeshRenderer>();
        Assert(renderer != null, "A Mesh renderer is present");

        var materials = renderer.sharedMaterials;
        Assert(materials.Length == 1, "One material is present");

        MeshFilter filter = cube.GetComponent<MeshFilter>();
        Assert(filter != null, "A Mesh filter is present");

        Mesh mesh = filter.sharedMesh;

        Assert(mesh != null, "A mesh is present");
        Assert(mesh.name == "Cube", "The mesh name is 'Cube'");
        Assert(mesh.subMeshCount == 1, "Only one submesh present");
    }
}
