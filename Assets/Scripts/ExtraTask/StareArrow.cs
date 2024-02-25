using UnityEngine;

class StareArrow : MonoBehaviour
{
    [SerializeField] private Transform _followObject;

    private void Update()
    {
        transform.LookAt(_followObject);
    }
}