using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagBehavior : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
	
	{
		if(collision.gameObject.name == "Player")
		{
			Destroy(this.transform.gameObject);
			
			Debug.Log("Flag Collected!");
		}
	}
}
