using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2_NPC : L2_ConversationManager
{
        
    public void OnTriggerEnter(Collider startCon)
    {
        if(startCon.gameObject.tag == ("Player"))
        {
            Debug.Log("trigger werkt");
            StartConversation(conversation);
            //GameObject.FindWithTag("Player").GetComponent<Player_Movement>().enabled = false;
        }
    }
}
