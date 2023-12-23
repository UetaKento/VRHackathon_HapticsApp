using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Haptics;

public class CheckColider : MonoBehaviour
{
    [SerializeField] HapticClip clip1;
    private HapticClipPlayer player;

    // Start is called before the first frame update
    void Start()
    {
        player = new HapticClipPlayer(clip1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHapticClip1()
    {
        player.Play(Controller.Left);
    }

    public void StopHaptics()
    {
        player.Stop();
    }

    void OnDestroy()
    {
        // Free the HapticClipPlayer
        player.Dispose();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            PlayHapticClip1();
            //Destroy(collision.gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.name == "Cube")
        //{
        //    PlayHapticClip1();
        //}
    }
    void OnCollisionExit(Collision collision)
    {

    }
}
