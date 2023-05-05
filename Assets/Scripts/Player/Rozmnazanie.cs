using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rozmnazanie : MonoBehaviour
{
    [SerializeField]
    bool CzyDzieckoMa;
    // [SerializeField]
    public GameObject dziecko;
    public GameObject Ostdziecko;
    [SerializeField]
    GameObject[] nowe_dziecko = new GameObject[2];
    public GameOver ded;

    // Start is called before the first frame update
    void Start()
    {
        CzyDzieckoMa = CzyDziecko(gameObject.transform);
        nowe_dziecko[0] = (GameObject)Resources.Load("Prefabs/body", typeof(GameObject));
        nowe_dziecko[1] = (GameObject)Resources.Load("Prefabs/blue_body", typeof(GameObject));
    }
    private void Update()
    {
        CzyDzieckoMa = CzyDziecko(gameObject.transform);
        switch(CzyDzieckoMa)
        {
            case true:
                pierwDziecko();
                ostatnieDziecko(dziecko);
                break;
            case false:
                Ostdziecko = gameObject;
                break;
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log(col.transform.tag);
        string tag = col.transform.name;
        switch (CzyDzieckoMa)
        {
            case true:
                switch (tag)
                {
                    case "Apple(Clone)":
                        var body = Instantiate(nowe_dziecko[0], Ostdziecko.transform).gameObject;
                        body.name = "body";
                        Ostdziecko.transform.parent = body.transform;
                        ScoreCounter.Score += 1;
                        break;
                    case "Pear(Clone)":
                        var blue_body = Instantiate(nowe_dziecko[1], Ostdziecko.transform).gameObject;
                        blue_body.name = "body";
                        Ostdziecko.transform.parent = blue_body.transform;
                        ScoreCounter.Score += 1;
                        break;
                    default:
                        break;
                }
                
                break;
            case false:
                switch (tag)
                {
                    case "Apple(Clone)":
                        var body = Instantiate(nowe_dziecko[0], Ostdziecko.transform).gameObject;
                        body.name = "body";
                        Ostdziecko.transform.parent = body.transform;
                        ScoreCounter.Score += 1;
                        break;
                    case "Pear(Clone)":
                        var blue_body = Instantiate(nowe_dziecko[1], Ostdziecko.transform).gameObject;
                        blue_body.name = "body";
                        Ostdziecko.transform.parent = blue_body.transform;
                        ScoreCounter.Score += 1;
                        break;
                    default:
                        break;
                }
                break;
        }
        
    }
    public bool CzyDziecko(Transform rodzic)
    {
        if(rodzic.childCount > 0)
        {
            return true;
        }
        else if(rodzic.childCount <= 0)
        {
            return false;
        }else{
            return false;
        }
    }
    public void ostatnieDziecko(GameObject parent)
    {
        GameObject dz;
        bool czy = CzyDziecko(parent.transform);
            if(czy == true)
            {
                dz = parent.transform.Find("body").gameObject;
                czy = CzyDziecko(dz.transform);
                    while(czy == true)
                    {  
                        dz = dz.transform.Find("body").gameObject;
                        czy = CzyDziecko(dz.transform);
                    }
                    Ostdziecko = dz;
            }
            else{
                Ostdziecko = parent;
            }
        }
    public void pierwDziecko()
    {
        dziecko = transform.Find("body").gameObject;
    }
}
