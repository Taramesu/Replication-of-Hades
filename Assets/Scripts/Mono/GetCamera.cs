using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCamera : MonoBehaviour
{
    public Camera mainCamera;

    public void Awake()
    {
        mainCamera = Camera.main;
    }
}
