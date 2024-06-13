using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject virtualCamera;
    public GameObject MainCamera;

    public void MoveCamera(float x, float y){
        virtualCamera.SetActive(false);
        MainCamera.transform.position = new Vector3(x, y, MainCamera.transform.position.z);
    }
}