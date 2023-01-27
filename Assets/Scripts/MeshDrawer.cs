using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace MyEngine
{
    public struct MeshDrawer
    {
        private static void Normalize(Vector3[] vertices, Vector3[] normals)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                normals[i] = vertices[i] = vertices[i].normalized;
            }
        }

        private static void CreateUV(Vector3[] vertices, Vector2[] uv)
        {
            float previousX = 1.0f;
            for (int i = 0; i < vertices.Length; i++)
            {
                Vector3 v = vertices[i];
                if(v.x == previousX)
                {
                    uv[i - 1].x = 1f;
                }
                previousX = v.x;
                Vector2 textureCoordinates;
                textureCoordinates.x = Mathf.Atan2(v.x, v.z) / (-2f * Mathf.PI);
                if(textureCoordinates.x < 0f)
                {
                    textureCoordinates.x += 1f;
                }
                textureCoordinates.y = Mathf.Asin(v.y) / Mathf.PI + 0.5f;
                uv[i] = textureCoordinates;
            }

            uv[vertices.Length - 4].x = uv[0].x = 0.125f;
            uv[vertices.Length - 3].x = uv[1].x = 0.375f;
            uv[vertices.Length - 2].x = uv[2].x = 0.625f;
            uv[vertices.Length - 1].x = uv[3].x = 0.875f;
        }

        public static Mesh Plane(float width, float length)
        {
            Mesh plane;

            Vector3[] vertexs;
            int[] triangles;
            Vector2[] uvs;

            plane = new Mesh();

            vertexs = new Vector3[4];

            vertexs[0] = new Vector3(-width / 2, 0, -length / 2);
            vertexs[1] = new Vector3(width / 2, 0, -length / 2);
            vertexs[2] = new Vector3(width / 2, 0, length / 2);
            vertexs[3] = new Vector3(-width / 2, 0, length / 2);

            plane.vertices = vertexs;

            triangles = new int[2 * 3];

            triangles[0] = 2;
            triangles[1] = 1;
            triangles[2] = 0;
            triangles[3] = 3;
            triangles[4] = 2;
            triangles[5] = 0;

            plane.triangles = triangles;

            uvs = new Vector2[4];

            uvs[0] = new Vector2(0, 0);
            uvs[1] = new Vector2(1, 0);
            uvs[2] = new Vector2(1, 1);
            uvs[3] = new Vector2(0, 1);

            plane.uv = uvs;

            plane.RecalculateNormals();
            plane.RecalculateBounds();

            return plane;
        }

        public static Mesh Trapezoid(float baseWidth, float baseLength, float height, float base2reduction)
        {
            Mesh block;

            Vector3[] vertexs;
            int[] triangles;
            Vector2[] uvs;

            block = new Mesh();

            vertexs = new Vector3[8];

            vertexs[0] = new Vector3(-baseWidth / 2, 0, -baseLength / 2);
            vertexs[1] = new Vector3(baseWidth / 2, 0, -baseLength / 2);
            vertexs[2] = new Vector3(baseWidth / 2, 0, baseLength / 2);
            vertexs[3] = new Vector3(-baseWidth / 2, 0, baseLength / 2);
            vertexs[4] = new Vector3(-base2reduction * baseWidth / 2, height, -base2reduction * baseLength / 2);
            vertexs[5] = new Vector3(base2reduction * baseWidth / 2, height, -base2reduction * baseLength / 2);
            vertexs[6] = new Vector3(base2reduction * baseWidth / 2, height, base2reduction * baseLength / 2);
            vertexs[7] = new Vector3(-base2reduction * baseWidth / 2, height, base2reduction * baseLength / 2);
            block.vertices = vertexs;

            triangles = new int[6 * 2 * 3];

            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;
            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;

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

        public static Mesh Octahedron(int subdivisions, float radius)
        {
            Vector3[] vertexs =
            {
                Vector3.down,
                Vector3.down,
                Vector3.down,
                Vector3.down,
                Vector3.forward,
                Vector3.left,
                Vector3.back,
                Vector3.right,
                Vector3.forward,
                Vector3.up,
                Vector3.up,
                Vector3.up,
                Vector3.up,
            };

            int[] triangles =
            {
                0, 4, 5,
                1, 5, 6,
                2, 6, 7,
                3, 7, 8,

                9, 5, 4,
               10, 6, 5,
               11, 7, 6,
               12, 8, 7
            };

            //Vector3[] normals = new Vector3[vertexs.Length];
            //Normalize(vertexs, normals);

            Vector2[] uv = new Vector2[vertexs.Length];
            CreateUV(vertexs, uv);

            if(radius != 1f)
            {
                for(int i = 0; i < vertexs.Length; i++)
                {
                    vertexs[i] *= radius;
                }
            }

            Mesh mesh = new Mesh();
            mesh.vertices = vertexs;
            //mesh.normals = normals;
            mesh.uv = uv;
            mesh.triangles = triangles;

            mesh.RecalculateNormals();
            //mesh.RecalculateBounds();

            return mesh;
        }
    }
}