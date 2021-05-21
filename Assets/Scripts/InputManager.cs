using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private int layerMask;

    void Start()
    {
        layerMask = 1 << 8;
        layerMask = ~layerMask;
    }


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


        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if ( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask) )
            {
                if (hit.collider.CompareTag("Target")){
                    // Appeler la fonction du plaisir
                    GameManager.instance.MakeMove(hit.transform.gameObject.GetComponent<Target>().position);
                }
            }

            TargetFactory.ClearTargets();

            if ( Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) )
            {
                Vector2[] targetPositions;

                if (GameManager.instance.playerPlaying == GameManager.Player.White){
                    if (hit.collider.CompareTag("WhitePiece")){
                        // Appeler la fonction du plaisir : targetPositions = fonction(hit.transform.gameObject.GetComponent<ChessPiece>().position)
                        targetPositions = new Vector2[1];
                        TargetFactory.instance.SetTargets(targetPositions);
                    }
                }
                else if (hit.collider.CompareTag("BlackPiece")){
                    // Appeler la fonction du plaisir : targetPositions = fonction(hit.transform.gameObject.GetComponent<ChessPiece>().position)
                    targetPositions = new Vector2[1];
                    TargetFactory.instance.SetTargets(targetPositions);
                }
                
            }

            
        }

    }

    
}
