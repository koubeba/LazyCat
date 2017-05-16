using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lollipop : Food {
    public new const int points = 5;
    public override int getPoints()
    {
        return points;
    }
}
