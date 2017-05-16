using UnityEngine;
using System.Collections;

public class CatControl : MonoBehaviour {

    public GameObject cat;
    private Vector3 middle, left, right;
    private float caty; // y position of the cat.
    public LayerMask Donuts;
    //Collider2D CatCollider;
    
	void Start () {
        cat = GameObject.FindGameObjectWithTag("Player");
        //CatCollider = cat.GetComponent<Collider2D>();
        caty = 3f * Screen.height / 4f;

        left = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.leftx, caty, 0f));
        middle = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.middlex, caty, 0f));
        right = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.rightx, caty, 0f));

        cat.transform.position = middle;

    }
	
	void Update () {
        if (GameManager.gameState!=state.paused) Move();
    }

    void Move ()
    {
        if (cat.transform.position.Equals(middle))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                cat.transform.position = left;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                cat.transform.position = right;
            }
        }
        else if (cat.transform.position == left)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                cat.transform.position = middle;
            }
        }
        else if (cat.transform.position == right)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                cat.transform.position = middle;
            }
        }

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            if (other.GetComponent<Food>() is Broccoli) GameManager.lives--;
            else GameManager.points += other.GetComponent<Food>().getPoints();
            Destroy(other.gameObject);
        }
    }
}
