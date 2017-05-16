using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muffin : Food {
    public new const int points = 10;
    public override int getPoints()
    {
        return points;
    }
}
