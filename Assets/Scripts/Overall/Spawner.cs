using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Food = new GameObject[1];
    public GameObject[] Enemy = new GameObject[2];
    public int Ecounter, Fcounter;
    public float Pfrequency = 0.5f;
    public float enemyFreq = 0.5f;
    public int capple;
    public GameObject player;
    public float safeRange, maxSpawnRange;
    public int maxSpawnCap = 100;
    bool thisFileGameState = true;
    
    private void Awake()
    {
        Food[0] = (GameObject)Resources.Load("Prefabs/Apple", typeof(GameObject)); 
        Food[1] = (GameObject)Resources.Load("Prefabs/Pear", typeof(GameObject)); 
        Enemy[0] = (GameObject)Resources.Load("Prefabs/enemy", typeof(GameObject)); 
        Enemy[1] = (GameObject)Resources.Load("Prefabs/enemy2", typeof(GameObject));
        Enemy[2] = (GameObject)Resources.Load("Prefabs/Enemy3", typeof(GameObject));  
        StateOfGame.gameStateChange += Spawn;
        // safeRange = player.GetComponent<d>().safeRange;
        // maxSpawnRange = player.GetComponent<d>().maxSpawnRange;
        // InvokeRepeating("SpawnFood(Food)", 0f, frequency);
        
    }
    // private void Start()
    // {
        
    // }
    void Spawn(bool gameState)
    {   
        thisFileGameState = gameState;
        
        StartCoroutine(SpawnFood(Food, Pfrequency, Fcounter, gameState));
        StartCoroutine(SpawnFood(Enemy, enemyFreq, Ecounter, gameState));
    }
    public IEnumerator SpawnFood(GameObject[] spawnObj, float frequency, int counter, bool GameState)
    {
        
        while(thisFileGameState == true){
            GameObject spawnObject = los(spawnObj);
            int x = Random.Range(-150, 150);
            int y = Random.Range(-100,100);
            if((Vector3.Distance(new Vector3(x, y, -1), player.transform.position) >= safeRange) && (Vector3.Distance(new Vector3(x, y, -1), player.transform.position) <= maxSpawnRange))
            {
                // Debug.Log(x + " " + y);
                Vector3 pozycja = new Vector3(x, y, -2);
                pozycja.z = -2;
                // Debug.Log(pozycja);

                // capple = Random.Range(0, Food.Length);
                // Debug.Log(capple);
                //Create food object from prefab
                Instantiate(spawnObject, pozycja, Quaternion.identity);
                switch (spawnObject.transform.tag)
                {
                    case "Enemy":
                        Ecounter += 1;
                        counter = Ecounter;
                        break;
                    case "Apple":
                        Fcounter += 1;
                        counter = Fcounter;
                        break;
                    default:
                        break;
                }
                
                // Debug.Log("Jest " + Fcounter + " jedzenia");
                // Debug.Log("Jest " + Ecounter + " Wrogów");
                if(counter < maxSpawnCap){
                    frequency = 0.01f;
                }else if(counter >= maxSpawnCap){
                    frequency = 1f;
                }
                yield return new WaitForSeconds(frequency);
            }
            yield return null;
        }
    }
    
    private void OnDisable()
    {
        StateOfGame.gameStateChange -= Spawn;
    }
    GameObject los(GameObject[] toLoseFrom)
    {
        int i = Random.Range(0, 100);
        switch(toLoseFrom.Length){
            case 2:
                if(i > 75){
                    return toLoseFrom[1];
                }else{
                    return toLoseFrom[0];
                }
                break;
            case 3:
                if(i > 90)
                {
                    return toLoseFrom[2];
                }else if(i > 75){
                    return toLoseFrom[1];
                }else{
                    return toLoseFrom[0];
                }
                break;
            default:
                return toLoseFrom[0];
                break;
        }
    }
}

