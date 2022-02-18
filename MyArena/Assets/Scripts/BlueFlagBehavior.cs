using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlagBehavior : MonoBehaviour

{
	public bool hasBlueFlag = false;
	
	void OnCollisionEnter(Collision collision)
	
	{
		Debug.Log("Picked up!");

		if(collision.gameObject.name == "Enemy")
		{
			Destroy(this.transform.parent.gameObject);
			
			Debug.Log("The enemy has your flag!");
			
			hasBlueFlag = true;

			FlagEnemyBehavior Enemy = collision.gameObject.GetComponent<FlagEnemyBehavior>();

			Enemy.ShowHat();

		}

		if (collision.gameObject.name == "Player")
        {

			Debug.Log("You can't pick up your own flag!");

		}
	}
}

