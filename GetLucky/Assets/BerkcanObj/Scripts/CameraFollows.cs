using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Camera cam;
    public GameObject cinemachine;
    public void cameraKapatVeBüyüt()
    {
        cam.fieldOfView = 75f;
        cinemachine.SetActive(false);

    }
}
