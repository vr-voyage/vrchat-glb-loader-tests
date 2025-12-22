
using UnityEngine;

public class TestMaterialsTransparency : GLBLoaderTest
{

    object[] expectedMaterialsProperties =
    {
        new object[]
        {
            "MatOpaque",
            new object[] // Texture Properties
            {

            },
            new object[] // Material Properties
            {
                new object[] { typeof(Color), "_Color", new Color(0.75f, 0.5f, 0.25f, 1.0f) },
                new object[] { typeof(float), "_Metallic", 0f },
                new object[] { typeof(float), "_Glossiness", 0.5f }
            },
            new object[] // Tags
            {

            }
        },
        new object[]
        {
            "MatAlphaMask",
            new object[] // Texture Properties
            {
                new object[] { "_MainTex", "ripped-paper-2" }
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_Cutoff", 0.75f },
                new object[] { typeof(float), "_Glossiness", 1.0f - 0.125f }
            },
            new object[] // Tags
            {
                new object[] { "RenderType", "TransparentCutout" }
            }
        },
        new object[]
        {
            "MatAlphaBlend",
            new object[] // Texture Properties
            {
                new object[] { "_MainTex", "TextHints2" }
            },
            new object[] // Material Properties
            {

            },
            new object[] // Tags
            {
                new object[] { "RenderType", "Transparent" }
            }
        },
        new object[]
        {
            "MetallicTexture",
            new object[] // Texture Properties
            {
                new object[] { "_MetallicGlossMap", "MetalRougnessAO" }
            },
            new object[] // Material Properties
            {
                new object[] { typeof(Color), "_Color", new Color(1f, 1f, 1f, 1f) },
                new object[] { typeof(float), "_Metallic", 1f },
                new object[] { typeof(float), "_Glossiness", 1f - 0.375f }
            },
            new object[] // Tags
            {
            }
        },
        new object[]
        {
            "RoughnessTexture",
            new object[] // Texture Properties
            {
                new object[] { "_MetallicGlossMap", "MetalRougnessAO" }
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_Metallic", 0.875f },
                new object[] { typeof(float), "_Glossiness", 1f - 1f  }
            },
            new object[] // Tags
            {
            }
        },
        new object[]
        {
            "MetalRoughnessTexture",
            new object[] // Texture Properties
            {
                new object[] { "_MetallicGlossMap", "MetalRougnessAO" }
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_Metallic", 1f },
                new object[] { typeof(float), "_Glossiness", 1f - 1f }
            },
            new object[] // Tags
            {
            }
        },
        new object[]
        {
            "NormalTexture",
            new object[] // Texture Properties
            {
                new object[] { "_BumpMap", "Fabric038_1K_NormalGL" }
            },
            new object[] // Material Properties
            {

            },
            new object[] // Tags
            {
            }
        },
        new object[]
        {
            "EmissiveTexture",
            new object[] // Texture Properties
            {
                new object[] { "_EmissionMap", "8x8" }
            },
            new object[] // Material Properties
            {

            },
            new object[] // Tags
            {
            }
        },
        new object[]
        {
            "OcclusionTexture",
            new object[] // Texture Properties
            {
                new object[] { "_OcclusionMap", "MetalRougnessAO" }
            },
            new object[] // Material Properties
            {

            },
            new object[] // Tags
            {
            }
        }
    };

    const int textureSlotNameIndex = 0;
    const int textureNameIndex = 1;
    void CheckTextureSlot(Material material, object[] expectedSlotConfiguration)
    {
        string materialName = material.name;
        string slotName = (string)expectedSlotConfiguration[textureSlotNameIndex];
        Texture texture = material.GetTexture(slotName);
        Assert(texture != null, $"Material {materialName} should have a texture set to {slotName}");

        string expectedTextureName = (string)expectedSlotConfiguration[textureNameIndex];
        string actualTextureName = texture.name;
        Assert(expectedTextureName == actualTextureName, $"{materialName}.{slotName} texture name should be {expectedTextureName} (currently {actualTextureName})");
    }
    void CheckTexturesSlots(Material material, object[] expectedSlotsInfo)
    {
        int nSlots = expectedSlotsInfo.Length;
        for (int i = 0; i < nSlots; i++)
        {
            CheckTextureSlot(material, (object[])expectedSlotsInfo[i]);
        }
    }

