using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SoulSlash.Camera
{
    public class SmothCamera : MonoBehaviour
    {
        public Transform target;
        public float Damping = .20f;
        private float _distance = 0;

        void LateUpdate()
        {
            if (!target) return;
            _distance = Mathf.Abs(target.transform.position.x - transform.position.x) + Mathf.Abs(target.transform.position.y - transform.position.y);
            if (_distance > 20)
            {
                _distance *= _distance * _distance;// d*d*d
            }
            Vector3 moveCamera = new Vector3(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, moveCamera, Damping * _distance * Time.deltaTime);
        }
    }
}
