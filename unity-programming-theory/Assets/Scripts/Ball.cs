using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private Rigidbody ballRB;
    private Renderer ballRenderer;
    private float forceLevel;

    //Encapsulation
    private int secondsToDestruct;
    protected int SecondsToDestruct 
    {
        get { return secondsToDestruct;}
        set { if (value < 0) 
            {
                secondsToDestruct = 0;
            }
            else 
            {
                secondsToDestruct = value;
            } ;} 
    }

    public virtual void Start()
    {
        forceLevel = 10;
        SecondsToDestruct = 5;
        ballRB = gameObject.GetComponent<Rigidbody>();
        ballRenderer = gameObject.GetComponent<Renderer>();
        InvokeRepeating("Flash", 0, 1);
        Debug.Log(gameObject.name);
    }

    //Abstraction
    protected void ChangeColor(Color color)
    {
        ballRenderer.material.SetColor("_Color", color);
    }

    public virtual void Flash()
    {
        float rand = Random.Range(0f, 1f);
        if(rand < 0.5)
        {
            ChangeColor(Color.red);
        }
        else
        {
            ChangeColor(Color.blue);
        }
    }

    private void OnMouseDown()
    {
        ballRB.AddForce(forceLevel * Vector3.up, ForceMode.Impulse);
        StartCoroutine("SelfDestruct");
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(secondsToDestruct);
        Destroy(gameObject);
    }

}
