using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using Random = UnityEngine.Random;

//[RequireComponent(typeof(CharacterController))]

public class Chaser : MonoBehaviour
{
	
		public Transform playerCamera; // Use the actual camera transform
		public float followSpeed = 3f;
		public float viewAngleThreshold = 45f;
		public LayerMask obstructionMask; // Set to walls, environment, etc.

		private bool isSeen = false;
		
		public FPSController fpsController;
		public AudioSource audioPlayerObject;

		void Start()
		{
			var data = OutfitData.Instance;
			
			
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				Debug.Log(collision.gameObject.name);
				ShowDeathScreen();
				
				
				//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				
			}
		}

		void Update()
		{
			if (wasPlaying && !audioPlayerObject.isPlaying)
			{
				Debug.Log("Sound finished playing at: " + Time.time);
				wasPlaying = false;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
				// Additional debug actions here
			}
			if (fpsController.videoPlayerIsPlaying)
			{
				followSpeed = 0f;
			}
			else
			{
				followSpeed = 3f;
			}
			LookatPlayer();
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

		void LookatPlayer()
		{
			Vector3 direction = (playerCamera.position - transform.position).normalized;
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
		}

			void FollowPlayer()
			{
				
				Vector3 direction = (playerCamera.position - transform.position).normalized;
				
				transform.position += direction * (followSpeed * Time.deltaTime);
				
			}
			
			public GameObject deathScreen; // Drag your "You Died" UI object here
			public AudioClip[] audioClips;
			private bool wasPlaying = false;
			public void ShowDeathScreen()
			{
				StopAllAudio();
				deathScreen.SetActive(true);
				Time.timeScale = 0f; // Optional: pause the game
				int x= Random.Range(0, audioClips.Length);
				audioPlayerObject.PlayOneShot(audioClips[x]);
				
				wasPlaying = true;
			}

			
			void StopAllAudio()
			{
				
				AudioSource[] allAudioSources = FindObjectsOfType<AudioSource>();
    
				foreach (AudioSource audioSource in allAudioSources)
				{
					audioSource.Stop();
				}
    
				// Alternative one-liner:
				// Array.ForEach(FindObjectsOfType<AudioSource>(), (source) => source.Stop());
			}
}
