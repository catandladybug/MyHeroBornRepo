using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeFlagBehavior : MonoBehaviour

{
	public bool hasOrangeFlag = false;
	
	void OnCollisionEnter(Collision collision)
	
	{
		if(collision.gameObject.name == "Player")
		{
			Destroy(this.transform.parent.gameObject);
			
			Debug.Log("Flag Collected!");
			
			hasOrangeFlag = true;


			PlayerBehavior Player = collision.gameObject.GetComponent<PlayerBehavior>();

			Player.ShowHat();
		}
	}
}
