using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour{
    public int points = 1;
    public virtual int getPoints()
    {
        return points;
    }
}
