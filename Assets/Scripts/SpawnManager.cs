using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System.Linq;

public class SpawnManager : MonoBehaviour {

    public GameObject Manager;
    private bool isSpawn = true;
    private bool spawnFood = true;
    public float Speed = 0.1f;

    public GameObject[] Food = new GameObject[4];
    private Vector3[] Positions;
    public Vector3 SpawnPosition;
    
	void Start () {
        Manager = this.gameObject;

        Positions = new Vector3[3];
        Positions[0] = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.leftx, 0f, 0f));
        Positions[1] = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.middlex, 0f, 0f));
        Positions[2] = Camera.main.ScreenToWorldPoint(new Vector3(GameManager.rightx, 0f, 0f));

        foreach (Transform child in transform)
        {
            if (child.tag == "Food")
            {
                Destroy(child.gameObject);
            }
        }
	}
	
	void Update () {
        Speed = 0.1f + Time.timeSinceLevelLoad / 16; //Speed up!
        Manager.transform.Translate(new Vector2(0f, Speed) * Time.deltaTime);
        if (Manager.transform.position.y < 1f && spawnFood)
        {
            spawnThings(Food);
            spawnFood = false;
        }
        if (Manager.transform.position.y > 3f && isSpawn)
        {
            Instantiate(Manager, new Vector2(0f, 0f), Quaternion.identity);
            isSpawn = false;
        }
        if(Manager.transform.position.y > 10f)
        {
            foreach (Transform child in transform)
            {
                if (child.tag == "Food" && !(child.GetComponent<Food>() is Broccoli))
                {
                    Destroy(child.gameObject);
                    GameManager.lives--;
                }
            }
            Destroy(Manager);
        }
	}

    void spawnThings (GameObject[] Food)
    {
        SpawnPosition = Positions[Random.Range(0, 3)];
        GameObject FFood = Instantiate(Food[Random.Range(0, 4)], SpawnPosition, Quaternion.identity);
        FFood.gameObject.layer = 8;
        FFood.GetComponent<SpriteRenderer>().sortingOrder = 1;
        FFood.transform.parent = Manager.transform;
    }
}
