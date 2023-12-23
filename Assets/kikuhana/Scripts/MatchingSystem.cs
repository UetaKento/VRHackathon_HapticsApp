using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;
using Oculus.Interaction;


public class MatchingSystem : MonoBehaviour
{
    public GameObject[] gameObjects;
    bool handtriggerL;
    bool handtriggerR;
    string hapticsNum1;
    string hapticsNum2;
    public Transform clearTransform;
    Vector3 clearPosition;

    public int totalPairNum;

    public HapticClip clip1;
    private HapticClipPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = new HapticClipPlayer(clip1);
        clearPosition = clearTransform.position;
    }

    private void FixedUpdate()
    {
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
            if(gameObject.tag == hapticsNum1)
            {
                gameObject.SetActive(false);
                gameObject.transform.position = clearPosition;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.SetActive(true);
                clearPosition += new Vector3(0.1f, 0.0f, 0.0f);
            }
        }
        totalPairNum -= 1;
        if(totalPairNum == 0)
        {
            GameClear();
        }
    }

    public void GameClear()
    {
        Debug.Log("ÅôGameClearÅô :)");
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

