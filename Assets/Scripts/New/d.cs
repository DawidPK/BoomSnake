using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class d : MonoBehaviour
{
    Inputs SnakeInputs;
    InputAction movement;
    InputAction atak;
    public float speed = 10f;
    [SerializeField]
    private float rtspeed = 400f;
    private Rigidbody2D rb;
    Vector2 przod;
    [SerializeField] Vector2 kierunek;
    [SerializeField] float rotation_input;
    Attackitp attac;
    public float safeRange = 50;
    public float maxSpawnRange = 50;
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
    private void Update()
    {
        wyliczenie();
    }
    public void ruch()
    {
        //przód
        rb.MovePosition(rb.position + przod * speed * Time.deltaTime);
        //rotacja

        rb.MoveRotation(rb.rotation + rotation_input * rtspeed * Time.deltaTime);
        // Debug.Log(rotation_input);
    }
    public void wyliczenie()
    {
        przod = transform.up;
        kierunek = movement.ReadValue<Vector2>();
        rotation_input = -kierunek.x;
    }
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(124, 252, 0, 1);
        Gizmos.DrawSphere(transform.position, safeRange);
    }
    // public void przyspiesz(float speedUp)
    // {
    //     speed += speedUp;
    //     Debug.Log("SZNELA");
    // }
    // public void zwolnij(float speedDwn)
    // {
    //     speed -= speedDwn;
    // }
}
