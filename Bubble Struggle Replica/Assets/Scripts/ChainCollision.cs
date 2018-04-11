using UnityEngine;
using UnityEngine.SceneManagement;
public class ChainCollision : MonoBehaviour {
	public int counter = 31;

	
	void Update()
	{
		if (counter <= 0)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		Chain.IsFired = false;

		if(col.tag == "Ball")
		{
			counter --;
			Debug.Log(counter);
			col.GetComponent<Ball>().Split();
		}
	}

}
