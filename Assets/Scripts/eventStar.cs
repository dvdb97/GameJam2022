using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventStar : MonoBehaviour
{
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startevent()); 
    }
    IEnumerator startevent()
    {
        yield return new WaitForSeconds(20f);
        sound.Play();
    }
    IEnumerator con()
    {
        StartCoroutine(con());
        yield return new WaitForSeconds(60f);
        sound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
