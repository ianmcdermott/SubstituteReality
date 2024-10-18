using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CatlikeCoding.SDFToolkit;
using System.IO;
public class SDFAutomator : MonoBehaviour
{
    private Object[] layers; // This will get the layers of the object from our resources folder
    public float maxInside, maxOutside, postProcessDistance; // Params for the SDf inner & outer fade and post process dist
    public RGBFillMode rgbMode = RGBFillMode.Distance; // Default our mode to distance 
    public string objName; // Name of the folder your object is saved in
    void Start()
    {
        Debug.Log("Generating SDFs, editor may freeze for a bit, especially for large files. Be patient");

        // Grab our original layer files from resources folder at designated path
        layers = Resources.LoadAll("Holograms/"+objName+"/Layers", typeof(Texture2D));

        // Loop through layers and create sdf files for each
        foreach(Texture2D t2d in layers){
            Texture2D source = (Texture2D) t2d;
            Texture2D destination = new Texture2D(t2d.width, t2d.height);

            // Catlike Coding's Generator function which incorporates our locations and sdf params
            SDFTextureGenerator.Generate(source, destination, maxInside, 
                         maxOutside, postProcessDistance, rgbMode);

            // Convert SDF texture to a PNG, destroy and export to our  
            byte[] bytes = destination.EncodeToPNG();
            Object.Destroy(destination);
            File.WriteAllBytes(Application.dataPath + "/../Assets/Resources/Holograms/"+
                                             objName+"/SDFs/"+source.name, bytes);
        }
        Debug.Log("SDFs Generated, Quitting Now");
        Application.Quit();
    }
}