    const int propertyTypeIndex = 0;
    const int propertyNameIndex = 1;
    const int propertyValueIndex = 2;
    void CheckProperty(Material material, object[] propertyInfo)
    {
        string materialName = material.name;
        System.Type propertyType = (System.Type)propertyInfo[propertyTypeIndex];
        string propertyName = (string)propertyInfo[propertyNameIndex];
        if (propertyType == typeof(float))
        {
            float expectedValue = (float)propertyInfo[propertyValueIndex];
            float actualValue = material.GetFloat(propertyName);
            Assert(expectedValue == actualValue, $"{materialName}.{propertyName} should be {expectedValue} (Current : {actualValue})");
        }
        else if (propertyType == typeof(int))
        {
            int expectedValue = (int)propertyInfo[propertyValueIndex];
            int actualValue = material.GetInt(propertyName);
            Assert(expectedValue == actualValue, $"{materialName}.{propertyName} should be {expectedValue} (Current : {actualValue})");
        }
        else if (propertyType == typeof(Color))
        {
            Color expectedValue = (Color)propertyInfo[propertyValueIndex];
            Color actualValue = material.GetColor(propertyName);
            Assert(expectedValue == actualValue, $"{materialName}.{propertyName} should be {expectedValue} (Current : {actualValue})");
        }
    }
    void CheckProperties(Material material, object[] propertiesInfo)
    {
        int nProperties = propertiesInfo.Length;
        for (int i = 0; i < nProperties; i++)
        {
            CheckProperty(material, (object[])propertiesInfo[i]);
        }
    }

    const int tagNameIndex = 0;
    const int tagValueIndex = 1;

    void CheckTag(Material material, object[] tagInfo)
    {
        string materialName = material.name;
        string tagName = (string)tagInfo[tagNameIndex];
        string expectedTagValue = (string)tagInfo[tagValueIndex];
        string actualTagValue = material.GetTag(tagName, false);
        Assert(expectedTagValue == actualTagValue, $"{materialName}.{tagName} tag value should be {expectedTagValue} (actual : {actualTagValue})");
    }

    void CheckTags(Material material, object[] tagsInfo)
    {
        int nTags = tagsInfo.Length;
        for (int t = 0; t < nTags; t++)
        {
            CheckTag(material, (object[])tagsInfo[t]);
        }
    }

    void CheckMaterialName(Material material, string expectedName)
    {
        Assert(material.name == expectedName, $"Expected material name to be {expectedName} (Current : {material.name})");
    }

    int materialExpectedNameIndex = 0;
    int materialTexturesExpectationsIndex = 1;
    int materialPropertiesExpectationsIndex = 2;
    int materialTagsExpectationsIndex = 3;
    void CheckMaterialProperties(Material material, object[] materialExpectations)
    {
        CheckMaterialName(material, (string)materialExpectations[materialExpectedNameIndex]);
        CheckTexturesSlots(material, (object[])materialExpectations[materialTexturesExpectationsIndex]);
        CheckProperties(material, (object[])materialExpectations[materialPropertiesExpectationsIndex]);
        CheckTags(material, (object[])materialExpectations[materialTagsExpectationsIndex]);
    }

    public override void Test()
    {
        Debug.Log("<color=pink>Test 2</color>");

        Transform loaderRoot = loader.mainParent;
        Assert(loaderRoot != null, "Assert that the root is defined !");
        Assert(loaderRoot.childCount == 1, "Only one scene loaded");

        Transform rootObject = loaderRoot.GetChild(0);
        Assert(rootObject.name == "Cube", "The cube should be loaded");

        GameObject rootGo = rootObject.gameObject;
        MeshRenderer renderer = rootGo.GetComponent<MeshRenderer>();
        Assert(renderer != null, "A renderer should be available");

        Material[] sharedMaterials = renderer.sharedMaterials;
        Assert(sharedMaterials.Length == expectedMaterialsProperties.Length, 
            $"{expectedMaterialsProperties.Length} materials should be loaded");

        for (int m = 0; m < sharedMaterials.Length; m++)
        {
            CheckMaterialProperties(sharedMaterials[m], (object[])expectedMaterialsProperties[m]);
        }



        /*Texture mainTex = matAlphaMask.GetTexture("_MainTex");
        Assert(mainTex != null, "The main texture should be set !");
        Assert(mainTex.name == "ripped-paper-1", "Ripped paper");
        float cutOffValue = matAlphaMask.GetFloat("_Cutoff");
        Assert(cutOffValue == 0.75f, $"Cutoff should be 0.75f but was {cutOffValue}");
        string renderTypeTag = matAlphaMask.GetTag("RenderType", false);
        Assert(renderTypeTag == "TransparentCutout", $"The Alpha mask material render type should be TransparentCutout (current : {renderTypeTag})");*/



    }
}
