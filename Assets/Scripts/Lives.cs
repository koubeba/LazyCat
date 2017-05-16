using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
    
	void Update () {
		switch(GameManager.lives)
        {
            case 1:
                DisableAllExcept("1Heart");
                break;
            case 2:
                DisableAllExcept("2Heart");
                break;
            case 3:
                DisableAllExcept("3Heart");
                break;
        }
	}

    void DisableAllExcept(string name)
    {
        foreach (Transform Child in this.transform)
        {
            if (Child.name == name) Child.gameObject.SetActive(true);
            else Child.gameObject.SetActive(false);
        }
    }
}
