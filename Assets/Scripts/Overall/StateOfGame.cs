using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Cinemachine;

public class StateOfGame : MonoBehaviour
{
    public static bool stateOfGame;

    public static event Action<bool> gameStateChange;

    public GameObject Player;
    public GameObject StartMenu;
    public GameObject GameOverMenu;
    public GameObject ScoreCounterUI;
    public CinemachineVirtualCamera Cam;
    public GameObject bodyBBB;
    public Spawner spawnn;
    private void Awake()
    {
        stateOfGame = false;
    }
    public void StartGame()
    {
        StartCoroutine(Game());
    }
    public void PauseGame()
    {
        gameStateChange?.Invoke(false);
    }
    public void EndGame()
    {
        gameStateChange?.Invoke(false);
        ScoreCounterUI.SetActive(false);
        GameOverMenu.SetActive(true);
    }
    public void RestartGame()
    {
        GameOverMenu.SetActive(false);
        StartGame();
        clearBodies();
        var body = Instantiate(bodyBBB, Player.transform).gameObject;
        body.name = "body";
        Player.transform.parent = body.transform;
    }
    void clearBodies()
    {
        for (int i = 0; i < Player.transform.childCount; i++)
        {
            Destroy(Player.transform.GetChild(i).gameObject);
        }
        GameObject[] food = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        clear(food);
        clear(bullets);
        clear(enemies);
        spawnn.Ecounter = 0;
        spawnn.Fcounter = 0;
        ScoreCounter.Score = 0;
    }
    IEnumerator Game()
    {
        ScoreCounterUI.SetActive(true);
        StartMenu.SetActive(false);
        Cam.transform.position = new Vector3(0, 0, -11);
        Player.transform.position = new Vector3(0, 0, -1);
        Player.transform.rotation = Quaternion.identity;
        Player.GetComponent<d>().speed = 11f;
        Player.SetActive(true);
        yield return new WaitForSeconds(1f);
        gameStateChange?.Invoke(true);
        stateOfGame = true;
        yield return null;
    }
    void clear(GameObject[] stuff)
    {
        foreach (var item in stuff)
        {
            Destroy(item);
        }
    }
}
