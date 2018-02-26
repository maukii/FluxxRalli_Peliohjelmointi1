using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressPlay : MonoBehaviour


{
    public Transform target1;
    public Transform target2;


    Transform newTarget;


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
