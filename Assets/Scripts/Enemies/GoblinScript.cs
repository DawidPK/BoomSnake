using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinScript : MonoBehaviour
{
    public EnemieSO pepe;
    [SerializeField] GameObject favorite;
    Rigidbody2D rb;
    Vector2 kierunek;
    [SerializeField]bool foodGot = false;
    [SerializeField]bool isSearchDone = false;
    public Transform place;
    [SerializeField] bool is_Player_close;
    [SerializeField] Transform PlayerPosition;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(search());
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
    IEnumerator search()
    {
        //make a ball
        Collider2D[] things = Physics2D.OverlapCircleAll(transform.position, pepe.targetRange);
        //check for highest rarity
        foreach (var thing in things)
        {
            if (thing.gameObject.TryGetComponent(out znikanie rare))
            {
                if(favorite == null)
                {
                    favorite = thing.gameObject;
                }else if((int)rare.Rarity > (int)favorite.GetComponent<znikanie>().Rarity)
                {
                    favorite = thing.gameObject;
                }
            }
        }
        //go for it
        yield return new WaitForSeconds(2f);
        isSearchDone = true;
        //pick it
        yield return null;
    }
    private void FixedUpdate()
    {
        if(isSearchDone == true && favorite != null && foodGot == false)
        {
            StartCoroutine(chase(favorite.transform, foodGot, false, 1));
        }
        if(is_Player_close == true && PlayerPosition != null && foodGot == true)
        {
            StartCoroutine(chase(PlayerPosition, is_Player_close, true, -1));
        }
    }
    private void Update()
    {
        if(PlayerPosition != null)
        {
            is_Player_close = closePlayer();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == favorite)
        {
            foodGot = true;
            var stolenFood = Instantiate(col.gameObject, transform).gameObject;
            stolenFood.transform.parent = place;
            stolenFood.transform.position = place.position;
            stolenFood.transform.rotation = place.rotation;
            stolenFood.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(col.gameObject);
            favorite = null;
        }
    }
    public IEnumerator chase(Transform player, bool tocheck, bool check, float dir)
    {
        //Debug.Log("Gonimy!");
        while(tocheck == check && player != null)
        {
            kierunek = player.transform.position - transform.position;
            kierunek.Normalize();
            rb.MovePosition((Vector2)transform.position + (kierunek * (dir * pepe.speed) * Time.deltaTime));
            if(Vector3.Distance(gameObject.transform.position, player.transform.position) < 2 || Vector3.Distance(gameObject.transform.position, player.transform.position) > pepe.targetRange)
            {
                tocheck = true;
                break;
            }
            yield return null;
        }
        yield return null;
    }
}
