using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class ObstacleCollision : MonoBehaviour
{
	
	public GameObject thePlayer;

	void OnTriggerEnter(Collider other)
	{
		this.gameObject.GetComponent<BoxCollider>().enabled = false;
		thePlayer.GetComponent<Playermove>().enabled = false;
	}
}*/

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Disable the collider of the obstacle
            GetComponent<BoxCollider>().enabled = false;

            // Disable the movement script of the player
            thePlayer.GetComponent<Playermove>().enabled = false;
        }
    }
}