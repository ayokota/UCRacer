using System;
using UnityEngine;

namespace YunWaypointNS
{
    public class YunAICarWaypoint : MonoBehaviour
    {
        [SerializeField]
        private YunObjWaypoint circuit;

        public YunObjWaypoint.RoutePoint targetPoint { get; private set; }
        public YunObjWaypoint.RoutePoint speedPoint { get; private set; }
        public YunObjWaypoint.RoutePoint progressPoint { get; private set; }
        public Transform target;
        private float Distance;
        private Vector3 LastPos;
        private float speed;

        private void Start()
        {
            if (target == null) target = new GameObject(name + " Waypoint Target").transform;
            Distance = 0;
        }
        private void Update()
        {
            if (Time.deltaTime > 0) speed = Mathf.Lerp(speed, (LastPos - transform.position).magnitude / Time.deltaTime, Time.deltaTime);
            target.position = (circuit.GetRoutePoint(Distance + 15 + .1f * speed)).position;
            target.rotation = Quaternion.LookRotation(circuit.GetRoutePoint(Distance + 20 + .5f * speed).direction);
            progressPoint = circuit.GetRoutePoint(Distance);
            Vector3 progressDelta = progressPoint.position - transform.position;
            if (Vector3.Dot(progressDelta, progressPoint.direction) < 0) Distance += progressDelta.magnitude * 0.5f;
            LastPos = transform.position;
        }
    }
}