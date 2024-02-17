using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _followobject;
    [SerializeField] private float _cameraspeed;
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;

    private Vector3 _position => new(_followobject.position.x + _x, _followobject.position.y + _y, transform.position.z + _z);

    void Start()
    {
        transform.position = _position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _cameraspeed);
    }
}
