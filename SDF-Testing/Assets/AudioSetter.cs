using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetter : MonoBehaviour
{
    public AudioClip[] verbalDes;
    List<AudioSource> audioSources = new List<AudioSource>();
    AudioSource[] sources;
    private string objName; // Must match the name of the folder

    void Start()
    {
        objName = transform.parent.name;

        verbalDes = Resources.LoadAll<AudioClip>("Holograms/"+objName+"/Audio");

        int counter = 0;
        for (int i = 0; i < verbalDes.Length; i++)
        {
            AudioSource asrc = this.gameObject.AddComponent<AudioSource>();
            asrc.clip = verbalDes[counter];
            asrc.loop = true;
            asrc.volume = 0;
            audioSources.Add(asrc);
            counter++;
        }
        int c = 0;
        foreach (AudioSource asrc in audioSources)
        {
            Debug.Log("Playing "+c);
            asrc.Play();
            c++;
        }
    }
}
