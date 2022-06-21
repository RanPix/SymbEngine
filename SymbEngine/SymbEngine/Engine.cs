using System;

namespace SymbEngine;

public class Vector2
{
    public int x;
    public int y;

    public Vector2(int X, int Y)
    {
        x = X;
        y = Y;
    }

    public static Vector2 operator +(Vector2 vector1, Vector2 vector2) => new Vector2(vector1.x + vector2.x, vector1.y + vector2.y);
    public static Vector2 operator -(Vector2 vector1, Vector2 vector2) => new Vector2(vector1.x - vector2.x, vector1.y - vector2.y);

    public static Vector2 operator *(Vector2 vector, int index) => new Vector2(vector.x * index, vector.y * index);
    public static Vector2 operator *(Vector2 vector, double index) => new Vector2((int)Math.Round((double)vector.x * index), (int)Math.Round((double)vector.y * index));
    public static Vector2 operator /(Vector2 vector, int index) => new Vector2(vector.x / index, vector.y / index);
    public static Vector2 operator /(Vector2 vector, double index) => new Vector2((int)Math.Round((double)vector.x / index), (int)Math.Round((double)vector.y / index));

    public static Vector2 Lerp(Vector2 start, Vector2 end, float T) => start + (end - start) * T;

    public static Vector2 Normalize(Vector2 vector)
    {
        Vector2 result = new Vector2(0, 0);
        double timesToScale = Math.Pow((vector.x * vector.x + vector.y * vector.y), -0.5);
        result.x = (int)Math.Round(vector.x * timesToScale);
        result.y = (int)Math.Round(vector.y * timesToScale);
        return result;
    }
}

public static class GameSettings
{
    public static int renderWidth { public get; protected set; }
    public static int renderHeight { public get; protected set; }
}

public class Tile
{//asd
    string same { get; }
    string symbol { get; }
    ConsoleColor color { get; }

    public Tile(string Name, string Symbol, ConsoleColor Color)
    {
        name = Name;
        symbol = Symbol;
        color = Color;
    }

    public static Dictionary<string, Tile> TileDictionary { get; } = new Dictionary<string, Tile>()
    {
        ["Grass"] = new Tile("Grass", ".", ConsoleColor.Green)
    };
}

public class Entity
{
    string name   { get; }
    string symbol { get; } = "";
    ConsoleColor color { get; }

    public Vector2 position { get; set; }

    public Entity(string Name, string Symbol, ConsoleColor Color, Vector2 Position)
    {
        name = Name;
        symbol = Symbol;
        color = Color;

        position = Position
    }

    public static Dictionary<string, Entity> Bestiary { get; } = new Dictionary<string, Entity>()
    {
        ["Void"] = new Entity("Void", " ", ConsoleColor.Black)
    };
}

public class Map
{
    Vector2 size { get; }

    public Tile[,]   TileMap   { get; protected set; }
    public Entity[,] EntityMap { get; protected set; }


    private Tile[,] GenerateTileMap(int Width, int Height)
    {
        Tile[,] TileMap = new Tile[Width, Height];

        for(int y = 0; y < Height; y++)
        {
            for(int x = 0; x < Width; x++)
            {
                TileMap[x, y] = Tile.TileDictionary["Grass"];
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
                TileMap[x, y] = Entity.Bestiary["Void"];
            }
        }

        return TileMap;
    }

    public Map(int Width, int Height)
    {
        size = new Vector2(Width, Height);

        TileMap   = GenerateTileMap(Width, Height);
        EntityMap = GenerateEnityMap(Width, Height);
    }
}

public static class Renderer
{
    public static class Camera
    {
        public Vector2 position { get; protected set; } = new Vector2((int)(GameSettings.renderWidth/2), (int)(GameSettings.renderHeight/2)); // Regular Case

        public Entity? entityToBind { get; protected set; } = null;

        bool isFollowingEntity { get; set; } = false;

        public void MoveCamera()
        {
            if (isFollowingEntity && entityToBind != null)
            {
                this.position = entityToBind.position;
            }
        }
    }

    public static void RenderMap(Map map)
    {
            
    }
}