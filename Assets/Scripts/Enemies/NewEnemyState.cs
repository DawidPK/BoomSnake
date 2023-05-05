using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyState : MonoBehaviour
{
    public EnemieSO pepe;
    private Rigidbody2D rb;
    Vector2 kierunek;
    Transform PlayerPosition;
    [SerializeField] bool is_Player_close;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if(GameObject.Find("Player") != null)
        {
            PlayerPosition = GameObject.Find("Player").transform;
        }
    }
    bool closePlayer()
    {
        if(Vector3.Distance(gameObject.transform.position, PlayerPosition.transform.position) > pepe.targetRange)
        {
            return false;
        }else
        {
            return true;
        }
    }
    private void Update()
    {   
        if(PlayerPosition != null)
        {
            is_Player_close = closePlayer();
        }
    }
    
    private void FixedUpdate()
    {
        if(is_Player_close == true && PlayerPosition != null){
            StartCoroutine(chase(PlayerPosition));
        }
    }
    public IEnumerator chase(Transform player)
    {
        while(is_Player_close == true)
        {
            kierunek = player.transform.position - transform.position;
            kierunek.Normalize();
            // float kat = Mathf.Atan2(kierunek.y, kierunek.x) * Mathf.Rad2Deg;
            // rb.rotation = kat;
            rb.MovePosition((Vector2)transform.position + (kierunek * pepe.speed * Time.deltaTime));
            if(Vector3.Distance(gameObject.transform.position, player.transform.position) > pepe.targetRange)
            {
                is_Player_close = false;
            }
            yield return null;
        }
        yield return null;
    }

}
