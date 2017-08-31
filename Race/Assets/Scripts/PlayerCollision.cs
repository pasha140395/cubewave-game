using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour {


	public PlayerMovement movement;
	public TimeManager timeManager;
	public TimeBody timeBody;
	public GameObject rewindImage;

	void OnCollisionEnter(Collision collisionInfo) 
	{
		if (collisionInfo.collider.tag == "Obstacle" && timeBody.isRewindBonusTaken)
		{	
			FindObjectOfType<AudioManager>().Play("Crash");
			movement.enabled = false;
			Invoke("InvokeStartRewind", 1);
			
		} else if (collisionInfo.collider.tag == "Obstacle")
		{	
			FindObjectOfType<AudioManager>().Play("Crash");
			movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		}
	}

	void OnTriggerEnter(Collider colliderInfo)
	{
		if (colliderInfo.tag == "SlowdownBonus")
		{
			Destroy(colliderInfo.gameObject);
			timeManager.DoSlowmotion();
			FindObjectOfType<AudioManager>().Play("Slowmo");
			
		}

		if (colliderInfo.tag == "AccelerationBonus")
		{
			Destroy(colliderInfo.gameObject);
			movement.DoAcceleration();	
			FindObjectOfType<AudioManager>().Play("BonusPick_2");
			
		}

		if (colliderInfo.tag == "RewindBonus")
		{
			Destroy(colliderInfo.gameObject);
			rewindImage.SetActive(true);
			timeBody.isRewindBonusTaken = true;
			FindObjectOfType<AudioManager>().Play("BonusPick_1");
			
		}
	}

	void InvokeStartRewind()
	{	
		timeBody.StartRewind();
		FindObjectOfType<AudioManager>().Play("Slowmo");
		movement.enabled = true;
		rewindImage.GetComponent<Image>().color = new Color32(0,255,225,100);
	}

}
