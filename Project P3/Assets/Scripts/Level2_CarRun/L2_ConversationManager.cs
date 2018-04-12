using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    public L2_Conversation conversation;
    private List<string> dialogueHolder = new List<string>();

    public bool begin;
    public bool nextCenteces;
    public bool left;
    public bool right;

    void Start()
    {
        begin = false;
        nextCenteces = false;
        left = true;
        right = true;
    }

    void Update()
    {
        EndConversation();
        NextSentence();
        if (begin == true)
        {
            if (Input.GetButton("Next"))
            {
                Debug.Log("tab werkt");
                nextCenteces = true;
            }
        }
        
    }

    public void StartConversation(L2_Conversation conversation)
    {
        Debug.Log("StartConverstation");
        Debug.Log(conversation.dialogue[0]);
        begin = true;
    }
    
    public void NextSentence()
    {
        if (nextCenteces == true)
        {
            Debug.Log(conversation.dialogue[1]);
            if (Input.GetButtonDown("Next"))
            {
                Debug.Log(conversation.dialogue[2]);
                nextCenteces = false;
            }
        }

        //Left
        if (left == true)
        {
            Debug.Log("left");
            if (Input.GetButtonDown("1"))
            {
                right = false;
                Debug.Log(conversation.dialogue[3]);

            }
        }
        
        //Right
        if (right == true)
        {
            Debug.Log("Right");
            if (Input.GetButtonDown("2"))
            {
                left = false;
                Debug.Log(conversation.dialogue[4]);
            }
        }
        
    }
    public void EndConversation()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = true;
        }
    }
}
