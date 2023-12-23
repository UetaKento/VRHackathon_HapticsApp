using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;

public class PlayHaptics : MonoBehaviour
{
    // Assign both clips in the Unity editor
    [SerializeField] HapticClip drill;
    [SerializeField] HapticClip carEngine;
    [SerializeField] HapticClip fan;
    private HapticClipPlayer player;
   

    [SerializeField] GameObject drillObj;
    [SerializeField] GameObject carObj;
    [SerializeField] GameObject fanObj;



    void Awake()
    {
        if(gameObject.name=="Drill") player = new HapticClipPlayer(drill);
        if (gameObject.name == "Car") player= new HapticClipPlayer(carEngine);
        if (gameObject.name == "Fan") player = new HapticClipPlayer(fan);
    }

    private void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayHapticClip1();
    }

    public void PlayHapticClip1()
    {
        player.Play(Controller.Left);
    }

    /*public void PlayHapticClip2(HapticClipPlayer player)
    {
        // Setting a new clip will stop the current playback
        player.clip = clip2;
        // Let's start the player again with the new clip loaded
        player.Play(Controller.Left);
    }*/

    public void StopHaptics()
    {
        player.Stop();
    }

    void OnDestroy()
    {
        // Free the HapticClipPlayer
        player.Dispose();
    }
}
