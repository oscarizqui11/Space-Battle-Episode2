using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class Tower : Tile3D
{
    //public Material material;

    Mesh block;

    float h;
    float ubr;
    int level;

    Tower[] nextLevel;

    const float reduc = 0.3f;

    public Tower(Tilemap3D tileMap, Vector3 position, float height, float upBaseReduction) : base(tileMap, position)
    {
        h = height;
        ubr = upBaseReduction;
        level = 0;

        block = MeshDrawer.Trapezoid(tileMap.tileWidth, tileMap.tileLength, h, ubr);

        int nextLevelTowers = Random.Range(0,4+1);
        if(nextLevelTowers > 0)
        {
            nextLevel = new Tower[nextLevelTowers];

            for(int i = 0; i < nextLevelTowers; i++)
            {
                //nextLevel[i] = new Tower(this, );
            }
        }
    }
    public Tower(Tower baseTower, Vector3 position, float height) : base(baseTower.tileMap, position)
    {
        h = height;
        ubr = baseTower.ubr;
        level = baseTower.level + 1;
    }

    public override void Draw(Material material)
    {
        Graphics.DrawMesh(block, position, Quaternion.identity, material, 0);

        

        float nextWidth = reduc;
        float nextLength = reduc;
        float nextHeight = Random.Range(tileMap.heightReducMin, tileMap.heightReducMax);
        Vector3 size = new Vector3(nextWidth, nextHeight, nextLength);

        Vector3 nextPos = new Vector3(position.x - (tileMap.tileWidth * ubr / 2) + nextWidth * tileMap.tileWidth / 2,
                                      position.y + h,
                                      position.z - (tileMap.tileLength * ubr / 2) + nextWidth * tileMap.tileLength / 2);

        Graphics.DrawMesh(block, Matrix4x4.TRS(nextPos, Quaternion.Euler(0.0f, 0.0f, 0.0f), size), material, 0);
    }

}
