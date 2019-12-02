using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BlockSpawner
{
    public enum ObjType {None, Monster, Block }
    [SerializeField]
    public GameObject BlockPrefab;
    [SerializeField]
    public Color BlockColour;
    [SerializeField]
    public ObjType ObjectType;
}
