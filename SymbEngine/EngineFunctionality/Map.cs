using System;

namespace SymbEngine;

public class Map
{
    public Vector2 size { get; }

    public Tile[,]   TileMap { get; protected set; }
    public Entity[,]? EntityMap { get; protected set; }


    private Tile[,] GenerateTileMap(int Width, int Height)
    {
        Tile[,] TileMap = new Tile[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                TileMap[x, y] = Tile.TileDictionary["Grass"];
            }
        }

        return TileMap;
    }

    private Tile[,] GenerateTileMap(int Width, int Height, Tile baseTile)
    {
        Tile[,] TileMap = new Tile[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                TileMap[x, y] = baseTile;
            }
        }

        return TileMap;
    }

    private Entity[,] GenerateEnityMap(int Width, int Height)
    {
        Entity[,] TileMap = new Entity[Width, Height];

        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                TileMap[x, y] = null;
            }
        }

        return TileMap;
    }

    public Map(int Width, int height)
    {
        size = new Vector2(Width, height);

        //TileMap   = GenerateTileMap(Width, height);
        //EntityMap = GenerateEnityMap(Width, height);
    }

    public Map(int width, int height, Tile baseTile)
    {
        size = new Vector2(width, height);

        TileMap   = GenerateTileMap(width, height, baseTile);
        EntityMap = GenerateEnityMap(width, height);
    }
}