using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Attackitp : MonoBehaviour
{
    Rozmnazanie roz;
    [SerializeField]
    GameObject pocisk;
    [SerializeField]
    float bulletThrust = 10f;
    
    int liczba_pocisków = 6;
    Vector2 startPoint;
    const float radius = 1f;
    // Rigidbody2D rb;
    public d ruch;
    float thrust = 7f;
    private void Awake()
    {
        roz = gameObject.GetComponent<Rozmnazanie>();
        pocisk = (GameObject)Resources.Load("Prefabs/Bullet", typeof(GameObject));
        // rb = gameObject.GetComponent<Rigidbody2D>();
        ruch = gameObject.GetComponent<d>();
    }

    public void wypisz(InputAction.CallbackContext obj)
    {
        GameObject dziecko;
        GameObject dzieckodziecka;
        
        if(roz.CzyDziecko(gameObject.transform) == true)
        {
            dziecko = roz.dziecko;
            switch (dziecko.GetComponent<BodyIdenity>().BodyIdenityfy.ToString())
            {
                case "Standard":
                    if(roz.CzyDziecko(dziecko.transform) == true){
                        dzieckodziecka = dziecko.transform.Find("body").gameObject;
                        przypisz(dziecko, dzieckodziecka);
                        Boom(dziecko, pocisk);
                        Destroy(dziecko);
                    }else{
                        Boom(dziecko, pocisk);
                        Destroy(dziecko);
                    }
                    break;
                case "Blue":
                    if(roz.CzyDziecko(dziecko.transform) == true){
                        dzieckodziecka = dziecko.transform.Find("body").gameObject;
                        przypisz(dziecko, dzieckodziecka);
                        StartCoroutine(Sprint());
                        Destroy(dziecko);
                    }else{
                        StartCoroutine(Sprint());
                        Destroy(dziecko);
                    }
                    break;
                default:
                    break;
            }
        }
    }
    public void Boom(GameObject dziecko, GameObject curPocisk)
    {  
        // Vector3 pozycja = new Vector3(dziecko.transform.position.x, dziecko.transform.position.y, 1);
        // gos = new Rigidbody2D[10];
        // for(int i = 0; i < 6; i++)
        // {
        //     Rigidbody2D clone = Instantiate(pocisk, dziecko.transform.position, Quaternion.identity * i);
        //     clone.AddForce(dziecko.transform.up * 350f);
        //     gos[i] = clone;
        // }
        
        float poruszanie = 360f / liczba_pocisków;
        float stopnie = 30f;
        float z = 60;
        
        
        FindObjectOfType<AudioManager>().Play("Boom");
        for (var i = 0; i <= liczba_pocisków - 1; i++)
        {
            float projectileDirxPosition =startPoint.x + Mathf.Sin((stopnie * Mathf.PI) / 180 * radius);
            float projectileDiryPosition =startPoint.y + Mathf.Cos((stopnie * Mathf.PI) / 180 * radius);

            Vector2 wsp_pocisku = new Vector2(projectileDirxPosition, projectileDiryPosition);
            Vector2 ruch_pocisku = (wsp_pocisku - startPoint).normalized * bulletThrust * Time.deltaTime;
            

            GameObject clone = Instantiate(curPocisk, dziecko.transform.position, new Quaternion(1,1,z,1));
            //clone.GetComponent<Rigidbody2D>().rotation = z;
            clone.GetComponent<Rigidbody2D>().velocity = ruch_pocisku;
            
            
            Destroy(clone, 5f);
            z += 60;
            stopnie += poruszanie;
        }
    }
    public IEnumerator Sprint()
    {
        //znajdź parenta
        // ruch.SendMessageUpwards("przyspiesz", thrust);
        ruch.speed += thrust;
        yield return new WaitForSeconds(2f);
        //przyspiesz
        // ruch.SendMessageUpwards("zwolnij", thrust);
        ruch.speed -= thrust;
        //przyspiesz dziecki
        yield return null;
    }
    void przypisz(GameObject Parent, GameObject Child)
    {
        Child.transform.SetParent(transform);
        Parent.transform.SetParent(null);
    }
}
