using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    
    public static TargetFactory instance;

	[SerializeField] private GameObject originalTargetPiece;
    [SerializeField] private GameObject originalTargetVoid;

	private static List<GameObject> allTargetsPiece = new List<GameObject>();
    private static List<GameObject> allTargetsVoid = new List<GameObject>();
    private static Queue<GameObject> deadTargetsPiece = new Queue<GameObject>();
    private static Queue<GameObject> deadTargetsVoid = new Queue<GameObject>();
	
	void Awake(){

        if (instance == null){

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
		else {
            Destroy(this);
        }
    }

	public void SetTargets(Vector2[] positions){

		GameObject target;

        foreach (Vector2 pos in positions)
        {
            if (GameManager.instance.currentBoard[(int) pos.x][(int) pos.y] == 0) {
                if (deadTargetsVoid.Count > 0) {
                    target = deadTargetsVoid.Dequeue();
                    target.gameObject.SetActive(true);
                }
                else {
                    target = Instantiate(originalTargetVoid);
                    target.transform.SetParent(this.gameObject.transform);
                }
                allTargetsVoid.Add(target);
            }

            else {
                if (deadTargetsPiece.Count > 0) {
                    target = deadTargetsPiece.Dequeue();
                    target.gameObject.SetActive(true);
                }
                else {
                    target = Instantiate(originalTargetPiece);
                    target.transform.SetParent(this.gameObject.transform);
                }
                allTargetsPiece.Add(target);
            }
            Vector3 newpos = GameManager.instance.GetPosition((int) pos.x, (int) pos.y);
            target.transform.position = new Vector3(newpos.x,0.012f,newpos.y);
        }
	}

	public static void ClearTargets() {

        foreach (GameObject target in allTargetsPiece)
        {
            target.SetActive(false);
            deadTargetsPiece.Enqueue(target);
        }
        foreach (GameObject target in allTargetsVoid)
        {
            target.SetActive(false);
            deadTargetsVoid.Enqueue(target);
        }

        allTargetsPiece.Clear();
        allTargetsVoid.Clear();
	}

}
