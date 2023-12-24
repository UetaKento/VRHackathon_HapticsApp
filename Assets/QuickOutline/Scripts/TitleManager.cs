using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    bool isButtonShown=false;
    bool isRuleShown=false;
    [SerializeField] GameObject toStartObj;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject ruleImage;

    public Transform anchor;
    private float maxDistance = 100;
    private LineRenderer lineRenderer;

    AudioSource selectAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        selectAudioSource = gameObject.GetComponent<AudioSource>();
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (OVRInput.GetDown(OVRInput.Button.Any)||Input.GetKeyDown(KeyCode.Space))//後で修正
        {
            isButtonShown = true;
            buttons.SetActive(true);
            selectAudioSource.Play();
        }

        if (isButtonShown)
        {
            toStartObj.SetActive(false);
        }

        if(isRuleShown&& Input.GetKeyDown(KeyCode.Escape))
        {
            CloseRuleImage();
        }


    }

    public void StartGame()
    {
        selectAudioSource.Play();
        SceneManager.LoadScene("MainScene");
    }

    public void ShowRule()
    {
        selectAudioSource.Play();
        ruleImage.SetActive(true);
        isRuleShown = true;
    }

    public void QuitGame()
    {
        selectAudioSource.Play();
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
        #else
            Application.Quit();//ゲームプレイ終了
        #endif
    }

    void CloseRuleImage()
    {
        ruleImage.SetActive(false);
    }


}
