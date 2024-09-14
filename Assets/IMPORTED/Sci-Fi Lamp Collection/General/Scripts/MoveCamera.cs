using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace com.ggames4u.scifi_lamp_collection {
    [RequireComponent(typeof(Camera))]
    public class MoveCamera : MonoBehaviour {
        private Transform camTransform;
        private float xAngle = 0f;
        private float yAngle = 0f;

        [SerializeField] private float speed = 1;
        [SerializeField] private float rotationSpeed = 1;
        [SerializeField] private float movementMultiplier = 2;
        private float multiplier = 1f;

        void Start() {
            Cursor.lockState = CursorLockMode.Locked;
            camTransform = transform;
            xAngle = camTransform.rotation.eulerAngles.x;
            yAngle = camTransform.rotation.eulerAngles.y;
        }

        // Update is called once per frame
        void Update() {
            
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                multiplier = movementMultiplier;
            } else {
                multiplier = 1f;
            }

            if (Input.GetKey(KeyCode.W)) {
                camTransform.position += camTransform.forward * speed * multiplier * Time.deltaTime;

            } else if (Input.GetKey(KeyCode.S)) {
                camTransform.position -= camTransform.forward * speed * multiplier * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A)) {
                camTransform.position -= camTransform.right * speed * multiplier * Time.deltaTime * 0.5f;

            } else if (Input.GetKey(KeyCode.D)) {
                camTransform.position += camTransform.right * speed * multiplier * Time.deltaTime * 0.5f;
            }

            if (Input.GetKey(KeyCode.Q)) {
                camTransform.position -= camTransform.up * speed * multiplier * Time.deltaTime;

            } else if (Input.GetKey(KeyCode.E)) {
                camTransform.position += camTransform.up * speed * multiplier * Time.deltaTime;
            }

            yAngle += Input.GetAxis("Mouse X") * rotationSpeed * multiplier * Time.deltaTime;
            xAngle -= Input.GetAxis("Mouse Y") * rotationSpeed * multiplier * Time.deltaTime;

            camTransform.rotation = Quaternion.Euler(xAngle, yAngle, 0f);
        }
    }
}
