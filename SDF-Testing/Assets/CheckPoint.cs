using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{ 
    public Camera cam;
    private AudioClip[] verbalDes;

    List<AudioSource> audioSources = new List<AudioSource>();
    AudioSource[] sources;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Mouse Input for testing, Change to Finger Input for Quest 3 //
        if (!Input.GetMouseButton(0))
            return;

        RaycastHit hit;
        if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
            return;
        // Mouse Input for testing, Change to Finger Input for Quest 3 //

        // Listen for raycast hit, grab the render component of any object it hits
        Renderer rend = hit.transform.GetComponent<Renderer>();

        //Snag the mesh collider, this 
        MeshCollider meshCollider = hit.collider as MeshCollider;
        sources = rend.GetComponents<AudioSource>();
        if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
            return;

        Material[] materials = rend.materials; 

        int count = 0;
        if(sources.Length > 0){
            foreach(Material m in materials){
                Texture2D tex = m.mainTexture as Texture2D;
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;
                //Debug.Log("pixelUV is : "+tex.GetPixel((int)pixelUV.x,(int) pixelUV.y));
                float sdfValue = tex.GetPixel((int)pixelUV.x,(int)pixelUV.y).r;
                sources[count].volume = sdfValue;
                Debug.Log("sdf: "+sdfValue);
                count++;
                
            }
        }
    }
}

