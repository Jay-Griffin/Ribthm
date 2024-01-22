using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNoteDat{
    public int noteId{get; private set;}
    public int noteScore {get; private set;}
    public GameObject note {get; private set;}
    public int colorId{get; private set;}
    public float lenght{get; private set;}

    public LongNoteDat(int ni, int ns,GameObject nt, int ci, float l){
        noteId = ni;
        noteScore = ns;
        colorId = ci;
        note=nt;
        lenght = l;
    }
}
