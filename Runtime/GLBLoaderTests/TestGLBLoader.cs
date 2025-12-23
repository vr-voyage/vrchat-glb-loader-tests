using UdonSharp;
using UnityEngine;
using VoyageVoyage;
using VRC.SDKBase;
using VRC.Udon;

public class TestGLBLoader : UdonSharpBehaviour
{
    public GLBLoader testedLoader;

    public GLBLoaderTest[] testScripts;
    public int currentTestIndex = 0;
    int nTests = 0;
    float timeout = 0f;
    const float testTimeoutInSeconds = 3.0f;

    bool testSuiteTimeout = false;

    public TextAsset asset;

    bool testRunning = false;

    void DelayTimeout(float nSeconds)
    {
        timeout = CurrentTime() + nSeconds;
    }

    public void CurrentTestFailed()
    {
        testRunning = false;
    }

    public void CurrentTestPassed()
    {
        testRunning = false;
        NextTest();
    }

    void NextTest()
    {
        if (testSuiteTimeout) { Debug.Log("Last test took too much time to run"); return; }
        currentTestIndex += 1;
        SendCustomEventDelayedSeconds(nameof(TestGLBLoader.RunCurrentTestIndexTest), 2);
    }

    float CurrentTime()
    {
        return Time.fixedTime;
    }

    public void RunCurrentTestIndexTest()
    {
        if (currentTestIndex < nTests)
        {
            GLBLoaderTest test = testScripts[currentTestIndex];
            if (test == null)
            {
                Debug.LogWarning($"Test {currentTestIndex} was null ???");
                NextTest();
            }

            testedLoader.Clear();

            test.loader = testedLoader;
            test.testRunner = this;

            DelayTimeout(testTimeoutInSeconds);

            test.SendCustomEvent(nameof(GLBLoaderTest.StartTest));

            testRunning = true;
        }
        else
        {
            Debug.Log("<color=lime>TEST SUITE COMPLETED !</color>");
            TestSuiteCompleted();
        }
    
    }

    void TestSuiteStart()
    {
        nTests = testScripts.Length;
        currentTestIndex = 0;
        Debug.Log($"Starting {nTests}");
        RunCurrentTestIndexTest();
    }

    void TestSuiteCompleted()
    {
        enabled = false;
        DelayTimeout(99.0f);
        Debug.Log($"<color=cyan>Test suite completed. {nTests} tests completed !</color>");
    }


    void RunTests()
    {
        Debug.Log("<color=orange>GLBLoaderTest : Running test suite</color>");
    }

    // Start is called before the first frame update
    void Start()
    {
        timeout = CurrentTime() + testTimeoutInSeconds;
        if (testedLoader == null)
        {
            Debug.LogError($"[{name}] [{this.GetType().Name}] testedLoader not set. Disabling.");
            gameObject.SetActive(false);
            return;
        }

        TestSuiteStart();
    }

    private void Update()
    {
        if (!testRunning) { return; }
        testSuiteTimeout = (CurrentTime() > timeout);
        if (testSuiteTimeout)
        {
            Debug.LogError($"Timeout while running test {currentTestIndex}");
            enabled = false;
        }
    }

}
