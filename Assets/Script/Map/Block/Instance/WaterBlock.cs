﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Cubecraft.Data.World.Blocks
{
    class WaterBlock : Block
    {
        public override int BlockID { get { return 9; } }
        public override bool Solid { get { return false; } }

        public override bool Transparent { get { return true; } }

        public override void SetMeshUp(Chunk chunk, int x, int y, int z)
        {
            chunk.objectMeshData.useRenderDataForCol = false;
            Block upblock = chunk.GetBlock(x, y + 1, z);
            if(upblock.BlockID == 0)
            {
                FaceDataUpSurface(x, y, z, chunk.objectMeshData);
                FaceDataDownSurface(x, y, z, chunk.objectMeshData);
            }
        }
        public override void SetMeshDown(Chunk chunk, int x, int y, int z) { }
        public override void SetMeshBack(Chunk chunk, int x, int y, int z) { }
        public override void SetMeshFront(Chunk chunk, int x, int y, int z) { }
        public override void SetMeshLeft(Chunk chunk, int x, int y, int z) { }
        public override void SetMeshRight(Chunk chunk, int x, int y, int z) { }
        private MeshData FaceDataFrontSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

            meshData.AddQuadTriangles();
            meshData.uv.AddRange(FaceUVs(Direction.Front, this));
            return meshData;
        }
        private MeshData FaceDataBackSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));

            meshData.AddQuadTriangles();
            //Add the following line to every FaceData function with the direction of the face
            meshData.uv.AddRange(FaceUVs(Direction.Back, this));
            return meshData;
        }
        private MeshData FaceDataLeftSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));

            meshData.AddQuadTriangles();
            //Add the following line to every FaceData function with the direction of the face
            meshData.uv.AddRange(FaceUVs(Direction.Left, this));
            return meshData;
        }
        private MeshData FaceDataRightSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));

            meshData.AddQuadTriangles();
            //Add the following line to every FaceData function with the direction of the face
            meshData.uv.AddRange(FaceUVs(Direction.Right, this));
            return meshData;
        }
        private MeshData FaceDataUpSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z - 0.5f));

            meshData.AddQuadTriangles();
            meshData.uv.AddRange(FaceUVs(Direction.Up, this));
            return meshData;
        }
        private MeshData FaceDataDownSurface(int x, int y, int z, MeshData meshData)
        {
            meshData.AddVertex(new Vector3(x - 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z - 0.5f));
            meshData.AddVertex(new Vector3(x + 0.5f, y, z + 0.5f));
            meshData.AddVertex(new Vector3(x - 0.5f, y, z + 0.5f));

            meshData.AddQuadTriangles();
            //Add the following line to every FaceData function with the direction of the face
            meshData.uv.AddRange(FaceUVs(Direction.Down, this));
            return meshData;
        }
        public override Tile TexturePosition(Direction direction)
        {
            Tile tile = new Tile();
            tile.x = 3;
            tile.y = 2;
            return tile;
        }
    }
}
