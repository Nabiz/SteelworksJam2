using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinSticksController : MonoBehaviour
{
	[SerializeField] private Entity entity;
	[SerializeField] private Rigidbody rb;
	
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Move (Vector2 vector2) { 
		rb.MovePosition(vector2);
	}
	
	public void Rotate (Vector2 vector2) { 
		rb.MoveRotation(Quaternion.Euler(vector2));
	}
	
	public void Fire()
	{
		entity.Fire();
	}
}
