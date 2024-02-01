using UnityEngine;

public class MegaCode : MonoBehaviour
{
    [SerializeField] private float RotateSpeed;

    [SerializeField] private Transform RotateTransform;

    [SerializeField] private float MinAngle;
    [SerializeField] private float MaxAngle;

    private Vector3 localAngle
    {
        get => transform.localEulerAngles;

        set => transform.localEulerAngles = value;
    }

    private Vector3 yAxisAngle
    {
        get => RotateTransform.localEulerAngles;
        set => RotateTransform.localEulerAngles = value;
    }

    private float yAngle
    {
        get
        {
            float angle = yAxisAngle.x - (Time.deltaTime * RotateSpeed * Input.GetAxis(Constatnts.MouseY));
            if (angle > 180)
                return angle - 360;
            else
                return angle;
        }
    }

    private void Update()
    {
        Rotate();
    }



    private void Rotate()
    {
        localAngle = new Vector3 (0,localAngle.y + ( Time.deltaTime * RotateSpeed * Input.GetAxis(Constatnts.MouseX)), 0);

        var angle = Mathf.Clamp(yAngle, MinAngle, MaxAngle);

        yAxisAngle = new Vector3(angle, 0, 0);
    }
}
