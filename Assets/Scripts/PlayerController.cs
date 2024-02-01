using UnityEngine;


[RequireComponent (typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Gravity;
    [SerializeField] private float JumpForce;
    [SerializeField] private float Speed;

    private float fallVelocity = 1;

    private Vector3 direction;

    private CharacterController Control;

    private bool isLand => Control.isGrounded;

    private void Awake()
    {
        Control = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction = Vector3.zero;
        if(Input.GetKeyDown(KeyCode.Space) && isLand) 
        {
            fallVelocity = -JumpForce;
        }

        if(Input.GetKey(KeyCode.W))
        {
            direction += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        { 
            direction -= transform.forward; 
        }
        if(Input.GetKey(KeyCode.D))
        {
            direction += transform.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= transform.right;
        }
    }
    private void FixedUpdate()
    {
        Control.Move(direction * Speed * Time.fixedDeltaTime);


        fallVelocity += Gravity * Time.fixedDeltaTime;
        direction *= Speed * Time.fixedDeltaTime;


        Control.Move(Vector3.down * fallVelocity);

        if (isLand)
            fallVelocity = 0;
            
    }
}
