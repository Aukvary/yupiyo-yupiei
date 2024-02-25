using UnityEngine;

public class ObjectFinder : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private bool _viewGizmos;
    [SerializeField] private Color _gizmosColor;

    private void FixedUpdate()
    {
        if (TryToFindObject<PlayerController>() != null)
            Debug.Log(TryToFindObject<PlayerController>().name);
        else
            Debug.LogError("Don't find");
    }

    public GameObject TryToFindObject<ObjectType>()
    {
        for (float i = 0; i < 360; i++)
        {
            var direction = new Vector3(_range * Mathf.Cos(i), 0, _range * Mathf.Sin(i));

            RaycastHit hit;

            if(Physics.Raycast(transform.position, direction, out hit, _range))
            {
                bool finded = hit.collider.gameObject.TryGetComponent<ObjectType>(out _);
                if(finded)
                    return hit.collider.gameObject;
            }
        }
        return null;
    }

    private void OnDrawGizmos()
    {
        if (_viewGizmos && _range >= 0)
        { 
            Gizmos.color = new Color(_gizmosColor.r, _gizmosColor.g, _gizmosColor.b);
            for (float i = 0; i < 360; i++)
            {
                var direction = new Vector3(_range * Mathf.Cos(i), 0, _range * Mathf.Sin(i));

                Gizmos.DrawRay(transform.position, direction);
            }
        }
        if (_range < 0)
        {
            Debug.LogError($"у объекта {gameObject.name} отрицательная дальность взгляда");
        }
    }
}
