using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Profiling;

public class ShootInput : MonoBehaviour
{
    public ShootController ShootController;
    
    public void OnFire(InputValue valueInput)
    {
        Profiler.BeginSample("On fire");
        if (valueInput.isPressed)
        {
            Debug.Log("Fire!");
            ShootController.Shoot();
        }
        Profiler.EndSample();
    }
}