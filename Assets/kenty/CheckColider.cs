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


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1.0f);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Cube")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 0.5f);
            player.Play(Controller.Left);
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
