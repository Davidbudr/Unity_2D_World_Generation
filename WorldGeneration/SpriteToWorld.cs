using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteToWorld : MonoBehaviour
{
    public Sprite Map;

    public List<BlockSpawner> PrefabsList;

    public GameObject BackgroundBlock;

    public BlockSpawner PlayerPrefab;

    public GameObject mother;
    private GameObject Enemies;
    private GameObject Blocks;
    private GameObject Background;

    public void SpawnWorld()
    {

        GameObject mom = new GameObject("Mother");
        mother = mom;

        GameObject babyE = new GameObject("Enemies");
        Enemies = babyE;
        Enemies.transform.parent = mother.transform;

        GameObject babyB = new GameObject("Blocks");
        Blocks = babyB;
        Blocks.transform.parent = mother.transform;

        GameObject babyBackribs = new GameObject("Background");
        Background = babyBackribs;
        Background.transform.parent = mother.transform;

        int TexwSize = Map.texture.width;
        int TexhSize = Map.texture.height;


        for (var i = 0; i < Map.texture.width; i++)
        {
            for (var j = 0; j < Map.texture.height; j++)
            {
                Color _c = Map.texture.GetPixel(i, j);

                Vector2 hm = new Vector2(i + (TexwSize), j + (TexhSize));



                //find matching colour
                bool colFound = false;
                while (!colFound)
                {
                    for (var _cl = 0; _cl < PrefabsList.ToArray().Length; _cl++)
                    {
                        if (PrefabsList[_cl].BlockColour == _c)
                        {
                            GameObject blk = Instantiate(PrefabsList[_cl].BlockPrefab);
                            blk.transform.parent = (PrefabsList[_cl].ObjectType == BlockSpawner.ObjType.Monster)? Enemies.transform : ((PrefabsList[_cl].ObjectType == BlockSpawner.ObjType.Block)? Blocks.transform : mother.transform);
                            blk.transform.position = hm;

                            GameObject bck = Instantiate(BackgroundBlock);
                            bck.transform.parent = Background.transform;
                            bck.transform.position = hm;
                            bck.GetComponent<SpriteRenderer>().sortingOrder = -100;

                        }
                        if (_c == Color.clear)
                        {
                            colFound = true;
                            break;
                        }
                    }
                    _c = Color.clear;
                }
            }
        }


    }

    public void DeleteTheWorld()
    {
        DestroyImmediate(GameObject.Find("Mother"));
        DestroyImmediate(GameObject.FindGameObjectWithTag("Player"));
    }
    public void SpawnPlayer()
    {
        bool _unspawned = true;
        GameObject _p;
        int TexwSize = Map.texture.width;
        int TexhSize = Map.texture.height;
        Vector2 pos = Vector2.zero;

        for (var i = 0; i < Map.texture.width; i++)
        {
            if (_unspawned)
            {
                for (var j = 0; j < Map.texture.height; j++)
                {
                    pos = new Vector2(i + (TexwSize), j + (TexhSize));
                    Color _c = Map.texture.GetPixel(i, j);
                    if (_c == PlayerPrefab.BlockColour)
                    {
                        _p = Instantiate(PlayerPrefab.BlockPrefab);
                        _p.transform.position = Vector2.zero;
                        _unspawned = false;
                        GameObject bck = Instantiate(BackgroundBlock);
                        bck.transform.parent = Background.transform;
                        bck.transform.position = pos;
                        bck.GetComponent<SpriteRenderer>().sortingOrder = -100;
                        break;
                    }
                }
            }
            else
            {
                break;
            }

        }
        mother.transform.position = mother.transform.position - (Vector3)pos;
    }
}
