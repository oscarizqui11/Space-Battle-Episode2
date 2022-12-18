using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyEngine;

public class Ground : Tile3D
{
    //public Material material;

    Mesh plane;

    public Ground(Tilemap3D tileMap, Vector3 position): base(tileMap, position)
    {
        plane = MeshDrawer.Plane(tileMap.tileWidth, tileMap.tileLength);
    }

    public override void Draw(Material material)
    {
        Graphics.DrawMesh(plane, position, Quaternion.identity, material, 0);
    }

}
