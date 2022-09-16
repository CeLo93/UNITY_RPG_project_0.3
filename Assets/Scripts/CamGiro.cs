using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.cam
{
    public class CamGiro : MonoBehaviour
    {
        public float sensibilidade = 5.0f;
        private float mouseX = 0.0f, mouseY = 0.0f;
        
        void Start()
        {
            
        }

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                mouseX += Input.GetAxis("Mouse X") * sensibilidade;
                mouseY += Input.GetAxis("Mouse Y") * sensibilidade;
                transform.eulerAngles = new Vector3(0, mouseX, 0);
            }
        }

      





    }
}

