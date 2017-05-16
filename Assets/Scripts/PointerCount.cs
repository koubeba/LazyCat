using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointerCount : MonoBehaviour {
    public Text counter;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        counter.text = GameManager.points.ToString();
	}
}
