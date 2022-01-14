using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
public class BlockController : MonoBehaviour,IPointerUpHandler
{
    public int x,y,num;
    MainLogic mc;

    void Start(){
        mc = transform.parent.gameObject.GetComponent<MainLogic>();
    }
    public void OnPointerUp(PointerEventData eventData){

    }
}
