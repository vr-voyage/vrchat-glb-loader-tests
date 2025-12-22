
using Newtonsoft.Json.Linq;
using System.Drawing;
using UdonSharp;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using VoyageVoyage;
using VRC.SDKBase;
using VRC.Udon;

public abstract class GLBLoaderTest : UdonSharpBehaviour
{
    public TestGLBLoader testRunner;

    public GLBLoader loader;

    public TextAsset testData;

    bool error = false;

    void StatusReport(string status, bool ok)
    {
        if (ok)
        {
            Debug.Log($"<color=lime>{status} : OK</color>");
        }
        else
        {
            Debug.Log($"<color=red>{status} : FAILED</color>");
            TestFailed();
        }
    }

    public void Assert(bool value, string reason)
    {
        StatusReport(reason, value == true);
    }

    void TestFailed()
    {
        error = true;
        testRunner.SendCustomEvent(nameof(TestGLBLoader.CurrentTestFailed));
    }

    void TestComplete()
    {
        testRunner.SendCustomEvent(nameof(TestGLBLoader.CurrentTestPassed));
    }

    public abstract void Test();

    public void SceneLoaded()
    {
        Test();
        if (!error) { TestComplete(); }
    }
    public void StartTest()
    {
        Assert(loader != null, "The GLB Loader should be available for the test");
        
        loader.stateReceivers = new UdonSharpBehaviour[] { this };
        loader.StartParsingGlb(testData.bytes);
        Debug.Log($"Started to parse GLB for {gameObject.name}");
    }
}
