using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 4f;
	public Rigidbody2D rb;
	public GameObject gameOver;
	public GameObject start;
	public GameObject tutorial;
	public bool lost;
	public bool isStart;
	private float movement = 0f;

	void Start()
	{
		gameOver.SetActive(false);
		start.SetActive(true);
		tutorial.SetActive(true);
		Time.timeScale = 0;
		lost = false;
		isStart = false;
	}

	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis("Horizontal") * speed;

		if(Input.anyKey && !isStart)
		{	
			Time.timeScale = 1;
			start.SetActive(false);
			tutorial.SetActive(false);
			isStart = true;
		}

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
