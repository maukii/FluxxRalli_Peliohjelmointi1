using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlay : MonoBehaviour

    //  Janne Viitala

{
    public Transform target1;
    public Transform target2;


    Transform newTarget;
    private void Start()
    {
        newTarget = target1;
    }

    public float speed = 800;

    public void Target1()
    {
        newTarget = target1;

    }
    public void Target2()
    {
        newTarget = target2;

    }

 

    void Update()
    {

        float step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, newTarget.position, step);

    }

}
