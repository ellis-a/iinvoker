using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameSetterCanvas : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _input;

    private void Awake()
    {
        _input.onSubmit.AddListener(_input_OnSubmit);
    }

    private void _input_OnSubmit(string text)
    {
        PlayerNameTracker.SetName(text);
    }
}
