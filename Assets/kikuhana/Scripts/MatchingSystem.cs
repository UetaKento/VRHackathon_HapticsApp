using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;


public class MatchingSystem : MonoBehaviour
{
    public GameObject[] gameObjects;
    string[] TagNames;
    bool triggerL;
    bool triggerR;
    bool handtriggerL;
    bool handtriggerR;
    string hapticsNum1;
    string hapticsNum2;
    public Transform clearTransform;
    Vector3 clearPosition;

    public HapticClip clip1;
    private HapticClipPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = new HapticClipPlayer(clip1);
        triggerL = false;
        triggerR = false;
        clearPosition = clearTransform.position;
    }

    private void FixedUpdate()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            //Debug.Log("Trigger:L");
            triggerL = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            triggerL = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            //Debug.Log("Trigger;R");
            triggerR = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            triggerR = false;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Debug.Log("HandTrigger:L");
            handtriggerL = true;
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Debug.Log("HandTrigger:R");
            handtriggerR = true;
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

    public void Haptics(HapticClip hapticClip)
    {
        player.clip = hapticClip;
        //player.Play(Controller.Left);
        if(handtriggerL)
        {
            player.Play(Controller.Left);
            handtriggerL = false;
        }
        if(handtriggerR)
        {
            player.Play(Controller.Right);
            handtriggerR = false;
        }
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
        foreach (GameObject gameObject in gameObjects)
        {
            //if(gameObject)
        }
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

