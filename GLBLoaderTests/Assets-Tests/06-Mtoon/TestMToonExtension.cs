
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestMToonExtension : GLBLoaderTest
{
    object[] expectedMaterialsProperties =
    {
        new object[]
        {
            "MainFeatures",
            new object[] // Texture Properties
            {
                new object[] { "_ShadeTex", "Carrelage-noir_metal_smoothness", new Vector2(0.25f,0.25f), new Vector2(1.25f, 2.25f) },
                new object[] { "_MatcapTex", "briques_normal", new Vector2(0.125f,0.125f), new Vector2(0.5f, 0.125f) },
                new object[] { "_RimTex", "briques_occlusion", new Vector2(0.625f,0.75f), new Vector2(0.25f, 0.75f) },
                new object[] { "_OutlineWidthTex", "briques_height", new Vector2(0.125f,0.25f), new Vector2(1, 1) },
                new object[] { "_UvAnimMaskTex", "briques_normal", new Vector2(0,0), new Vector2(0.125f, 0.25f) },
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_TransparentWithZWrite", 1 },
                new object[] { typeof(float), "_RenderQueueOffset", 9 },
                new object[] { typeof(Color), "_ShadeColor", new Color(0.25f, 0.5f, 0.75f, 1.0f) },
                new object[] { typeof(float), "_ShadingShiftFactor", 3.125f },
                new object[] { typeof(float), "_ShadingToonyFactor", 0.125f },
                new object[] { typeof(float), "_GiEqualization", 0.625f },
                new object[] { typeof(Color), "_MatcapColor", new Color(0.125f, 0.375f, 0.875f, 1.0f) },
                new object[] { typeof(Color), "_RimColor", new Color(0.625f, 0.125f, 0.75f, 1.0f) },
                new object[] { typeof(float), "_RimLightingMix", 0.375f },
                new object[] { typeof(float), "_RimFresnelPower", 7.25f },
                new object[] { typeof(float), "_RimLift", -0.25f },
                new object[] { typeof(float), "_OutlineWidthMode", 1 },
                new object[] { typeof(float), "_OutlineWidth", 2.25f },
                new object[] { typeof(float), "_OutlineLightingMix", 0.5f },
                new object[] { typeof(Color), "_OutlineColor", new Color(0.125f, 0.25f, 0.375f, 1.0f) },
                new object[] { typeof(float), "_UvAnimScrollXSpeed", -0.125f },
                new object[] { typeof(float), "_UvAnimScrollYSpeed", -0.25f },
                new object[] { typeof(float), "_UvAnimRotationSpeed", -2.25f },
            },
            new object[] // Tags
            {

            },
            new string[] // EnabledKeywords
            {
                "_MTOON_PARAMETERMAP",
                "_MTOON_RIMMAP",
                "_MTOON_OUTLINE_WORLD"
            }
        },
        new object[]
        {
            "Default",
            new object[] // Texture Properties
            {
                new object[] { "_ShadeTex", null },
                new object[] { "_MatcapTex", null },
                new object[] { "_RimTex", null },
                new object[] { "_OutlineWidthTex", null },
                new object[] { "_UvAnimMaskTex", null },
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_TransparentWithZWrite", 0 },
                new object[] { typeof(float), "_RenderQueueOffset", 0 },
                new object[] { typeof(Color), "_ShadeColor", new Color(1,1,1,1) },
                new object[] { typeof(float), "_ShadingShiftFactor", 0 },
                new object[] { typeof(float), "_ShadingToonyFactor", 0.9f },
                new object[] { typeof(float), "_GiEqualization", 0.9f },
                new object[] { typeof(Color), "_MatcapColor", new Color(0,0,0,1) },
                new object[] { typeof(Color), "_RimColor", new Color(0,0,0,1) },
                new object[] { typeof(float), "_RimLightingMix", 1 },
                new object[] { typeof(float), "_RimFresnelPower", 5 },
                new object[] { typeof(float), "_RimLift", 0 },
                new object[] { typeof(float), "_OutlineWidthMode", 0 },
                new object[] { typeof(float), "_OutlineWidth", 0 },
                new object[] { typeof(float), "_OutlineLightingMix", 1 },
                new object[] { typeof(Color), "_OutlineColor", new Color(0,0,0,1) },
                new object[] { typeof(float), "_UvAnimScrollXSpeed", 0 },
                new object[] { typeof(float), "_UvAnimScrollYSpeed", 0 },
                new object[] { typeof(float), "_UvAnimRotationSpeed", 0 },
            },
            new object[] // Tags
            {

            },
            new string[] // EnabledKeywords
            {
            }
        },
        new object[]
        {
            "NegativeValues",
            new object[] // Texture Properties
            {
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_TransparentWithZWrite", 0 },
                new object[] { typeof(float), "_RenderQueueOffset", -9 },
                new object[] { typeof(float), "_ShadingShiftFactor", -10 },
                new object[] { typeof(float), "_OutlineWidthMode", 2 },
                new object[] { typeof(float), "_UvAnimRotationSpeed", -25 },
            },
            new object[] // Tags
            {

            },
            new string[] // EnabledKeywords
            {
                "_MTOON_OUTLINE_SCREEN"
            }
        },
        new object[]
        {
            "OutOfRangeValues",
            new object[] // Texture Properties
            {
                new object[] { "_ShadeTex", null },
                new object[] { "_MatcapTex", null },
                new object[] { "_RimTex", null },
                new object[] { "_OutlineWidthTex", null },
                new object[] { "_UvAnimMaskTex", null },
            },
            new object[] // Material Properties
            {
                new object[] { typeof(float), "_RenderQueueOffset", 9 },
                new object[] { typeof(Color), "_ShadeColor", new Color(1, 1, 1, 1) },
                new object[] { typeof(float), "_ShadingShiftFactor", 0 },
                new object[] { typeof(float), "_ShadingToonyFactor", 0 },
                new object[] { typeof(float), "_GiEqualization", 1 },
                new object[] { typeof(Color), "_MatcapColor", new Color(0,1,1, 1) },
                new object[] { typeof(Color), "_RimColor", new Color(0, 1, 0, 1) },
                new object[] { typeof(float), "_RimLightingMix", 1 },
                new object[] { typeof(float), "_RimFresnelPower", 7.25f },
                new object[] { typeof(float), "_OutlineWidthMode", 0 },
                new object[] { typeof(float), "_OutlineWidth", 0 },
                new object[] { typeof(float), "_OutlineLightingMix", 1 },
                new object[] { typeof(Color), "_OutlineColor", new Color(0, 0, 0, 1) },
            },
            new object[] // Tags
            {

            },
            new string[] // EnabledKeywords
            {
            }
        },
    };

    const int textureSlotNameIndex = 0;
    const int textureNameIndex = 1;
    const int textureOffsetIndex = 2;
    const int textureScaleIndex = 3;
    void CheckTextureSlot(Material material, object[] expectedSlotConfiguration)
    {
        string materialName = material.name;
        string slotName = (string)expectedSlotConfiguration[textureSlotNameIndex];
        string expectedTextureName = (string)expectedSlotConfiguration[textureNameIndex];
        Texture texture = material.GetTexture(slotName);

        if (expectedTextureName != null)
        {
            Assert(texture != null, $"Material {materialName} should have a texture set to {slotName}");
            string actualTextureName = texture.name;
            Assert(expectedTextureName == actualTextureName, $"{materialName}.{slotName} texture name should be {expectedTextureName} (currently {actualTextureName})");

            Vector2 expectedTextureOffset = (Vector2)expectedSlotConfiguration[textureOffsetIndex];
            Vector2 expectedTextureScale = (Vector2)expectedSlotConfiguration[textureScaleIndex];

            Vector2 actualTextureOffset = material.GetTextureOffset(slotName);
            Vector2 actualTextureScale = material.GetTextureScale(slotName);

            Assert(expectedTextureOffset == actualTextureOffset, $"The texture Offset should be {expectedTextureOffset} (Actual : {actualTextureOffset})");
            Assert(expectedTextureScale == actualTextureScale, $"The texture Scale should be {expectedTextureScale} (Actual : {actualTextureScale})");
        }
        else
        {
            Assert(texture == null, $"Expecting {materialName}.{slotName} to be null");
        }

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
        Debug.LogWarning(expectedName);
        Assert(material.name == expectedName, $"Expected material name to be {expectedName} (Current : {material.name})");
    }

    void CheckKeywords(Material material, string[] expectedKeywords)
    {
        int nKeywords = expectedKeywords.Length;
        for (int k = 0; k < nKeywords; k++)
        {
            string expectedEnabledKeyword = expectedKeywords[k];
            bool isKeywordEnabled = material.IsKeywordEnabled(expectedEnabledKeyword);
            Assert(isKeywordEnabled == true, $"Expecting keyword to be enabled {expectedEnabledKeyword} (Actual : {isKeywordEnabled})");
        }
    }

    int materialExpectedNameIndex = 0;
    int materialTexturesExpectationsIndex = 1;
    int materialPropertiesExpectationsIndex = 2;
    int materialTagsExpectationsIndex = 3;
    int materialKeywordsExpectationsIndex = 4;
    void CheckMaterialProperties(Material material, object[] materialExpectations)
    {
        CheckMaterialName(material, (string)materialExpectations[materialExpectedNameIndex]);
        CheckTexturesSlots(material, (object[])materialExpectations[materialTexturesExpectationsIndex]);
        CheckProperties(material, (object[])materialExpectations[materialPropertiesExpectationsIndex]);
        CheckTags(material, (object[])materialExpectations[materialTagsExpectationsIndex]);
        CheckKeywords(material, (string[])materialExpectations[materialKeywordsExpectationsIndex]);
    }

    public override void Test()
    {
        Debug.Log("<color=pink>Test 1</color>");
        Transform rootTransform = loader.mainParent;

        int expectedRootNodesCount = 1;
        int nChildren = rootTransform.childCount;
        Assert(nChildren == expectedRootNodesCount, $"{expectedRootNodesCount} root node should be present (Actual : {nChildren})");

        string expectedRootNodeName = "Cube";
        Transform mainRootNode = rootTransform.GetChild(0);
        Assert(mainRootNode.name == expectedRootNodeName, $"The second root Node should be '{expectedRootNodeName}'");

        MeshRenderer cubeMeshRenderer = mainRootNode.GetComponent<MeshRenderer>();
        Assert(cubeMeshRenderer != null, $"The {expectedRootNodeName} have a Mesh Renderer");

        Material[] materials = cubeMeshRenderer.sharedMaterials;
        Assert(materials != null, $"The {expectedRootNodeName} Mesh Renderer have materials set to it");

        int nMaterials = materials.Length;
        int expectedMaterialsCount = expectedMaterialsProperties.Length;

        Assert(nMaterials == expectedMaterialsCount, $"Expected {nMaterials} materials (Actual : {expectedMaterialsCount})");

        for (int m = 0; m < nMaterials; m++)
        {
            object[] expectedMaterialProperties = (object[])expectedMaterialsProperties[m];
            Material material = materials[m];
            CheckMaterialProperties(material, expectedMaterialProperties);
        }
    }
}
