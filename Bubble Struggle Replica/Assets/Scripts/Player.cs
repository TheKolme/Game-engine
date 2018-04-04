using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 4f;

	public Rigidbody2D rb;

	public GameObject gameOver;
	public bool lost;

	private float movement = 0f;

	void Start()
	{
		gameOver.SetActive(false);
		lost = false;
	}

	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * speed;

		if(Input.anyKey && lost)
		{	
			Debug.Log("restart");
			lost = false;
			Time.timeScale = 1;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}

	void FixedUpdate()
	{
		rb.MovePosition(rb.position + new Vector2 (movement * Time.fixedDeltaTime, 0f));
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.collider.tag == "Ball")
		{
			Debug.Log("GAME OVER!");
			gameOver.SetActive(true);
			Time.timeScale = 0;	
			lost = true;
		}
	}
}
