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

    public Transform player;

    [Header("Tower Params")]
    public float minTowerHeight;
    public float maxTowerHeight;
    public float upBaseReduction;
    public int maxTowerLevels;
    public float heightReducMin;
    public float heightReducMax;

    [Header("Canon Params")]
    public float minCanonHeigth;
    public float maxCanonHeigth;
    [Range(1, 6)]
    public int sphereSubdivisions;
    public float sphereRadius;

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
        tile.Draw(material);

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
        Vector3 tilePos = new Vector3(transform.position.x + tileWidth * indexTileWidth, 
                                      transform.position.y,
                                      transform.position.z + tileLength * indexTileLength);

        int tileType = Random.Range(0, 3);
        if (tileType == 0)    
        {
            tilemap[indexTileWidth, indexTileLength] = new Ground(this, tilePos);
        }
        else if(tileType == 1)
        {
            tilemap[indexTileWidth, indexTileLength] = new Tower(this, tilePos, Random.Range(minTowerHeight, maxTowerHeight), upBaseReduction);    
        }
        else
        {
            tilemap[indexTileWidth, indexTileLength] = new Canon(this, tilePos, Random.Range(minCanonHeigth, maxCanonHeigth), upBaseReduction);
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
