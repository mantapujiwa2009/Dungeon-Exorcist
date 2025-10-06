using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    InputAction PlayerMovement;

    public float speed = 5f;

    private Rigidbody2D rb;
    void Start()
    {
        PlayerMovement = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        Vector2 direction = PlayerMovement.ReadValue<Vector2>();
        rb.linearVelocity = direction * speed;
    }
}
