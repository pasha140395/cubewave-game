using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Transform player;

	void Update () 
	{
		scoreText.text = player.position.z.ToString("0");
	}
}
