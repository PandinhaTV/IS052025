using System;
using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour
{
	
		public Transform playerCamera; // Use the actual camera transform
		public float followSpeed = 3f;
		public float viewAngleThreshold = 45f;
		public LayerMask obstructionMask; // Set to walls, environment, etc.

		private bool isSeen = false;

		

		void Start()
		{
			var data = OutfitData.Instance;
			/*customizer.SetOutfit(
				data.topOptions, data.topIndex,
				data.midOptions, data.midIndex,
				data.bottomOptions, data.bottomIndex
			);*/
		}

		

		void Update()
		{
				Vector3 toEnemy = (transform.position - playerCamera.position).normalized;
				float angle = Vector3.Angle(playerCamera.forward, toEnemy);
				
				// Is enemy within the player's view cone?
				if (angle < viewAngleThreshold)
				{
					Ray ray = new Ray(playerCamera.position, toEnemy);
					if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, ~0))
					{
						if (hit.transform == transform)
						{
							isSeen = true;
						}
						else
						{
							isSeen = false; // Something is blocking the view
						}
					}
				}
				else
				{
					isSeen = false;
				}

				if (!isSeen)
				{
					FollowPlayer();
				}
		}

			void FollowPlayer()
			{
				
				Vector3 direction = (playerCamera.position - transform.position).normalized;
				Quaternion targetRotation = Quaternion.LookRotation(direction);
				transform.position += direction * (followSpeed * Time.deltaTime);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
			}
}
