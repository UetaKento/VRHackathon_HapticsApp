using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchingSystem : MonoBehaviour
{
    bool triggerL;
    bool triggerR;
    string hapticsNum1;
    string hapticsNum2;
    
    // Start is called before the first frame update
    void Start()
    {
        triggerL = false;
        triggerR = false;
    }

    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Debug.Log("Trigger:L");
            triggerL = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            triggerL = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.Log("Trigger;R");
            triggerR = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            triggerR = false;
        }
        if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) 
                || (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)))
        {
            Judgement();
            Debug.Log("Judgement");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("select is " + selectX  + " and " + selectY);
    }

    public void Judgement()
    {
        if (hapticsNum1 == hapticsNum2)
        {
           Correct();
        }
        if (hapticsNum1 != hapticsNum2)
        {
            Failure();
        }
    }

    public void Correct()
    {
        Debug.Log("Correct! :)");
    }

    public void Failure()
    {
        Debug.Log("Failure... :(");
    }

    public void Select(string numOfHuptics)
    {
        Debug.Log("SERECT");
        

        if (hapticsNum1 != null)
        { 
            hapticsNum2 = numOfHuptics; 
        }
        else
        {
            hapticsNum1 = numOfHuptics;
        }

    }

    public void UnSelect()
    {
        Debug.Log("UNSELECT");

        if (hapticsNum2 == null)
        {
            hapticsNum1 = null;
        }
        else
        {
            hapticsNum2 = null;
        }

    }
}

