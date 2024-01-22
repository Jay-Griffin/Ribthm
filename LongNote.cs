using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
     [SerializeField] private int MapID;
    [SerializeField] private int colorID;

    [SerializeField] private GameObject miss;

    [SerializeField] private GameObject First, Mid, Last;
    GameObject actFirst, actLast;
    [SerializeField] private Vector3 rot;

    float length;
   
    float tAlive;
    float aliveCount;
    public bool held;

    Vector2 toPlayer;

    bool STOP;
    // Start is called before the first frame update
    void Start()
    {
        STOP=false;
        aliveCount=1;
        MapID=Note.Count;
        Note.Count++;
       

        //calculate direction to player -- (0,-2.5)
        toPlayer = new Vector2(transform.position.x-0, transform.position.y-(-2.5f))*-1;
        toPlayer.Normalize();
        actFirst= Instantiate(First, transform.position,Quaternion.Euler(rot.x,rot.y,rot.z));
        actFirst.GetComponent<Rigidbody2D>().velocity=toPlayer*(GameController.Instance.bpm/60)*2;
        //rotate
    }

    public void SetLength(string L){
        length=float.Parse(L.Split(":")[1]);
        //length=4;
       //Strign magic
    }

    // Update is called once per frame
    void LateUpdate() //REALLY BAD -- Like hioly quac
    {
        tAlive+=Time.deltaTime;

       // Debug.Log(tAlive+" "+aliveCount+" "+(aliveCount/2)*(60/GameController.Instance.bpm));

        if(tAlive>length*(60/GameController.Instance.bpm)&!STOP){
            actLast=Instantiate(Last, transform.position,Quaternion.Euler(rot.x,rot.y,rot.z));
            actLast.GetComponent<Rigidbody2D>().velocity=toPlayer*(GameController.Instance.bpm/60)*2;
            GetComponent<Rigidbody2D>().velocity=toPlayer*(GameController.Instance.bpm/60)*2;
            STOP=true;
        }else if(tAlive>(aliveCount/2.125)*(60/GameController.Instance.bpm)&!STOP){
            Instantiate(Mid, transform.position,Quaternion.Euler(rot.x,rot.y,rot.z)).GetComponent<Rigidbody2D>().velocity=toPlayer*(GameController.Instance.bpm/60)*2;
            aliveCount+=1f;
        }

        //After length beats have passed spawn invisible up note
        //keep this note until the up note
        //on down check with note ids... 
        //if clicking this for color cancel all searches with color id
        
        bool found = false;
        switch (colorID)
        {
            case 0:
                if(Input.GetButtonDown("F")){
                    for(int i=0; i < GameController.Instance.notes.Count; i++){
                        if(GameController.Instance.notes[i].colorId==0){
                            if(GameController.Instance.notes[i].noteId>MapID){
                                GameController.Instance.notes.RemoveAt(i);
                                held=true;
                                GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                            }
                            found =true;
                        }
                    }
                    if(!found){
                        held=true;
                        GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                    }
                }
                if(Input.GetButtonUp("F")&held){
                    GameController.Instance.heldNoteUp(actLast,calculateScore(actLast));
                }
                break;
            case 1:
                if(Input.GetButtonDown("D")){
                    for(int i=0; i < GameController.Instance.notes.Count; i++){
                        if(GameController.Instance.notes[i].colorId==1){
                            if(GameController.Instance.notes[i].noteId>MapID){
                                GameController.Instance.notes.RemoveAt(i);
                                held=true;
                                GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                            }
                            found = true;
                        }
                    }
                    if(!found){
                        held=true;
                        GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                    }
                }
                if(Input.GetButtonUp("D")&held){
                    GameController.Instance.heldNoteUp(actLast,calculateScore(actLast));
                }
                break;
            case 2:
                if(Input.GetButtonDown("J")){
                    for(int i=0; i < GameController.Instance.notes.Count; i++){
                        if(GameController.Instance.notes[i].colorId==2){
                            if(GameController.Instance.notes[i].noteId>MapID){
                                GameController.Instance.notes.RemoveAt(i);
                                held=true;
                                GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                            }
                            found = true;
                        }
                    }
                    if(!found){
                        held=true;
                        GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                    }
                }
                if(Input.GetButtonUp("J")&held){
                    GameController.Instance.heldNoteUp(actLast,calculateScore(actLast));
                }
                break;
            case 3:
                if(Input.GetButtonDown("K")){
                    for(int i=0; i < GameController.Instance.notes.Count; i++){
                        if(GameController.Instance.notes[i].colorId==3){
                            if(GameController.Instance.notes[i].noteId>MapID){
                                GameController.Instance.notes.RemoveAt(i);
                                held=true;
                                GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                            }
                            found = true;
                        }
                    }
                    if(!found){
                        held=true;
                        GameController.Instance.heldNoteDown(actFirst,calculateScore(actFirst));
                    }
                }
                if(Input.GetButtonUp("K")&held){
                    GameController.Instance.heldNoteUp(actLast,calculateScore(actLast));
                }
                break;
        }


        if(Vector2.Distance(Vector2.down*2.5f,transform.position)<2.25f){
            Destroy(gameObject);
            Instantiate(miss,transform.position,Quaternion.identity);
            //GameControllerActScore as Miss
        }
    }
    int calculateScore(GameObject obj){
       // Debug.Log(held);
        float dist = Vector2.Distance(Vector2.down*2.5f,obj.transform.position);
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
