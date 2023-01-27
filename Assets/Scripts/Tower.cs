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
    int[] nextLevelPositions;

    const float reduc = 0.3f;

    public Tower(Tilemap3D tileMap, Vector3 position, float height, float upBaseReduction) : base(tileMap, position)
    {
        h = height;
        ubr = upBaseReduction;
        level = 0;

        block = MeshDrawer.Trapezoid(tileMap.tileWidth, tileMap.tileLength, h, ubr);

        RandomizeNextLevel();
        
    }
    public Tower(Tower baseTower, Vector3 position, float height) : base(baseTower.tileMap, position)
    {
        h = baseTower.h * height;
        ubr = baseTower.ubr;
        level = baseTower.level + 1;

        float nextWidth = ApplyReduction(tileMap.tileWidth, level);
        float nextLength = ApplyReduction(tileMap.tileLength, level);

        block = MeshDrawer.Trapezoid(nextWidth, nextLength, h, ubr);


        if(level < tileMap.maxTowerLevels)
            RandomizeNextLevel();
    }

    public override void Draw(Material material)
    {
        Graphics.DrawMesh(block, position, Quaternion.identity, material, 0);

        if(nextLevel != null)
        {
            int i = 0;
            while(i < nextLevel.Length)
            {
                nextLevel[i].Draw(material);

                i++;
            }
        }
    }

    private void RandomizeNextLevel()
    {
        int nextLevelTowers = Random.Range(0, 4 + 1);
        if (nextLevelTowers > 0)
        {
            nextLevel = new Tower[nextLevelTowers];
            nextLevelPositions = new int[nextLevelTowers];

            /*for(int i = 0; i < nextLevelPositions.Length; i++)
            {
                RandomizeLevelPosition(i);
            }

            //int rnd = (int)(Random.value * 1000.0f);
            //nextLevelPositions = Enumerable.Range(0, 4).OrderBy(x => rnd).Take(nextLevelTowers).ToArray();

            Debug.Log("New Tower ---------");
            for (int i = 0; i < nextLevelPositions.Length; i++)
            {
                Debug.Log("Tower " + i + ": " + nextLevelPositions[i]);
            }*/


            for (int i = 0; i < nextLevelTowers; i++)
            {
                //nextLevelPositions[i] = Random.Range(0, 4);

                float nextWidth = ApplyReduction(tileMap.tileWidth, level + 1);
                float nextLength = ApplyReduction(tileMap.tileLength, level + 1);
                float actualWidth = ApplyReduction(tileMap.tileWidth, level);
                float actualLength = ApplyReduction(tileMap.tileLength, level);
                float nextHeight = Random.Range(tileMap.heightReducMin, tileMap.heightReducMax);

                Vector3 nextPos = Vector3.zero;

                if (i == 0)
                {
                    nextPos = new Vector3(position.x - (actualWidth * ubr / 2) + nextWidth / 2,
                                                    position.y + h,
                                                    position.z - (actualLength * ubr / 2) + nextLength / 2);
                }
                else if (i == 1)
                {
                    nextPos = new Vector3(position.x + (actualWidth * ubr / 2) - nextWidth / 2,
                                                    position.y + h,
                                                    position.z - (actualLength * ubr / 2) + nextLength / 2);
                }
                else if (i == 2)
                {
                    nextPos = new Vector3(position.x - (actualWidth * ubr / 2) + nextWidth / 2,
                                                    position.y + h,
                                                    position.z + (actualLength * ubr / 2) - nextLength / 2);
                }
                else if (i == 3)
                {
                    nextPos = new Vector3(position.x + (actualWidth * ubr / 2) - nextWidth / 2,
                                                    position.y + h,
                                                    position.z + (actualLength * ubr / 2) - nextLength / 2);
                }
                else
                {
                    Debug.Log("Next position of figure not set");
                }

                nextLevel[i] = new Tower(this, nextPos, nextHeight);
            }
        }
    }

    private float ApplyReduction(float initialSize, int levelsToReduc)
    {
        float retScale = initialSize * reduc;

        if(levelsToReduc > 1)
        {
            retScale = ApplyReduction(retScale, levelsToReduc - 1);
        }
        else if(levelsToReduc <= 0)
        {
            retScale = initialSize;
        }

        return retScale;
    }

    private void RandomizeLevelPosition(int towerIndex) //DANGER!! STACK OVERFLOW!
    {
        int i = towerIndex;
        bool contains = false;

        int newPosition = Random.Range(0, 4);

        while(i >= 0 && !contains)
        { 
            if (nextLevelPositions[i] == newPosition)
            {
                contains = true;
                RandomizeLevelPosition(towerIndex); //DANGER!! STACK OVERFLOW!
            }

            i--;
        }

        if(i < 0 && !contains)
        {
            nextLevelPositions[towerIndex] = newPosition;
        }
        else
        {
            Debug.Log(i + ", " + contains);
        }
    }

}
