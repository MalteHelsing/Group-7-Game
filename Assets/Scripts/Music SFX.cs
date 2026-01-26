using UnityEngine;

public class MusicSFX : MonoBehaviour
{
    [Header("1")]
    [SerializeField] AudioClip one;
    [SerializeField, Range(0, 1)] float oneVolume;

    [Header("2")]
    [SerializeField] AudioClip two;
    [SerializeField, Range(0, 1)] float twoVolume;
}
