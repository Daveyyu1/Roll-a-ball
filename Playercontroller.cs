using UnityEngine;
using System.Collections;

public class Playercontroller : MonoBehaviour {

	public float speed;
	public GUIText countText;
	public GUIText winText;

	private Rigidbody rb;
	private int count;
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 12;
		SetCountText ();
		}

	void FixedUpdate ()
		{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count = count - 1;
			SetCountText ();
	}
}
	void SetCountText ()
	{
		countText.text = "Cubes left to collect: " + count.ToString ();
		if (count == 0) {
			winText.text = "No more cubes left! You win! :D";
		} 
	}
}
