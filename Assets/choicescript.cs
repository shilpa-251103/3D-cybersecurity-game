using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choicescript : MonoBehaviour
{
    public GameObject  TextBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public int ChoiceMade;

    public void ChoiceOption1 (){
        TextBox.GetComponent<Text>().text = "well done";
        ChoiceMade = 1;
    }
     public void ChoiceOption2 (){
        TextBox.GetComponent<Text>().text = " Wrong ";
        ChoiceMade = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(ChoiceMade >=1 ){
            Choice01.SetActive(false);
            Choice02.SetActive(false);
        }
    }
}
