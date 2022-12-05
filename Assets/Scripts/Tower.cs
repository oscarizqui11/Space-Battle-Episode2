using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Tile3D
{
    //public Material material;

    Mesh tower;
    
    Mesh tube;

    public Tower(float width, float length)// : base(width, length)
    {
        tower = CreateTower(width, length);
    }

    public Mesh CreateTower(float width, float length)
    {
        Mesh block;
        Vector3[] vertexs;
        int[] triangles;
        Vector2[] uvs;

        block = new Mesh();

        vertexs = new Vector3[8];

        vertexs[0] = new Vector3(-width / 2, 0, -length / 2);
        vertexs[1] = new Vector3(width / 2, 0, -length / 2);
        vertexs[2] = new Vector3(width / 2, 0, length / 2);
        vertexs[3] = new Vector3(-width / 2, 0, length / 2);
        vertexs[4] = new Vector3(-0.7f * width / 2, 5, -0.7f * length / 2);
        vertexs[5] = new Vector3(0.7f * width / 2, 5, -0.7f * length / 2);
        vertexs[6] = new Vector3(0.7f * width / 2, 5, 0.7f * length / 2);
        vertexs[7] = new Vector3(-0.7f * width / 2, 5, 0.7f * length / 2);

        block.vertices = vertexs;

        triangles = new int[6 * 2 * 3];

        triangles[0] = 2;
        triangles[1] = 1;
        triangles[2] = 0;
        triangles[3] = 3;
        triangles[4] = 2;
        triangles[5] = 0;

        triangles[6] = 1;
        triangles[7] = 5;
        triangles[8] = 2;
        triangles[9] = 2;
        triangles[10] = 5;
        triangles[11] = 6;

        triangles[12] = 0;
        triangles[13] = 4;
        triangles[14] = 5;
        triangles[15] = 0;
        triangles[16] = 5;
        triangles[17] = 1;

        triangles[18] = 3;
        triangles[19] = 7;
        triangles[20] = 0;
        triangles[21] = 0;
        triangles[22] = 7;
        triangles[23] = 4;

        triangles[24] = 3;
        triangles[25] = 6;
        triangles[26] = 7;
        triangles[27] = 3;
        triangles[28] = 2;
        triangles[29] = 6;

        triangles[30] = 4;
        triangles[31] = 7;
        triangles[32] = 5;
        triangles[33] = 7;
        triangles[34] = 6;
        triangles[35] = 5;

        block.triangles = triangles;

        uvs = new Vector2[8];

        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(1, 1);
        uvs[3] = new Vector2(0, 1);

        uvs[4] = new Vector2(0, 0);
        uvs[5] = new Vector2(1, 0);
        uvs[6] = new Vector2(1, 1);
        uvs[7] = new Vector2(0, 1);

        block.uv = uvs;

        block.RecalculateNormals();
        block.RecalculateBounds();

        return block;
    }

    public override void Draw(float posX, float posY, float posZ, Material material)
    {
        Graphics.DrawMesh(tower, new Vector3(posX, posY, posZ), Quaternion.identity, material, 0);
    }

}
