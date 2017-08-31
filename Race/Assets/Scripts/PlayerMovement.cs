using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

	public float forwardForce = 2000f;
	public float sidewaysForce = 500f;
	public Rigidbody rb;
	public float accelerationForce = 10000f;
	public TimeBody timeBody;
	public GameObject rewindImage;
	
	void FixedUpdate () 
	{

		rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))
		{
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))
		{
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (rb.position.y < -1f && timeBody.isRewindBonusTaken)
		{	
			FindObjectOfType<AudioManager>().Play("Slowmo");
			rewindImage.GetComponent<Image>().color = new Color32(0,255,225,100);
			timeBody.StartRewind();
		}
		
		if (rb.position.y < -1.1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}

	}

	public void DoAcceleration()
	{
		rb.AddForce(0, 0, accelerationForce * Time.deltaTime);
	}

}
