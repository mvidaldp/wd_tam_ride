﻿using System.Collections;
using UnityEngine;

/// <summary>
/// Loads the First announcement and loads the City in the background
/// </summary>
public class ExperimentLoader : MonoBehaviour
{
    private bool startSceneLoad = false;

    public bool isLoading
    {
        get { return startSceneLoad; }
    }

    [Header("Components")]
    //public VideoPlayer loadingVideoOne;
    //public VideoPlayer loadingVideoTwo;
    public GameObject mainCamera;

    public CanvasGroup screen;
    public GameObject loader;

    [Space] [Header("parameters")] [Range(0, 1)]
    public float fadeSpeed = 0.05f;

    public float frameWaitSpeed = 0.01f;
    public float pauseForFirstVideo = 10f;

    public float logoPauseTime = 3f;

    // Stops all coroutines and loads the startNewScene Method
    private void Awake()
    {
        StopAllCoroutines();

        //Invoke("StartNewScene", logoPauseTime);
        StartCoroutine(StartNewScene());
    }

    //Starts the new Scene and loads the City in the background
    IEnumerator StartNewScene()
    {
        if (!startSceneLoad)
        {
            Debug.Log("Input Detected!");
            startSceneLoad = true;
            StartCoroutine(loadCityAsync());
            yield return null;
        }
    }

    //loads the City in the background without switching scenes
    IEnumerator loadCityAsync()
    {
        Debug.Log("Loading coroutine started");
        /*float fadeAlpha = 1f;
        while(fadeAlpha >=0f)
        {
            screen.alpha = fadeAlpha;
            fadeAlpha -= fadeSpeed;
            yield return new WaitForSeconds(frameWaitSpeed);
        }
        screen.alpha = 0f;
        fadeAlpha = 0f;
        yield return new WaitForEndOfFrame();
        */

        Debug.Log("loading city scene in background started");
        loader.GetComponent<Valve.VR.SteamVR_LoadLevel>().Trigger();
        yield return null;
    }

    //stops all Coroutines
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}