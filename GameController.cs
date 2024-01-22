using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Collider2D ring;

    public static GameController Instance;
    public float bpm;

    public List<NoteDat> notes {get; set;}
    List<LongNoteDat> longNotes;
    GameObject note;

    [SerializeField] private GameObject miss,ok,good,perfect;
    void Awake(){
        if(Instance == null){
            Instance = this;
        }else{
            Instance = this;
        }

        //bpm = 1.587f*2f; // 1 = 40
        bpm = 158;
    }
    // Start is called before the first frame update
    void Start()
    {
        notes= new List<NoteDat>();
        longNotes= new List<LongNoteDat>();
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(NoteDat note in notes){
            if(note.noteId!=-1){
                //Debug.Log("Clicked "+note.noteId);
                Destroy(note.note);
                switch (Mathf.Abs(note.noteScore))
                {
                    case 0:
                        Instantiate(perfect,note.note.transform.position,transform.rotation);
                    break;
                    case 1:
                        Instantiate(good,note.note.transform.position,transform.rotation);
                    break;
                    case 2:
                        Instantiate(ok,note.note.transform.position,transform.rotation);
                    break;
                    case 3:
                        Instantiate(miss,note.note.transform.position,transform.rotation);
                    break;
                }
            }
        }
        notes.Clear();
        
    }

    public void clickedNote(int id, GameObject obj, int score, int color){
        bool found = false;
        for(int i=0; i<notes.Count; i++){
            if(notes[i].colorId==color){
                found=true;
                if(id<notes[i].noteId|notes[i].noteId==-1){
                    notes[i]=new NoteDat(id,score,obj,color);
                }
            }
        }
        if(!found){
            notes.Add(new NoteDat(id,score,obj,color));
        }
        
    }

    public void heldNoteDown(GameObject obj, int score){
        //longNotes.Add(new LongNoteDat(id,score,obj,color,len, ));
        switch (score)
                {
                    case 0:
                        Instantiate(perfect,obj.transform.position,transform.rotation);
                    break;
                    case 1:
                        Instantiate(good,obj.transform.position,transform.rotation);
                    break;
                    case 2:
                        Instantiate(ok,obj.transform.position,transform.rotation);
                    break;
                    case 3:
                        Instantiate(miss,obj.transform.position,transform.rotation);
                    break;
                }
    }

    public void heldNoteUp(GameObject obj, int score){
        switch (score)
                {
                    case 0:
                        Instantiate(perfect,obj.transform.position,transform.rotation);
                    break;
                    case 1:
                        Instantiate(good,obj.transform.position,transform.rotation);
                    break;
                    case 2:
                        Instantiate(ok,obj.transform.position,transform.rotation);
                    break;
                    case 3:
                        Instantiate(miss,obj.transform.position,transform.rotation);
                    break;
                }

    }
}
