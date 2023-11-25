using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class TruckController : MonoBehaviour
{
    public WheelCollider WheelFL;
    public WheelCollider WheelFR;
    public WheelCollider WheelRL;
    public WheelCollider WheelRR;
    public Transform WheelFLtrans;
    public Transform WheelFRtrans;
    public Transform WheelRLtrans;
    public Transform WheelRRtrans;
    private bool braked = false;
    private Rigidbody rb;
    public Transform centreofmass;
    public float maxTorque = 1000;
    public float maxBrakeTorque = 500;
    public float maxSteerAngle = 30;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centreofmass.transform.localPosition;
    }

    void FixedUpdate()
    {
        if (!braked)
        {
            WheelFL.brakeTorque = 0;
            WheelFR.brakeTorque = 0;
            WheelRL.brakeTorque = 0;
            WheelRR.brakeTorque = 0;
        }
        
        WheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
        WheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");

        WheelFL.steerAngle = maxSteerAngle * (Input.GetAxis("Horizontal"));
        WheelFR.steerAngle = maxSteerAngle * Input.GetAxis("Horizontal");
    }
    
    void Update()
    {
        HandBrake();

        WheelFLtrans.Rotate(WheelFL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelFRtrans.Rotate(WheelFR.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRLtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        WheelRRtrans.Rotate(WheelRL.rpm / 60 * 360 * Time.deltaTime, 0, 0);
        
        Vector3 temp = WheelFLtrans.localEulerAngles;
        Vector3 temp1 = WheelFRtrans.localEulerAngles;
        temp.y = WheelFL.steerAngle - (WheelFLtrans.localEulerAngles.z);
        WheelFLtrans.localEulerAngles = temp;
        temp1.y = WheelFR.steerAngle - WheelFRtrans.localEulerAngles.z;
        WheelFRtrans.localEulerAngles = temp1;
    }
    
    void HandBrake()
    {
        if (Input.GetButton("Jump"))
        {
            braked = true;
        }
        else
        {
            braked = false;
        }
        if (braked)
        {
            WheelRL.brakeTorque = maxBrakeTorque * 20;
            WheelRR.brakeTorque = maxBrakeTorque * 20;
            WheelRL.motorTorque = 0;
            WheelRR.motorTorque = 0;
        }
    }
}