using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    private float imageSizeX = 3f;
    private float imageSizeY = 3f;
    private int nPieceCol = 3;
    private int nPieceRow = 3;

    private Dictionary<string, Sprite> piecesMap = new Dictionary<string, Sprite>();
    [Serializable]
    public struct NamedImage {
        public string name;
        public Sprite image;
    }
    public NamedImage[] puzzleImages;
    
    public GameObject initialPositionObject;
    public GameObject piecePrefab;
    public GameObject imagePrefab;
    
    
    private void Start()
    {
        imageSizeX = initialPositionObject.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        imageSizeY = initialPositionObject.transform.GetChild(0).GetComponent<RectTransform>().rect.height;
        
        foreach (var namedImage in puzzleImages)
        {
            piecesMap.Add(namedImage.name, namedImage.image);
        }
        
        // this is the amount of the piece that is square, the other 0.25 is the image of the following piece
        var pieceOffsetRatio = 0.75f;
        var pieceInitialSizeX = imageSizeX / nPieceCol;
        var pieceSizeX = pieceInitialSizeX / pieceOffsetRatio;
        var pieceInitialSizeY = imageSizeY / nPieceRow;
        var pieceSizeY = pieceInitialSizeY / pieceOffsetRatio;
        
        for (int c = 0; c < nPieceCol; c++)
        {
            string pieceName;
            float x;
            float y;

            for (int r = 0; r < nPieceRow; r++)
            {
                pieceName = "";
                
                if (r == 0)
                    pieceName += "1";
                else
                    pieceName += "0";

                if (c==nPieceCol-1)
                    pieceName += "1";
                else
                    pieceName += "2";

                if (r == nPieceRow - 1)
                    pieceName += "1";
                else
                    pieceName += "2";
                
                if (c==0)
                    pieceName += "1";
                else
                    pieceName += "0";
                
                if (c == 0)
                    x = 0;
                else
                    x = pieceInitialSizeX * c;
                if (c== nPieceCol - 1)
                    x -= pieceSizeX * 0.25f;
                
                if (r == 0)
                    y = 0;
                else
                    y = - pieceInitialSizeY * r;
                if (r == nPieceRow - 1)
                    y += pieceSizeY * 0.25f;
                
                var piece = Instantiate(piecePrefab, initialPositionObject.transform, true);
                piece.transform.localPosition = new Vector3(x, y, 0f);
                
                var collider = piece.GetComponent<BoxCollider2D>();
                collider.offset = new Vector2(
                    collider.offset.x + (c == nPieceCol - 1 ? pieceInitialSizeX * 0.25f : 0),
                    collider.offset.y - (r == nPieceRow - 1 ? pieceInitialSizeY * 0.25f : 0));
                
                piece.transform.localScale = new Vector3(pieceSizeX, pieceSizeY, 1);
                
                piece.GetComponentInChildren<Image>().sprite = piecesMap[pieceName];

                var imagePlaceholder = Instantiate(imagePrefab, initialPositionObject.transform);
                imagePlaceholder.transform.parent = piece.transform.GetChild(0);

            }
        }
    }
}
