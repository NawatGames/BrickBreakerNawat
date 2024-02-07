using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonScript : MonoBehaviour
{
    private Button _button;
    public int sceneIndex;

    private void Awake()
    {
        _button = this.gameObject.GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnMouseDown);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnMouseDown);
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
