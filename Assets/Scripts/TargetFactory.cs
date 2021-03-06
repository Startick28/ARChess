using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFactory : MonoBehaviour
{
    
    public static TargetFactory instance;

	[SerializeField] private Target originalTargetPiece;
    [SerializeField] private Target originalTargetVoid;

	private static List<Target> allTargetsPiece = new List<Target>();
    private static List<Target> allTargetsVoid = new List<Target>();
    private static Queue<Target> deadTargetsPiece = new Queue<Target>();
    private static Queue<Target> deadTargetsVoid = new Queue<Target>();
	
	void Awake(){

        if (instance == null){

            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } 
		else {
            Destroy(this);
        }
        ClearTargets();
    }

	public void SetTargets(Vector2[] positions){

		Target target;

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
                    target.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
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
                    target.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                }
                allTargetsPiece.Add(target);
            }
            Vector3 newpos = GameManager.instance.GetPosition((int) pos.x, (int) pos.y);
            target.transform.localPosition = new Vector3(newpos.x,0.012f,newpos.z);
            target.transform.localRotation = Quaternion.Euler(90f,0f,0f);
            target.position = pos;
        }
	}

	public static void ClearTargets() {

        foreach (Target target in allTargetsPiece)
        {
            target.gameObject.SetActive(false);
            deadTargetsPiece.Enqueue(target);
        }
        foreach (Target target in allTargetsVoid)
        {
            target.gameObject.SetActive(false);
            deadTargetsVoid.Enqueue(target);
        }

        allTargetsPiece.Clear();
        allTargetsVoid.Clear();
	}

}
