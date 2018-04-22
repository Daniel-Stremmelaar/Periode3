using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class L2_ConversationManager : MonoBehaviour
{
    [TextArea(2,5)]
    public List<string> sentences = new List<string>();
    [TextArea(2,5)]
    public List<string> answers = new List<string>();

    public Text startText;
    public Button choice1;
    public Button choice2;
    public GameObject choice1Switch;
    public GameObject choice2Switch;
    public GameObject startTextSwitch;
    public GameObject leftWall;
    public GameObject rightWall;


    void Start()
    {
        startTextSwitch.SetActive(false);
        choice1Switch.SetActive(false);
        choice2Switch.SetActive(false);

    }
    void Update()
    {
                
    }

    public void StarConversation()
    {
        Debug.Log(sentences[0]);
        startTextSwitch.SetActive(true);
        startText.text = sentences[0];

        choice1Switch.SetActive(true);
        choice2Switch.SetActive(true);

        choice1.GetComponentInChildren<Text>().text = answers[0];
        choice2.GetComponentInChildren<Text>().text = answers[1];

        choice1.onClick.AddListener(Right);
        choice2.onClick.AddListener(Left);
    }
    public void Left()
    {
        rightWall.GetComponent<BoxCollider>().isTrigger = false;
        leftWall.GetComponent<BoxCollider>().isTrigger = true;
        Debug.Log("rightwall is false");
        NextSentence();
    }

    public void Right()
    {
        leftWall.GetComponent<BoxCollider>().isTrigger = false;
        rightWall.GetComponent<BoxCollider>().isTrigger = true;
        Debug.Log("leftwall is false");
        NextSentence();
    }

    public void NextSentence()
    {
        startText.text = sentences[1];

        choice1.GetComponentInChildren<Text>().text = answers[2];
        choice2.GetComponentInChildren<Text>().text = answers[3];

        choice1.onClick.AddListener(Yes);
        choice2.onClick.AddListener(No);
    }

    public void Yes()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 2;
        if (GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax == 2)
        {
            FinalSentence();
            Debug.Log("dubble");
        }      
    }

    public void No()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 1;
        if(GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax == 1)
        {
            FinalSentence();
            Debug.Log("singel");
        }
    }
    
    public void FinalSentence()
    {
        startText.text = sentences[3];

        choice2.GetComponentInChildren<Text>().text = answers[4];
        choice1Switch.SetActive(false);
        choice2.onClick.AddListener(EndConversation);

    }

    public void EndConversation()
    {
        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = true;
        choice2Switch.SetActive(false);
        startTextSwitch.SetActive(false);
    }
}
