using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap3D : MonoBehaviour
{
    public Material material;

    public int numTileWidth;
    public int numTileLength;

    public float tileWidth;
    public float tileLength;

    private Tile3D[,] tilemap;
    private int indexTileWidth;
    private int indexTileLength;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = new Tile3D[numTileWidth, numTileLength];

        indexTileWidth = 0;
        indexTileLength = 0;

        InitializeTilesRecursive();
    }

    // Update is called once per frame
    void Update()
    {
        indexTileWidth = 0;
        indexTileLength = 0;

        DrawTile(tilemap[indexTileWidth, indexTileLength]);
    }

    private void DrawTile(Tile3D tile)
    {
        tile.Draw(transform.position.x + tileWidth * indexTileWidth, transform.position.y, transform.position.z + tileLength * indexTileLength, material);

        if(indexTileWidth + 1 < numTileWidth)
        {
            indexTileWidth++;

            DrawTile(tilemap[indexTileWidth, indexTileLength]);
        }
        else if(indexTileLength + 1 < numTileLength)
        {
            indexTileWidth = 0;
            indexTileLength++;

            DrawTile(tilemap[indexTileWidth, indexTileLength]);
        }
    }

    private void InitializeTilesRecursive()
    {
        if(Random.Range(0, 1 + 1) == 0)    
        {
            tilemap[indexTileWidth, indexTileLength] = new Ground(tileWidth, tileLength);
        }
        else
        {
            tilemap[indexTileWidth, indexTileLength] = new Tower(tileWidth, tileLength);
        }


        if (indexTileWidth + 1 < numTileWidth)
        {
            indexTileWidth++;

            InitializeTilesRecursive();
        }
        else if (indexTileLength + 1 < numTileLength)
        {
            indexTileWidth = 0;
            indexTileLength++;

            InitializeTilesRecursive();
        }
    }

}
