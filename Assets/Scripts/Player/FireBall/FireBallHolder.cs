using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireBallHolder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _targetInSkyDistance;

    private Ray ray => _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));

    private void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            _target.position = hit.point;
        }
        else
            _target.position = ray.GetPoint(_targetInSkyDistance);

        transform.LookAt(_target);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(ray);
    }
}
