using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileScript : MonoBehaviour {

    SpriteRenderer rend;

    private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);

    private static TileScript previousSelected = null;

    private bool isSelected = false;

    public Vector2[] adjacentDirections;

    public Vector2 gridPosition;    
  

    void Awake() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Select() {
        isSelected = true;
        rend.color = selectedColor;
        previousSelected = gameObject.GetComponent<TileScript>();
    }

    private void Deselect() {
        isSelected = false;
        rend.color = Color.white;
        previousSelected = null;
    }

    void OnMouseDown() {
        if(rend.sprite == null) {
            return;
        }

        if (isSelected) {
            Deselect();
        }
        else {
            if(previousSelected == null) {
                Select();
            }
            else {
                if (CheckAdjacent(previousSelected)) {
                    SwapSprite(previousSelected.rend);
                }
                previousSelected.Deselect();
            }
        }
    }

    public bool CheckAdjacent(TileScript tile2) {

        adjacentDirections[0] = new Vector2(gridPosition.x - 1, gridPosition.y);
        adjacentDirections[1] = new Vector2(gridPosition.x + 1, gridPosition.y);
        adjacentDirections[2] = new Vector2(gridPosition.x, gridPosition.y - 1);
        adjacentDirections[3] = new Vector2(gridPosition.x, gridPosition.y + 1);

        for (int i = 0; i < adjacentDirections.Length; i++) {
            if(tile2.gridPosition == adjacentDirections[i]) {
                return true;
            }
        }
        return false;
    }

    public void SwapSprite(SpriteRenderer rend2) {
        if(rend.sprite == rend2.sprite) {
            return;
        }

        Sprite tempSprite = rend2.sprite;
        rend2.sprite = rend.sprite;
        rend.sprite = tempSprite;
    }    
}
