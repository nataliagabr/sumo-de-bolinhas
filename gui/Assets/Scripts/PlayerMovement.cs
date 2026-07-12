using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 moveInput;

    private BolinhaController bolinha;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bolinha = GetComponent<BolinhaController>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        rb.MovePosition(
            rb.position +
            movement * bolinha.VelocidadeAtual * Time.fixedDeltaTime);
    }
}