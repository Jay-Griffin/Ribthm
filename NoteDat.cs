using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDat{

    public int noteId{get; private set;}
    public int noteScore {get; private set;}
    public GameObject note {get; private set;}
    public int colorId{get; private set;}

    public NoteDat(int ni, int ns,GameObject nt, int ci){
        noteId = ni;
        noteScore = ns;
        colorId = ci;
        note=nt;
    }
}