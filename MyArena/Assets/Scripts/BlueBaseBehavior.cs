using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBaseBehavior : MonoBehaviour
{
	public bool scorePoint = false;
	public bool hasFlag = false;
	public GameObject flag;
	private OrangeFlagBehavior bool_script;
	private void Start()
	{
		bool_script = flag.GetComponent<OrangeFlagBehavior>();
	}
	private void Update()
	{
		if (bool_script.hasOrangeFlag == true) 
		{
			hasFlag = true;
		}
	}

	void OnCollisionEnter(Collision collision)

	{
		if (collision.gameObject.name == "Player") 
		{
			if (hasFlag == true) 
			{
				Debug.Log("You scored a point!");

				scorePoint = true;

				hasFlag = false;
			}
		}
	}
}
