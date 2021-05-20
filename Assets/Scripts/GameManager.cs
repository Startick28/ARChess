using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform targetImageTransform;

    public GameObject boardPrefab;
    public GameObject boardContainer;

    public enum Player {
        White,
        Black
    }
    public Player playerPlaying = Player.White;

    public enum ChessPieces {
        Void,
        WhitePawn, WhiteKing, WhiteQueen, WhiteBishop, WhiteKnight, WhiteRook,
        BlackPawn, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook
    }

    public ChessPieces[][] currentBoard;
    

    public void Awake()
    {
        if(instance)
        {
            Debug.Log("Il y a déjà une instance de GameManager " + name);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }


    public void StartGame()
    {
        playerPlaying = Player.White;
        if (boardContainer) Destroy(boardContainer);
        boardContainer = Instantiate(boardPrefab,targetImageTransform);

        currentBoard = new ChessPieces[8][];
        currentBoard[0] = new ChessPieces[8] {ChessPieces.WhiteRook, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackRook};
        currentBoard[1] = new ChessPieces[8] {ChessPieces.WhiteKnight, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackKnight};
        currentBoard[2] = new ChessPieces[8] {ChessPieces.WhiteBishop, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackBishop};
        currentBoard[3] = new ChessPieces[8] {ChessPieces.WhiteQueen, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackQueen};
        currentBoard[4] = new ChessPieces[8] {ChessPieces.WhiteKing, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackKing};
        currentBoard[5] = new ChessPieces[8] {ChessPieces.WhiteBishop, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackBishop};
        currentBoard[6] = new ChessPieces[8] {ChessPieces.WhiteKnight, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackKnight};
        currentBoard[7] = new ChessPieces[8] {ChessPieces.WhiteRook, ChessPieces.WhitePawn, 0, 0, 0, 0, ChessPieces.BlackPawn, ChessPieces.BlackRook}; 
    }

    public void MakeMove()
    {

    }



    public Vector3 GetPosition(int line, int col)
    {
        float x = 0;
        float z = 0;

        switch (line)
        {
            case 0:
                z = 0.264f;
                break;
            case 1:
                z = 0.19f;
                break;
            case 2:
                z = 0.112f;
                break;
            case 3:
                z = 0.039f;
                break;
            case 4:
                z = -0.039f;
                break;
            case 5:
                z = -0.112f;
                break;
            case 6:
                z = -0.19f;
                break;
            case 7:
                z = -0.264f;
                break;
            default:
                break;
        }

        switch (col)
        {
            case 0:
                x = -0.264f;
                break;
            case 1:
                x = -0.19f;
                break;
            case 2:
                x = -0.112f;
                break;
            case 3:
                x = -0.039f;
                break;
            case 4:
                x = 0.039f;
                break;
            case 5:
                x = 0.112f;
                break;
            case 6:
                x = 0.19f;
                break;
            case 7:
                x = 0.264f;
                break;
            default:
                break;
        }

        return new Vector3(x,0f,z);
    }
}
