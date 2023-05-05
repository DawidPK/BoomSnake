using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameOver : MonoBehaviour
{
    StateOfGame game;
    private void Start()
    {
        game = GameObject.Find("Canvas").GetComponent<StateOfGame>();
    }
    public void gameOver()
    {
        StartCoroutine(Death());
    }
    public IEnumerator Death()
    {
        Debug.Log("Przywalił");
        //Pause the game
        game.SendMessageUpwards("EndGame");
        //Destroy player object
        gameObject.SetActive(false);

        yield return null;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.transform.tag;
        switch (tag)
        {
            case "Enemy":
                StartCoroutine(Death());
                break;
            case "Border":
                StartCoroutine(Death());
                break;
            default:
                break;
        }
        
    }
}
