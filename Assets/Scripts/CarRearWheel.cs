using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CarRearWheel : NetworkBehaviour
{

    private WheelCollider[] wheels;

    public float maxAngle = 30;
    public float maxTorque = 300;
    public GameObject wheelShape;

    public float cameraDistance = 10f;
    public float cameraHeight = 10f;

    Transform mainCamera;
    Vector3 cameraOffset;

    // here we find all the WheelColliders down in the hierarchy
    public void Start()
    {

        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        cameraOffset = new Vector3(0f, cameraHeight, -cameraDistance);

        mainCamera = Camera.main.transform;
        MoveCamera();

        wheels = GetComponentsInChildren<WheelCollider>();

        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            // create wheel shapes only when needed
            if (wheelShape != null)
            {
                var ws = GameObject.Instantiate(wheelShape);
                ws.transform.parent = wheel.transform;
            }
        }
    }

    // this is a really simple approach to updating wheels
    // here we simulate a rear wheel drive car and assume that the car is perfectly symmetric at local zero
    // this helps us to figure our which wheels are front ones and which are rear
    public void Update()
    {
        float angle = maxAngle * Input.GetAxis("Horizontal");
        float torque = maxTorque * Input.GetAxis("Vertical");

        foreach (WheelCollider wheel in wheels)
        {
            // a simple car where front wheels steer while rear ones drive
            if (wheel.transform.localPosition.z > 0)
                wheel.steerAngle = angle;

            if (wheel.transform.localPosition.z < 0)
                wheel.motorTorque = torque;

            // update visual wheels if any
            if (wheelShape)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // assume that the only child of the wheelcollider is the wheel shape
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
                shapeTransform.rotation = q;
                shapeTransform.Rotate(0,0,90);
            }

        }

        MoveCamera();

    }

    void MoveCamera()
    {
        mainCamera.position = transform.position; //move camera to player
        mainCamera.rotation = transform.rotation; //camera rotates with player
        mainCamera.Translate(cameraOffset); //offsetting camera pos
        mainCamera.LookAt(transform); //camera looks at player
    }

}
