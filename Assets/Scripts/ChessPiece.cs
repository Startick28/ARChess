using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
   public GameManager.ChessPieces pieceType;
   public Vector2 position;

   public ChessPiece(GameManager.ChessPieces pieceT, Vector2 pos)
   {
      pieceType = pieceT;
      position = pos;
   }

}
