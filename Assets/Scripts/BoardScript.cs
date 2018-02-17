using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardScript : MonoBehaviour {

    //grid specifics
    [SerializeField]
    private int rows;
    [SerializeField]
    private int cols;

    public GameObject TilePrefab;

    [SerializeField]
    public GameObject[,] Tiles;

    public Vector2 tileSize;

    public Vector2 gridOffset;

    public Sprite[] tileSprites;

    List<GameObject> matches;

    void Start() {
        DrawGrid();
    }

    void DrawGrid() {
        Tiles = new GameObject[rows, cols];

          gridOffset.x = -(rows / 2) * (tileSize.x / 2);
          gridOffset.y = -(cols / 2) * (tileSize.y / 2);

        tileSize = TilePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size;

        Sprite[] previousLeft = new Sprite[rows];
        Sprite previousBelow = null;

        for (int x = 0; x < rows; x++) {
            for (int y = 0; y < cols; y++) {
                Vector2 pos = new Vector2(y * tileSize.x + gridOffset.x + transform.position.x, x * tileSize.y + gridOffset.y + transform.position.y);

                Tiles[x, y] = Instantiate(TilePrefab, pos, Quaternion.identity) as GameObject;

                Tiles[x, y].transform.parent = transform;
                Tiles[x, y].name = "Tile[" + x + "," + y + "]";
                Tiles[x, y].GetComponent<TileScript>().gridPosition = new Vector2(x, y);

                List<Sprite> possibleSprites = new List<Sprite>();
                possibleSprites.AddRange(tileSprites);

                possibleSprites.Remove(previousLeft[y]);
                possibleSprites.Remove(previousBelow);

                Sprite newSprite = possibleSprites[Random.Range(0, possibleSprites.Count)];
                Tiles[x, y].GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[y] = newSprite;
                previousBelow = newSprite;

            }
        }
    }

    void FindMatches(){
        matches.Clear();

        for (int j = 0; j < rows; j++) {

            int matchLength = 1;

            for (int i = 0; i < cols; i++) {
                bool checkMatch = false;


                if( i == cols) {
                    //Last Tile
                    checkMatch = true;
                }
                else {
                    //if(Tiles[i,j].GetComponent<SpriteRenderer>().sprite = )
                }
            }

        }
    }
}                