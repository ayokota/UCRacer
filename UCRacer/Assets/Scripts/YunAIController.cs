using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class YunAIController : MonoBehaviour
{
    private Rigidbody CarRigidbody;
    public Transform CurrTarget;
    public WheelCollider FrontRight;
    public WheelCollider FrontLeft;
    public WheelCollider BackRight;
    public WheelCollider BackLeft;
    public float MaxSpeed = 250;
    [Range(0, 1)] [SerializeField] private float AdvanceSteering = 0.85f;
    private float SteerAngle;
    public float CurrSpeed { get { return CarRigidbody.velocity.magnitude * 2.23693629f; } }
    public float AccelIn { get; private set; }
    public float BrakeIn { get; private set; }
    private float thrustTorque;
    private float SteerOffset = 0.05f;
    private float AccelOffset = 0.04f;
    private float BrakeOffset = 1f;
    private float AngularVelocityOffset = 30f;
    private float RandomCarNum;
    private float CurrentTorque;
    private float CurrRotate;

    private void Start()
    {
        CarRigidbody = GetComponent<Rigidbody>();
        CurrentTorque = 2000;
    }

    public void Drive(float steering, float accel, float footbrake)
    {

        steering = Mathf.Clamp(steering, -1, 1);
        AccelIn = accel = Mathf.Clamp(accel, 0, 1);
        BrakeIn = footbrake = -1 * Mathf.Clamp(footbrake, -1, 0);
        AdvSteer();
        if (Vector3.Angle(transform.forward, CarRigidbody.velocity) < 50f)
        {
            FrontLeft.brakeTorque = FrontRight.brakeTorque = BackLeft.brakeTorque = BackRight.brakeTorque = 20000 * footbrake;
        }
        else if (footbrake > 0)
        {
            FrontLeft.brakeTorque = FrontRight.brakeTorque = BackLeft.brakeTorque = BackRight.brakeTorque = 10f;
            FrontLeft.motorTorque = FrontRight.motorTorque = BackLeft.motorTorque = BackRight.motorTorque = -150 * footbrake;
        }
        SteerAngle = steering * 55;
        FrontRight.steerAngle = SteerAngle;
        FrontLeft.steerAngle = SteerAngle;
        thrustTorque = accel * (CurrentTorque / 2f);
        BackRight.motorTorque = BackLeft.motorTorque = thrustTorque * 1.25f;
    }
    private void AdvSteer() {
        WheelHit wheelhit;
        FrontRight.GetGroundHit(out wheelhit);
        if (wheelhit.normal == Vector3.zero) return;
        FrontLeft.GetGroundHit(out wheelhit);
        if (wheelhit.normal == Vector3.zero) return;
        BackRight.GetGroundHit(out wheelhit);
        if (wheelhit.normal == Vector3.zero) return;
        BackLeft.GetGroundHit(out wheelhit);
        if (wheelhit.normal == Vector3.zero) return;
        if (Mathf.Abs(CurrRotate - transform.eulerAngles.y) < 10f)
        {
            var turnadjust = (transform.eulerAngles.y - CurrRotate) * AdvanceSteering;
            Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
            CarRigidbody.velocity = velRotation * CarRigidbody.velocity;
        }
        CurrRotate = transform.eulerAngles.y;
    }
    private void FixedUpdate() {
        RandomCarNum = Random.value * 100;
        Vector3 fwd = transform.forward;
        Vector3 offsetTargetPos = CurrTarget.position;
        float DesiredSpeed = MaxSpeed;
        float CornerAngle = Vector3.Angle(CurrTarget.forward, fwd);
        float SpinAngle = CarRigidbody.angularVelocity.magnitude * AngularVelocityOffset;
        float AngleReq = Mathf.InverseLerp(0, 50f, Mathf.Max(SpinAngle, CornerAngle));
        DesiredSpeed = Mathf.Lerp(MaxSpeed, MaxSpeed / 2, AngleReq);

        offsetTargetPos += CurrTarget.right * (Mathf.PerlinNoise(Time.time / 5, RandomCarNum) * 2 - 1) * 3;
        float accelBrakeOffset = (DesiredSpeed < CurrSpeed) ? BrakeOffset : AccelOffset;
        float accel = Mathf.Clamp((DesiredSpeed - CurrSpeed) * accelBrakeOffset, -1, 1);
        Vector3 localTarget = transform.InverseTransformPoint(offsetTargetPos);
        float targetAngle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
        float steer = Mathf.Clamp(targetAngle * SteerOffset, -1, 1) * Mathf.Sign(CurrSpeed);
        Drive(steer, accel, accel);
    }
    public void SetTarget(Transform NewTarget) {
        CurrTarget = NewTarget;
    }
}