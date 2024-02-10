using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    [SerializeField] private Transform FirstTarget;
    [SerializeField] private Transform SecondTarget;
    [SerializeField, Range(0, 1)] private float Position;
    
    void Update()
    {
        transform.position = Vector3.Lerp(FirstTarget.position, SecondTarget.position, Position);
    }
}
