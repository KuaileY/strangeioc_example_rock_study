using System;
using UnityEditor;


namespace Assets.strangerocks
{
    [InitializeOnLoad]
    public class AddTagsAndLayers
    {

        static AddTagsAndLayers()
        {
            SerializedObject tagManager =
                new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);

            int startIndex = 10;
            int layerCount = 0;
            foreach (var layer in Enum.GetValues(typeof(MaskLayers)))
            {
                AddLayer(layer.ToString(), tagManager, startIndex + layerCount);
                layerCount++;
            }
        }

        static void AddLayer(string layer, SerializedObject tagManager, int index)
        {
            SerializedProperty layersProp = tagManager.FindProperty("layers");

            bool found = false;
            for (int i = 0; i < layersProp.arraySize; i++)
            {
                SerializedProperty t = layersProp.GetArrayElementAtIndex(i);
                if (t.stringValue.Equals(layer)) { found = true; break; }
            }
            if (!found)
            {
                SerializedProperty sp = layersProp.GetArrayElementAtIndex(index);
                if (sp != null) sp.stringValue = layer;
            }
            tagManager.ApplyModifiedProperties();
        }
    }
}
