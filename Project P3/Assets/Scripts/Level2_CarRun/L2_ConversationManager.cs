using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_ConversationManager : MonoBehaviour
{
    public L2_Conversation conversation;
    public List<string> dialogueHolder = new List<string>();

    public bool begin;
    public bool nextCenteces;
    public bool left;
    public bool right;

    void Start()
    {
        begin = false;
        nextCenteces = false;
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
                begin = false;
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
            }
        }

        //Left
        if (left == true)
        {
            if (Input.GetButtonDown("Left"))
            {
                right = false;
                Debug.Log(conversation.dialogue[3]);

                if (Input.GetButtonDown("Next"))
                {
                    Debug.Log(conversation.dialogue[5]);

                    if (Input.GetButtonDown("Left"))
                    {
                        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 2;
                        Debug.Log(conversation.dialogue[8]);
                        EndConversation();
                    }
                    if (Input.GetButtonDown("Right"))
                    {
                        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 1;
                        Debug.Log(conversation.dialogue[8]);
                        EndConversation();
                    }
                }
            }
        }
        
        //Right
        if (right == true)
        {
            if (Input.GetButtonDown("Right"))
            {
                left = false;
                Debug.Log(conversation.dialogue[4]);

                if (Input.GetButtonDown("Next"))
                {
                    Debug.Log(conversation.dialogue[5]);

                    if (Input.GetButtonDown("Right"))
                    {
                        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 1;
                        Debug.Log(conversation.dialogue[8]);
                        EndConversation();
                    }
                      if (Input.GetButtonDown("Left"))
                    {
                        GameObject.FindWithTag("Player").GetComponent<Player_Movement>().jumpMax = 2;
                        Debug.Log(conversation.dialogue[8]);
                        EndConversation();
                    }
                }
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
