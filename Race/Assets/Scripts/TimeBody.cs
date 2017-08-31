using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBody : MonoBehaviour {

	public GameObject rewindImage;
	public bool isRewindBonusTaken = false;
	public bool isRewinding = false;
	List<Vector3> positions;
	List<Quaternion> rotations;
	public float recordTime = 2f;


	// Use this for initialization
	void Start () 
	{
		positions = new List<Vector3>();
		rotations = new List<Quaternion>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Return))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
			StopRewind();
	}

	void FixedUpdate()
	{
		if (isRewinding)
			Rewind();
		else
			Record();
	}

	void Rewind()
	{	

		if (rotations.Count > 0)
		{	
			transform.rotation = rotations[0];
			rotations.RemoveAt(0);
		}

		if (positions.Count > 0)
		{
			transform.position = positions[0];
			positions.RemoveAt(0);
		} 
		else
		{	
			rewindImage.SetActive(false);
			rewindImage.GetComponent<Image>().color = new Color32(255,255,225,255);
			isRewindBonusTaken = false;
			StopRewind();
		}
	}

	void Record()
	{

		if (positions.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			positions.RemoveAt(positions.Count - 1);
		}
		positions.Insert(0, transform.position);


		if (rotations.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
		{
			rotations.RemoveAt(rotations.Count - 1);
		}
		rotations.Insert(0, transform.rotation);
	}

	public void StartRewind()
	{
		isRewinding = true;
	}

	void StopRewind()
	{
		isRewinding = false;
	}

	
}
