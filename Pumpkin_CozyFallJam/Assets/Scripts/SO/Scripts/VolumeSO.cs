using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Volume")]
public class VolumeSO : ScriptableObject
{
    public float musicVolume = 0.5f;
    public float sfxVolume = 0.5f;
}
