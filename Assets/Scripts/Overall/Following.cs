using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField]
    Transform glowa;
    private Rigidbody2D rb;
    private Vector2 ruch;
    Vector3 kierunek;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        // glowa = GameObject.FindWithTag("Player").transform;
        
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        glowa = transform.parent;
        Obrot();
        ruch = kierunek;
        kierunek.Normalize();
    }
    void FixedUpdate()
    {
        Poruszanie(ruch);
    }
    void Obrot()
    {
        //Obracanie ciała w stronę głowy
        kierunek = glowa.position - transform.position;
        float kat = Mathf.Atan2(kierunek.y, kierunek.x) * Mathf.Rad2Deg;
        rb.rotation = kat;

    }
    void Poruszanie(Vector2 direction)
    {
        
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

}
