using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    [SerializeField]private float velocidad = 5.0f;

    // Update es llamado cada frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Movemos el objeto en la dirección del input
        transform.Translate(new Vector3(horizontal, 0.0f, vertical) * velocidad * Time.deltaTime);
    }
}
