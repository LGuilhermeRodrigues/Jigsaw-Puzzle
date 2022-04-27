using System.Collections;
using System.Collections.Generic;
using System.IO;
using SFB;
using UnityEditor;
using UnityEngine;

public class UploadImage : MonoBehaviour
{
    public void OpenFileBrowser()
    {
        var extensions = new [] {
            new ExtensionFilter("Image Files", "png", "jpg", "jpeg" )
        };
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        if (paths.Length > 0)
        {
            var file = paths[0];
        
            Sprite sprite = CreateSpriteFromFile(file);
            var pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
            foreach (var piece in pieces)
            {
                piece.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
                piece.GetComponent<Respawn>().ReturnToInitialPosition();
            }
        }
    }
    
    private Sprite CreateSpriteFromFile(string file)
    {
        var bytes = File.ReadAllBytes(file);
        var tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);
        var rect = new Rect(0, 0, tex.width, tex.height);
        var sprite = Sprite.Create(tex, rect, new Vector2(0.5f, 0.5f), 100);
        return sprite;
    }
}
