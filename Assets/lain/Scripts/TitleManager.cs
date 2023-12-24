using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    bool isStart=false;
    [SerializeField] GameObject pushtoStartObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStart = true;
        }

        if (isStart)
        {
            pushtoStartObj.SetActive(false);
        }
    }
}
