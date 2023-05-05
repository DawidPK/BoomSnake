using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public AudioSource music;

    public void muteVolume()
    {
        music.enabled = !music.enabled;
    }
}
