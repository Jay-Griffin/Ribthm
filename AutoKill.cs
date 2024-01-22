using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    public bool acKill;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Vector2.down*2.5f,transform.position)<2.25f){
            GetComponent<Animator>().SetBool("Kill", true);
        }
        if(acKill){
            Destroy(gameObject);
            Debug.Log("Killed Note");
        }
    }
}
