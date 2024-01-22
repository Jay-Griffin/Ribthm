using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.IO;

public class MagicAudioer : MonoBehaviour
{

    [SerializeField] AudioSource GimmeLove;
    [SerializeField] TextAsset GimmeLoveTxt;

    [SerializeField] GameObject green,blue,purp,red;
    [SerializeField] GameObject greenL,blueL,purpL,redL;

    string noteSheet;
    Queue<(int,float,string)> noteList;

    float timeBetween;
    [SerializeField] private float delayForStart;
    // Start is called before the first frame update
    void Start()
    {
        timeBetween=0;
        noteList=new Queue<(int,float, string)> ();
        
        loadSong(GimmeLoveTxt);
        delayForStart=60/GameController.Instance.bpm*6.5f/2;
    }

    // Update is called once per frame
    void Update()
    {
        
        updateTimes(Time.deltaTime);
        doTheNoteThing();
        if(delayForStart<0&GimmeLove.enabled!=true){
            GimmeLove.enabled=true;
        }
    }
    //Load song file
    //Spawn notes
    //Sync notes to start of song? 
    void loadSong(TextAsset TL){
        noteSheet=TL.text;
        foreach(string line in noteSheet.Split(';')){
            
            var splitLine = line.Split(',');
            if(splitLine.Length>2){
                noteList.Enqueue((Int32.Parse(splitLine[0]),float.Parse(splitLine[1]),splitLine[2]));
            }else if(splitLine.Length>1){
                noteList.Enqueue((Int32.Parse(splitLine[0]),float.Parse(splitLine[1]),""));
            }
        }
    }

    void doTheNoteThing(){
        if(timeBetween<=0){
            if(noteList.Count>0){
                (int, float, string) cNote = noteList.Dequeue();
                timeBetween=cNote.Item2*(60/GameController.Instance.bpm);
                spawnNote(cNote.Item1,cNote.Item3);
            }else{
                timeBetween=-1;
            }
        }
        if(timeBetween==0){
            doTheNoteThing();
        }
    }

    void updateTimes(float dt){
        timeBetween-=dt;
        delayForStart-=dt;
    }

    void spawnNote(int noteId,string noteText){
       // Debug.Log("Spawning note: "+noteId);
        if(noteText==""){
            switch (noteId)
            {
                case 0:
                    Instantiate(green,Vector2.left*10+Vector2.down*2.5f,Quaternion.Euler(0,0,45));
                break;
                case 1:
                    Instantiate(blue,Vector2.left*Mathf.Cos(Mathf.PI/4)*10+Vector2.up*Mathf.Sin(Mathf.PI/4)*10+Vector2.down*2.5f,Quaternion.Euler(0,0,0));
                break;
                case 2:
                    Instantiate(purp,Vector2.right*Mathf.Cos(Mathf.PI/4)*10+Vector2.up*Mathf.Sin(Mathf.PI/4)*10+Vector2.down*2.5f,Quaternion.Euler(0,0,-90));
                break;
                case 3:
                    Instantiate(red,Vector2.right*10+Vector2.down*2.5f,Quaternion.Euler(0,0,225));
                break;
            }
        }else if(noteText.Contains("hold")){
            switch (noteId)
            {
                case 0:
                    GameObject g = Instantiate(greenL,Vector2.left*10+Vector2.down*2.5f,Quaternion.identity);
                    g.SendMessage("SetLength", noteText);
                break;
                case 1:
                    GameObject b = Instantiate(blueL,Vector2.left*Mathf.Cos(Mathf.PI/4)*10+Vector2.up*Mathf.Sin(Mathf.PI/4)*10+Vector2.down*2.5f,Quaternion.Euler(0,0,45));
                    b.SendMessage("SetLength", noteText);
                break;
                case 2:
                    GameObject p = Instantiate(purpL,Vector2.right*Mathf.Cos(Mathf.PI/4)*10+Vector2.up*Mathf.Sin(Mathf.PI/4)*10+Vector2.down*2.5f,Quaternion.Euler(0,0,-45));
                    p.SendMessage("SetLength", noteText);
                break;
                case 3:
                    GameObject r = Instantiate(redL,Vector2.right*10+Vector2.down*2.5f,Quaternion.identity);
                    r.SendMessage("SetLength", noteText);
                break;
            }
        }
    }
}
