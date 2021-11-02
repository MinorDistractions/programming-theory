using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyBall : Ball
{
    //JF: FancyBall should live longer than Ball and change into more colors.
    public override void Start()
    {
        base.Start();
        SecondsToDestruct = 10;
    }

    public override void Flash()
    {
        base.Flash();
        float rand = Random.Range(0f, 1f);
        if(rand < 0.75)
        {
            ChangeColor(Color.green);
        }

    }

}
