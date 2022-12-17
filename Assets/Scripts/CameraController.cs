using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset; //일정거리 유지하면서 플레이어 따라가도록
    // Start is called before the first frame update
    void Start()
    {
        //target -> 카메라를 향하는 백터 구함
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
