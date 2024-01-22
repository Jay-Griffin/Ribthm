using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private BoxCollider2D EOk,EGreat,Perfect,LGreat,LOk,EMiss,LMiss;
    [SerializeField] private int MapID;
    [SerializeField] private int colorID;

    [SerializeField] private GameObject miss;
    public static int Count;
    // Start is called before the first frame update
    void Start()
    {
        MapID=Count;
        Count++;

        //calculate direction to player -- (0,-2.5)
        Vector2 toPlayer = new Vector2(transform.position.x-0, transform.position.y-(-2.5f))*-1;
        //normalize vector velocity
        toPlayer.Normalize();
        GetComponent<Rigidbody2D>().velocity=toPlayer*(GameController.Instance.bpm/60)*2;
        //rotate
    }

    // Update is called once per frame
    void Update()
    {
        switch (colorID)
        {
            case 0:
                if(Input.GetButtonDown("F")){
                     GameController.Instance.clickedNote(MapID,gameObject,calculateScore(),colorID);
                }
                break;
            case 1:
                if(Input.GetButtonDown("D")){
                     GameController.Instance.clickedNote(MapID,gameObject,calculateScore(),colorID);
                }
                break;
            case 2:
                if(Input.GetButtonDown("J")){
                     GameController.Instance.clickedNote(MapID,gameObject,calculateScore(),colorID);
                }
                break;
            case 3:
                if(Input.GetButtonDown("K")){
                     GameController.Instance.clickedNote(MapID,gameObject,calculateScore(),colorID);
                }
                break;
        }

        if(Vector2.Distance(Vector2.down*2.5f,transform.position)<2.25f){
            Destroy(gameObject);
            Instantiate(miss,transform.position,Quaternion.identity);
        }
        // if(Input.GetButtonDown("Fire1")){
        //     GameController.Instance.clickedNote(MapID,gameObject,calculateScore());
        // }
    }

    int calculateScore(){
        //float dist = (transform.position.y-2.5f)*(transform.position.y-2.5f)+transform.position.x*transform.position.x;
        float dist = Vector2.Distance(Vector2.down*2.5f,transform.position);
        if(dist<3.1f&dist>2.9f){
            return 0;
        }else if((dist<3.35f&dist>=3.1f)|(dist<=2.9f&dist>2.65f)){
            return 1;
        }else if((dist<3.6f&dist>=3.35f)|(dist<=2.65f&dist>2.4f)){
            return 2;
        }else{
            return 3;
        }
    }
}
