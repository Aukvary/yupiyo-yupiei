using UnityEngine;

class BoxController : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    [SerializeField] private Camera _camera;

    private Ray _ray => _camera.ScreenPointToRay(Input.mousePosition);

    private void Update()
    {
        Debug.Log(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("pewpew");
            CreateOrDestroy();
        }
    }

    void CreateOrDestroy()
    { 

        RaycastHit hit;

        if(Physics.Raycast(_ray, out hit))
        {
            if (hit.collider.gameObject == _object)
                Destroy(hit.collider.gameObject);
            else
            {
                Instantiate(_object, hit.point, Quaternion.identity);
                Debug.Log("Create");
            }
                
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawRay(_ray);
    }
}