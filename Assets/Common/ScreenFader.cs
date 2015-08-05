﻿using UnityEngine;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public float fadeSpeed = 1.5f;
    GUITexture _guiTexture;
    public bool FadeInEnded { get { return (_guiTexture.color == Color.clear); } }
    public bool FadeOutEnded { get { return (_guiTexture.color == Color.black); } }

    bool sceneStarting = true;
    bool sceneEnding = false;

    void Awake()
    {
        _guiTexture = GetComponent<GUITexture>();
        _guiTexture.pixelInset = new Rect(0, 0, Screen.width, Screen.height);
    }

    void Update()
    {
        if (sceneStarting)
        {
            StartScene();
        }
        else if (sceneEnding)
        {
            EndScene();
        }
    }

    void FadeToClear()
    {
        _guiTexture.color = Color.Lerp(_guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
    }
    void FadeToBlack()
    {
        _guiTexture.color = Color.Lerp(_guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void StartScene()
    {
        FadeToClear();
        if (_guiTexture.color.a <= 0.05f)
        {
            _guiTexture.color = Color.clear;
            _guiTexture.enabled = false;
            sceneStarting = false;
        }
    }
    void EndScene()
    {
        _guiTexture.enabled = true;
        FadeToBlack();

        if (_guiTexture.color.a >= 0.95f)
        {
            _guiTexture.color = Color.black;
            sceneEnding = false;
        }
    }

    public void RequestSceneEnd()
    {
        sceneEnding = true;
    }
}