using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector2 startForce;

	public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb.AddForce(startForce, ForceMode2D.Impulse);
	}

}
