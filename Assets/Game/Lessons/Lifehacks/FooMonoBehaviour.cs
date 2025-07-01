using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class FooMonoBehaviour : MonoBehaviour
{
    //0, 1
    [Range(0, 1)]
    [SerializeField] private float _luckyPercent;

    [SerializeField] private GameObject _menu;
    private Rigidbody _rigidbody;

    [SerializeField] private MyPlayer _myPlayer;
    [SerializeField] private Button _button;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = 1000f;
        
        Debug.Log($"Speed = {_myPlayer.Speed}");
        Debug.Log($"Speed = " + _myPlayer.Speed + " " + " ");
        
        _button.onClick.AddListener(()=> Debug.Log("Button click"));
        _button.Subscribe(()=> Debug.Log("Button click"));
    }

    [Button]
    public void ShowUI(float duration)
    {
        Debug.Log($"Duration = {duration}");
    }
    
    [Button]
    public void ShowUI()
    {
        _menu.SetActive(!_menu.activeSelf);
    }

    public void Init()
    {
        Debug.Log("Init mono behaviour");
    }
}

public static class ButtonExtensions
{
    public static void Subscribe(this Button button, UnityAction action)
    {
        button.onClick.AddListener(action);
    }
    
    public static void Unsubscribe(this Button button, UnityAction action)
    {
        button.onClick.RemoveListener(action);
    }
}
