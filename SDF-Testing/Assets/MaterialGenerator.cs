using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class MaterialGenerator : MonoBehaviour
{
    public static string fileName;
    public static string textureFolder;
    [MenuItem("GameObject/Create Material")]
    static void CreateMaterial()
    {
        string[] fileNames = Directory.GetFiles(textureFolder);
        // Create a simple material asset
        foreach (string t in fileNames){
            Material material = new Material(Shader.Find("Specular"));
            AssetDatabase.CreateAsset(material, "Resources/Holograms/"+fileName+"/Materials/"+ fileName + ".mat");

            // Print the path of the created asset
            Debug.Log(AssetDatabase.GetAssetPath(material));
            }
    }
}
