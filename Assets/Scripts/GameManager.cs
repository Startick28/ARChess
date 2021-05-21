using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public TMP_Text playerText;

    public GameObject popup;
    public Image popupImage;
    public TMP_Text popupText;
    public RectTransform pauseButton;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public TMP_Text finalText;

    public enum ChessPieces {
        Void,
        WhitePawn, WhiteKing, WhiteQueen, WhiteBishop, WhiteKnight, WhiteRook,
        BlackPawn, BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackRook
    }

    public ChessPieces[][] currentBoard;
    public ChessPiece currentSelectedPiece;
    

    public void Awake()
    {
        if(instance)
        {
            Debug.Log("Il y a déjà une instance de GameManager : " + name);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        float scalingRatioX = Screen.width / 1440f;
        float scalingRatioY = Screen.height / 2960f;

        playerText.gameObject.GetComponent<RectTransform>().localScale = new Vector3(scalingRatioX, scalingRatioX, 1f);
        playerText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(340f * scalingRatioX, -110f * scalingRatioY, 0f);
        popup.GetComponent<RectTransform>().localScale = new Vector3(scalingRatioX, scalingRatioX, 1f);
        popup.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -620f * scalingRatioY, 0f);
        pauseButton.localScale = new Vector3(scalingRatioY, scalingRatioY, 1f);
        pauseButton.anchoredPosition = new Vector3(-150f * scalingRatioX, -150f * scalingRatioY, 0f);
        button1.transform.localScale = new Vector3(scalingRatioY, scalingRatioY, 1f);
        button1.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 400f * scalingRatioY, 0f);
        button2.transform.localScale = new Vector3(scalingRatioY, scalingRatioY, 1f);
        button3.transform.localScale = new Vector3(scalingRatioY, scalingRatioY, 1f);
        button3.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, -400f * scalingRatioY, 0f);
        finalText.gameObject.GetComponent<RectTransform>().localScale = new Vector3(scalingRatioX, scalingRatioX, 1f);
        finalText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(720 * scalingRatioX, -590f * scalingRatioY, 0f);

        playerPlaying = Player.White;
        playerText.text = "White to play";
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


    public void StartGame()
    {
        playerPlaying = Player.White;
        playerText.text = "White to play";
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

    public void MakeMove(Vector2 pos)
    {
        // Si le move est autorisé :
            currentBoard[(int) currentSelectedPiece.position.x][(int) currentSelectedPiece.position.y] = 0;
            currentSelectedPiece.position = pos;
            currentBoard[(int) pos.x][(int) pos.y] = currentSelectedPiece.pieceType;

            playerPlaying = 1-playerPlaying;
            playerText.text = playerPlaying == Player.White ? "White to play" : "Black to play";

            // Si on a win
                finalText.text = playerPlaying == Player.White ? "CheckMate\\Black Won" : "CheckMate\\White Won";
                button1.SetActive(true);
                button2.SetActive(true);

        // Sinon : 
            StartCoroutine(FadingPopup());


    }


    public IEnumerator FadingPopup(){
        
        float duration = 2f;
        float tmpAlpha;
        float tmp;

        popupImage.color = new Color(popupImage.color.r, popupImage.color.g, popupImage.color.b, 1f);
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 1f);

        for ( float t = 0 ; t <= duration ; t+= Time.deltaTime) {
            tmp = t/duration;
            tmpAlpha = Mathf.Lerp(1f, 0f, tmp*tmp*tmp);

            popupImage.color = new Color(popupImage.color.r, popupImage.color.g, popupImage.color.b, tmpAlpha);
            popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, tmpAlpha);
            yield return null;
        }
        
        popupImage.color = new Color(popupImage.color.r, popupImage.color.g, popupImage.color.b, 0f);
        popupText.color = new Color(popupText.color.r, popupText.color.g, popupText.color.b, 0f);
        
    }


    public void Pause()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
    }
    public void Restart()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Cancel()
    {
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
    }

    public Vector3 GetPosition(int line, int col)
    {
        float x = 0;
        float z = 0;

        switch (line)
        {
            case 0:
                z = 5.25f;
                break;
            case 1:
                z = 3.75f;
                break;
            case 2:
                z = 2.25f;
                break;
            case 3:
                z = 0.75f;
                break;
            case 4:
                z = -0.75f;
                break;
            case 5:
                z = -2.25f;
                break;
            case 6:
                z = -3.75f;
                break;
            case 7:
                z = -5.25f;
                break;
            default:
                break;
        }

        switch (col)
        {
            case 0:
                x = -5.25f;
                break;
            case 1:
                x = -3.75f;
                break;
            case 2:
                x = -2.25f;
                break;
            case 3:
                x = -0.75f;
                break;
            case 4:
                x = 0.75f;
                break;
            case 5:
                x = 2.25f;
                break;
            case 6:
                x = 3.75f;
                break;
            case 7:
                x = 5.25f;
                break;
            default:
                break;
        }

        return new Vector3(x,0f,z);
    }
}
