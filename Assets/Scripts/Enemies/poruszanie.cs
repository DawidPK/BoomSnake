using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poruszanie : MonoBehaviour
{
    GameObject gracz;
    private Rigidbody2D rb;
    Vector2 kierunek;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        gracz = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(StateOfGame.stateOfGame == true){
            ruch();
        }
    }
    void ruch()
    {
        kierunek = gracz.transform.position - transform.position;
        kierunek.Normalize();
        // float kat = Mathf.Atan2(kierunek.y, kierunek.x) * Mathf.Rad2Deg;
        // rb.rotation = kat;
        rb.MovePosition((Vector2)transform.position + (kierunek * speed * Time.deltaTime));
        
    }
}
