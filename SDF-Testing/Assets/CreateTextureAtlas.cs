using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTextureAtlas : MonoBehaviour
{
    // Source textures.
    Texture2D[] atlasTextures;

    private Texture[] textures;
    // Rectangles for individual atlas textures.
    Rect[] rects;

    void Start()
    {
        // Pack the individual textures into the smallest possible space,
        // while leaving a two pixel gap between their edges.
  //      textures = Resources.LoadAll("SDFs", typeof(Texture));

   //     Texture2D atlas = new Texture2D(8192, 8192);
    //    textures = atlas.PackTextures((Texture2D)textures, 2, 8192);
    }
}