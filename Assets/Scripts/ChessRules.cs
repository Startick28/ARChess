using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ChessRules : MonoBehaviour
{

    public bool whiteKmoved = false;
    public bool whiteR1moved = false;
    public bool whiteR2moved = false;
    
    public bool blackKmoved = false;
    public bool blackR1moved = false;
    public bool blackR2moved = false;
    
    public bool IsWhite(GameManager.ChessPieces piece)
    {
        return 1 <= (int)piece && (int)piece <= 6;
    }
    
    
    public List<Vector2> PossibleMoves(ChessPiece piece)
    {
        List<Vector2> l = new List<Vector2>();
        int x = (int) piece.position.x;
        int y = (int) piece.position.y;


        switch(piece.pieceType) {
            
            case GameManager.ChessPieces.WhitePawn : 
                // Diagonal Left
                if(x!=0 && y!=7) 
                {
                    if (GameManager.instance.currentBoard[x-1][y+1] != 0 && !IsWhite(GameManager.instance.currentBoard[x-1][y+1]))
                    {
                        l.Add(new Vector2(x - 1, y + 1));
                    }

                }
                // Diagonal Right
                if (x != 7 && y != 7)
                {
                    if (GameManager.instance.currentBoard[x+1][y+1] != 0 && !IsWhite(GameManager.instance.currentBoard[x+1][y+1]))
                    {
                        l.Add(new Vector2(x + 1, y + 1));
                    }
                }

                // Forward
                if(y != 7)
                {
                    if (GameManager.instance.currentBoard[x][y+1] == 0)
                    {
                        l.Add(new Vector2(x, y + 1));
                    }
                }
                // Two Steps Forward
                if(y == 1)
                {
                    if (GameManager.instance.currentBoard[x][y+1] == 0 && GameManager.instance.currentBoard[x][y+2] == 0)
                    {
                        l.Add(new Vector2(x, y + 2));
                    }
                }
                break;
            
            case GameManager.ChessPieces.BlackPawn :
                // Diagonal Left
                if(x!=0 && y!=0) 
                {
                    if (GameManager.instance.currentBoard[x-1][y-1] != 0 && IsWhite(GameManager.instance.currentBoard[x-1][y-1]))
                    {
                        l.Add(new Vector2(x - 1, y - 1));
                    }

                }
                // Diagonal Right
                if (x != 7 && y != 0)
                {
                    if (GameManager.instance.currentBoard[x+1][y-1] != 0 && IsWhite(GameManager.instance.currentBoard[x+1][y-1]))
                    {
                        l.Add(new Vector2(x + 1, y - 1));
                    }
                }

                // Forward
                if(y != 0)
                {
                    if (GameManager.instance.currentBoard[x][y-1] == 0)
                    {
                        l.Add(new Vector2(x, y - 1));
                    }
                }
                // Two Steps Forward
                if(y == 6)
                {
                    if (GameManager.instance.currentBoard[x][y-1] == 0 && GameManager.instance.currentBoard[x][y-2] == 0)
                    {
                        l.Add(new Vector2(x, y - 2));
                    }
                }
                break;
            
                
            case GameManager.ChessPieces.WhiteBishop :
            case GameManager.ChessPieces.BlackBishop :
                
                // Top Left
                int x_t = x;
                int y_t = y;
                while(true)
                {
                    x_t--;
                    y_t++;
                    if (x_t < 0 || y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Top Right
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t++;
                    y_t++;
                    if (x_t >= 8 || y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Bottom Left
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t--;
                    y_t--;
                    if (x_t < 0 || y_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Bottom Right
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t++;
                    y_t--;
                    if (x_t >= 8 || y_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                break;
            
            case GameManager.ChessPieces.WhiteKnight :
            case GameManager.ChessPieces.BlackKnight :

                List<Vector2> l_t = new List<Vector2>();

                // Up  Left
                
                l_t.Add(new Vector2(x-1,y+2));
                l_t.Add(new Vector2(x-2,y+1));

                // Up  Right
                
                l_t.Add(new Vector2(x+1,y+2));
                l_t.Add(new Vector2(x+2,y+1));

                // Down  Left
                
                l_t.Add(new Vector2(x-1,y-2));
                l_t.Add(new Vector2(x-2,y-1));

                // Down  Right
                
                l_t.Add(new Vector2(x+1,y-2));
                l_t.Add(new Vector2(x+2,y-1));

                
                for (int i = 0; i < 8; i++)
                {
                    if ((int) l_t[i].x >= 0 && (int) l_t[i].x < 8 && (int) l_t[i].y >= 0 && (int) l_t[i].y < 8)
                    {
                        if (GameManager.instance.currentBoard[(int) l_t[i].x][(int)l_t[i].y] == 0)
                        {
                            l.Add(new Vector2((int) l_t[i].x, (int)l_t[i].y));
                        }
                        else
                        {
                            if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[(int) l_t[i].x][(int) l_t[i].y]))
                            {
                                l.Add(new Vector2((int) l_t[i].x, (int) l_t[i].y));
                            }
                        }
                    }
                }
                break;
            
            
            case GameManager.ChessPieces.WhiteRook :
            case GameManager.ChessPieces.BlackRook :
                 // Left
                x_t = x;
                y_t = y;
                while(true)
                {
                    x_t--;
                    if (x_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t, y));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y]))
                        {
                            l.Add(new Vector2(x_t, y));
                        }
                        break;
                    }
                }

                // Right
                x_t = x;
                while (true)
                {
                    x_t++;
                    if (x_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y] == 0)
                    {
                        l.Add(new Vector2(x_t,y));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y]))
                        {
                            l.Add(new Vector2(x_t, y));
                        }
                        break;
                    }
                }

                // Bottom
                while (true)
                {
                    y_t--;
                    if (y_t < 0) break;
                    if (GameManager.instance.currentBoard[x][y_t] == 0)
                    {
                        l.Add(new Vector2(x,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x][y_t]))
                        {
                            l.Add(new Vector2(x, y_t));
                        }
                        break;
                    }
                }

                // Up
                y_t = y;
                while (true)
                {
                    y_t++;
                    if (y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x][y_t] == 0)
                    {
                        l.Add(new Vector2(x,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x][y_t]))
                        {
                            l.Add(new Vector2(x, y_t));
                        }
                        break;
                    }
                }
                break;
                
            
            case GameManager.ChessPieces.WhiteQueen :
            case GameManager.ChessPieces.BlackQueen :
                
                // Bishop + Rook
            
             // Top Left
                x_t = x;
                y_t = y;
                while(true)
                {
                    x_t--;
                    y_t++;
                    if (x_t < 0 || y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Top Right
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t++;
                    y_t++;
                    if (x_t >= 8 || y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Bottom Left
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t--;
                    y_t--;
                    if (x_t < 0 || y_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }

                // Bottom Right
                x_t = x;
                y_t = y;
                while (true)
                {
                    x_t++;
                    y_t--;
                    if (x_t >= 8 || y_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y_t]))
                        {
                            l.Add(new Vector2(x_t, y_t));
                        }
                        break;
                    }
                }
                // Left
                x_t = x;
                y_t = y;
                while(true)
                {
                    x_t--;
                    if (x_t < 0) break;
                    if (GameManager.instance.currentBoard[x_t][y_t] == 0)
                    {
                        l.Add(new Vector2(x_t, y));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y]))
                        {
                            l.Add(new Vector2(x_t, y));
                        }
                        break;
                    }
                }

                // Right
                x_t = x;
                 while (true)
                {
                    x_t++;
                    if (x_t >= 8) break;
                    if (GameManager.instance.currentBoard[x_t][y] == 0)
                    {
                        l.Add(new Vector2(x_t,y));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x_t][y]))
                        {
                            l.Add(new Vector2(x_t, y));
                        }
                        break;
                    }
                }

                // Bottom
                 while (true)
                {
                    y_t--;
                    if (y_t < 0) break;
                    if (GameManager.instance.currentBoard[x][y_t] == 0)
                    {
                        l.Add(new Vector2(x,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x][y_t]))
                        {
                            l.Add(new Vector2(x, y_t));
                        }
                        break;
                    }
                }

                // Up
                 y_t = y;
                while (true)
                {
                    y_t++;
                    if (y_t >= 8) break;
                    if (GameManager.instance.currentBoard[x][y_t] == 0)
                    {
                        l.Add(new Vector2(x,y_t));
                    }
                    else
                    {
                        if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[x][y_t]))
                        {
                            l.Add(new Vector2(x, y_t));
                        }
                        break;
                    }
                }

                break;
            
            case GameManager.ChessPieces.WhiteKing :
            case GameManager.ChessPieces.BlackKing :
                
                l_t = new List<Vector2>();

                // Up  Left
                l_t.Add(new Vector2(x-1,y+1));
                
                // Up
                l_t.Add(new Vector2(x,y+1));

                // Up  Right
                l_t.Add(new Vector2(x+1,y+1));
                
                // Right
                l_t.Add(new Vector2(x+1,y));
                
                // Down  Right
                l_t.Add(new Vector2(x+1,y-1));
                
                // Down
                l_t.Add(new Vector2(x,y-1));

                // Down  Left
                l_t.Add(new Vector2(x-1,y-1));
                
                // Left
                l_t.Add(new Vector2(x-1,y));
                

                for (int i = 0; i < 8; i++)
                {
                    if ((int) l_t[i].x >= 0 && (int) l_t[i].x < 8 && (int) l_t[i].y >= 0 && (int) l_t[i].y < 8)
                    {
                        if (GameManager.instance.currentBoard[(int) l_t[i].x][(int)l_t[i].y] == 0)
                        {
                            l.Add(new Vector2((int) l_t[i].x, (int)l_t[i].y));
                        }
                        else
                        {
                            if (IsWhite(piece.pieceType) != IsWhite(GameManager.instance.currentBoard[(int) l_t[i].x][(int) l_t[i].y]))
                            {
                                l.Add(new Vector2((int) l_t[i].x, (int) l_t[i].y));
                            }
                        }
                    }
                }
                
                // Castle handling
                
                GameManager.ChessPieces[][] board_t = new GameManager.ChessPieces[8][];
                for (int k = 0; k < 8; k++)
                {
                    board_t[k] = new GameManager.ChessPieces[8];
                    for (int n = 0; n < 8; n++)
                    {
                        board_t[k][n] = GameManager.instance.currentBoard[k][n];
                    }
                }


                bool castle_possible = true;
                if (IsWhite(piece.pieceType))
                {
                    if (!whiteKmoved && !whiteR1moved)
                    {
                        if (board_t[1][0] == GameManager.ChessPieces.Void &&
                            board_t[2][0] == GameManager.ChessPieces.Void &&
                            board_t[3][0] == GameManager.ChessPieces.Void)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                board_t[k][0] = GameManager.ChessPieces.WhiteKing;
                                if (IsCheck(board_t))
                                {
                                    castle_possible = false;
                                }
                            }
                        }

                        if (castle_possible = true)
                        {
                            l.Add(new Vector2(2,0));
                        }

                        castle_possible = true;
                    }
                    if (!whiteKmoved && !whiteR2moved)
                    {
                        if (board_t[5][0] == GameManager.ChessPieces.Void &&
                            board_t[6][0] == GameManager.ChessPieces.Void )
                        {
                            for (int k = 5; k < 7; k++)
                            {
                                board_t[k][0] = GameManager.ChessPieces.WhiteKing;
                                if (IsCheck(board_t))
                                {
                                    castle_possible = false;
                                }
                            }
                        }

                        if (castle_possible = true)
                        {
                            l.Add(new Vector2(6,0));
                        }

                        castle_possible = true;
                    }
                }
                
                if (!IsWhite(piece.pieceType))
                {
                    if (!blackKmoved && !blackR1moved)
                    {
                        if (board_t[1][7] == GameManager.ChessPieces.Void &&
                            board_t[2][7] == GameManager.ChessPieces.Void &&
                            board_t[3][7] == GameManager.ChessPieces.Void)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                board_t[k][7] = GameManager.ChessPieces.BlackKing;
                                if (IsCheck(board_t))
                                {
                                    castle_possible = false;
                                }
                            }
                        }

                        if (castle_possible = true)
                        {
                            l.Add(new Vector2(2,7));
                        }

                        castle_possible = true;
                    }
                    if (!blackKmoved && !blackR2moved)
                    {
                        if (board_t[5][7] == GameManager.ChessPieces.Void &&
                            board_t[6][7] == GameManager.ChessPieces.Void )
                        {
                            for (int k = 5; k < 7; k++)
                            {
                                board_t[k][7] = GameManager.ChessPieces.BlackKing;
                                if (IsCheck(board_t))
                                {
                                    castle_possible = false;
                                }
                            }
                        }

                        if (castle_possible = true)
                        {
                            l.Add(new Vector2(6,7));
                        }

                        castle_possible = true;
                    }
                }
                
                break;
        }
        return l;
    }

    public bool IsCheck(GameManager.ChessPieces[][] board)
    {
        List<Vector2> l = new List<Vector2>();
        ChessPiece piece = new ChessPiece(board[0][0], new Vector2(0, 0));
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                piece.position = new Vector2(i, j);
                piece.pieceType = board[i][j];


                if (!IsWhite(piece.pieceType) && GameManager.instance.playerPlaying == GameManager.Player.White)
                {
                    // On exclut le cas du roi noir pouvoir faire appel à PossibleMoves (qui fait appel à IsCheck dans le cas des rois)
                    if (piece.pieceType != GameManager.ChessPieces.BlackKing)
                    { 
                        l = PossibleMoves(piece); 
                        for (int k = 0; k < l.Count; k++) 
                        {
                            if (board[(int) l[k].x][(int) l[k].y] == GameManager.ChessPieces.WhiteKing)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        List <Vector2> l_t = new List<Vector2>();
                        
                        l_t.Add(new Vector2(i-1,j+1));
                        l_t.Add(new Vector2(i,j+1));
                        l_t.Add(new Vector2(i+1,j+1));
                        l_t.Add(new Vector2(i+1,j));
                        l_t.Add(new Vector2(i+1,j-1));
                        l_t.Add(new Vector2(i,j-1));
                        l_t.Add(new Vector2(i-1,j-1));
                        l_t.Add(new Vector2(i-1,j));
                

                        for (int m = 0; m < 8; m++)
                        {
                            if (board[(int) l[m].x][(int) l[m].y] == GameManager.ChessPieces.WhiteKing)
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    if (IsWhite(piece.pieceType) && GameManager.instance.playerPlaying == GameManager.Player.Black)
                    {
                        if (piece.pieceType != GameManager.ChessPieces.WhiteKing) 
                        { 
                            for (int k = 0; k < l.Count; k++)
                            {
                                if (board[(int) l[k].x][(int) l[k].y] == GameManager.ChessPieces.BlackKing)
                                {
                                    return true;
                                }
                            }
                        }
                        else
                        {
                            List <Vector2> l_t = new List<Vector2>();
                        
                            l_t.Add(new Vector2(i-1,j+1));
                            l_t.Add(new Vector2(i,j+1));
                            l_t.Add(new Vector2(i+1,j+1));
                            l_t.Add(new Vector2(i+1,j));
                            l_t.Add(new Vector2(i+1,j-1));
                            l_t.Add(new Vector2(i,j-1));
                            l_t.Add(new Vector2(i-1,j-1));
                            l_t.Add(new Vector2(i-1,j));
                

                            for (int m = 0; m < 8; m++)
                            {
                                if (board[(int) l[m].x][(int) l[m].y] == GameManager.ChessPieces.BlackKing)
                                {
                                    return true;
                                }
                            }
                        }
                        
                    }
                }
            }
        }

        return false; 
    }


    public int IsMate(GameManager.ChessPieces[][] board)
    {
        int mate;
        GameManager.ChessPieces[][] board_t = new GameManager.ChessPieces[8][];
        for (int k = 0; k < 8; k++)
        {
            board_t[k] = new GameManager.ChessPieces[8];
            for (int n = 0; n < 8; n++)
            {
                board_t[k][n] = GameManager.instance.currentBoard[k][n];
            }
        }

        List<Vector2> l = new List<Vector2>();
        ChessPiece piece = new ChessPiece(board[0][0], new Vector2(0, 0));

        // White mated
        mate = 1;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (mate == 1)
                {
                    piece.position = new Vector2(i, j);
                    piece.pieceType = board[i][j];

                    if (IsWhite(piece.pieceType))
                    {
                        l = PossibleMoves(piece);
                        for (int k = 0; k < l.Count; k++)
                        {
                            board_t[(int) l[k].x][(int) l[k].y] = piece.pieceType;
                            board_t[i][j] = GameManager.ChessPieces.Void;

                            if (IsCheck(board_t) == 1)
                            {
                                mate = 1;
                            }
                            else
                            {
                                mate = 0;
                            }

                            board_t[(int) l[k].x][(int) l[k].y] = board[(int) l[k].x][(int) l[k].y];
                            board_t[i][j] = piece.pieceType;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        // Black mated
        mate = 2;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (mate == 2)
                {
                    piece.position = new Vector2(i, j);
                    piece.pieceType = board[i][j];

                    if (!IsWhite(piece.pieceType))
                    {
                        l = PossibleMoves(piece);
                        for (int k = 0; k < l.Count; k++)
                        {
                            board_t[(int) l[k].x][(int) l[k].y] = piece.pieceType;
                            board_t[i][j] = GameManager.ChessPieces.Void;

                            if (IsCheck(board_t) == 2)
                            {
                                mate = 2;
                            }
                            else
                            {
                                mate = 0;
                            }

                            board_t[(int) l[k].x][(int) l[k].y] = board[(int) l[k].x][(int) l[k].y];
                            board_t[i][j] = piece.pieceType;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        return mate;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}