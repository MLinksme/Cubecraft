﻿using Cubecraft.Data.World;
using Cubecraft.Data.World.Blocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    int size = 0;
    private Chunk[] chunks = new Chunk[16];
    public GameObject chunkPrefab;
    public World world;
    public int posX, posZ;
    public IEnumerator CreateColumn(Vector2Int pos, ChunkColumn column)
    {
        this.posX = pos.x;
        this.posZ = pos.y;
        Chunk newChunk = null;
        for (int chunkY = 0; chunkY < ChunkColumn.ColumnSize; chunkY++)
        {
            Vector3 worldPos = new Vector3(posX * 16, chunkY * 16, posZ * 16);
            ChunkData chunk = column[chunkY];
            size++;
            GameObject newChunkObject = Instantiate(chunkPrefab, worldPos, Quaternion.Euler(Vector3.zero));
            newChunkObject.transform.SetParent(gameObject.transform);

            newChunk = newChunkObject.GetComponent<Chunk>();
            newChunk.position = chunkY;
            newChunk.column = this;

            InitializeBlocks(newChunk, chunk);

            chunks[chunkY] = newChunk;
            world.calculateQueue.Add(newChunk);
            yield return null;
        }
    }
    public static void InitializeBlocks(Chunk newChunk, ChunkData chunk)
    {
        for (int blockX = 0; blockX < Chunk.chunkSize; blockX++)
        {
            for (int blockY = 0; blockY < Chunk.chunkSize; blockY++)
            {
                for (int blockZ = 0; blockZ < Chunk.chunkSize; blockZ++)
                {
                    newChunk.SetBlock(blockX, blockY, blockZ, chunk != null ? Global.blockDic.GetBlock(chunk[blockX, blockY, blockZ].ID) : BlockData.AIR);
                }
            }
        }
    }
    public Chunk this[int index]
    {
        get { return chunks[index]; }
    }
}
