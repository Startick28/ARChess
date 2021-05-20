using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputs : MonoBehaviour
{
    

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            RaycastHit hit;
            if ( Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit) )
            {
                if (hit.collider.CompareTag("ChessPiece")) Debug.Log("Yes mon gars");
                Debug.Log("Yes mon gars");
            }
        }
    }
}
