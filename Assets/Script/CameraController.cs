using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _currBall;

    private void LateUpdate()
    {
        if(_currBall)
            this.transform.LookAt(_currBall);
    }
}
