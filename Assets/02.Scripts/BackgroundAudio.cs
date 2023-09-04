using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public static BackgroundAudio Instance;

    public AudioSource audioSource;
    public GameObject bgm;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        bgm.SetActive(true);
        audioSource.Play();
    }

    public void BgmOff()
    {
        bgm.SetActive(false);
    }
}
