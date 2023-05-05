using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Inputs SnakeInputs;
    InputAction movement;
    InputAction atak;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float rtspeed = 400f;
    private Rigidbody2D rb;
    Vector2 przod;
    Vector2 kierunek;
    float rotation_input;
    Attackitp attac;
    float safeRange = 350f;
    // Start is called before the first frame update
    void Awake()
    {
        SnakeInputs = new Inputs();
        rb = GetComponent<Rigidbody2D>();
        attac = gameObject.GetComponent<Attackitp>();
    }
    private void OnEnable()
    {
        movement = SnakeInputs.Player.Movement;
        movement.Enable();
        SnakeInputs.Player.Attack.performed += attac.wypisz;
        SnakeInputs.Player.Attack.Enable();
    }
    private void OnDisable()
    {
        movement.Disable();
        SnakeInputs.Player.Attack.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        ruch();
    }
    public void ruch()
    {
        //ruch
        przod = transform.up;
        rb.MovePosition(rb.position + przod * speed * Time.deltaTime);
        //rotacja
        kierunek = movement.ReadValue<Vector2>();
        rotation_input = -kierunek.x;
        rb.MoveRotation(rb.rotation + rotation_input * rtspeed * Time.deltaTime);
        Debug.Log(rotation_input);
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawSphere(transform.position, safeRange);
    }


}
