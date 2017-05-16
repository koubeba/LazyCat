using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : Food {
    public new const int points = 1;
    public override int getPoints()
    {
        return points;
    }
}
