using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource[] _sounds;

    public void Play(string name)
    {
        AudioSource snd = null;

        for (int 회 = 0; 회 < _sounds.Length; 회++)
        {

            snd = _sounds[회];



            if (snd.name == name)
            {
                Debug.Log(snd.name);
                snd.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
