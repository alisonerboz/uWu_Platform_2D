using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DiyalogManager : MonoBehaviour
{

    [Header("Diyalog UI")]
    [SerializeField] private GameObject diyalogPanel;
    [SerializeField] private TextMeshProUGUI diyalogText;


    private Story currentStory;

    public bool diyalogPlaying { get; private set; }

    private static DiyalogManager instance;

    private void Start()
    {
        diyalogPlaying = false;
        diyalogPanel.SetActive(false);
    }
    private void Update()
    {
        if(!diyalogPlaying)
        {
            return;
        }
        if(InputManager.GetInstance().GetSubmitPressed())
        {
            DevamStory();
        }
    }
    private void Awake()
    {
        if(instance!=null)
        {
            Debug.LogWarning("Birden çok diyalog bulundu!");
        }
        instance = this;
    }

    public static DiyalogManager GetInstance()
    {
        return instance;
    }
    public void EnterDiyalogMode(TextAsset inkle)
    {
        currentStory = new Story(inkle.text);
        diyalogPlaying = true;
        diyalogPanel.SetActive(true);

        DevamStory();
        
    }
    private IEnumerator ExitDiyalogMode()
    {
        yield return new WaitForSeconds(0.2f);
        diyalogPlaying = false;
        diyalogPanel.SetActive(false);
        diyalogText.text = "";
    }
    private void DevamStory()
    {
        if (currentStory.canContinue)
        {
            diyalogText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDiyalogMode());
        }
    }
}
