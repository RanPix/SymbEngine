using System;

namespace SymbEngine;

public static class Engine
{
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

    public class GameSettings
    {
        int renderWidth { get; }
        int renderHeight { get; }

        public GameSettings(int RenderWidth, int RenderHeight)
        {
            renderWidth  = RenderWidth;
            renderHeight = RenderHeight;
        }
    }

    public class Tile
    {
        string Name { get; }
        string Symbol { get; }
        ConsoleColor Color { get; }

        public Tile(string Name, string Symbol, ConsoleColor Color)
        {
            this.Name = Name;
            this.Symbol = Symbol;
            this.Color = Color;
        }

        public static Dictionary<string, Tile> TileDictionary { get; } = new Dictionary<string, Tile>()
        {
            ["Grass"] = new Tile("Grass", ".", ConsoleColor.Green)
        };
    }

    public class Entity
    {
        string Name   { get; }
        string Symbol { get; } = "";
        ConsoleColor Color { get; }

        public Entity(string Name, string Symbol, ConsoleColor Color)
        {
            this.Name = Name;
            this.Symbol = Symbol;
            this.Color = Color;
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
        public static void RenderMap(Map map)
        {
            
        }
    }
} 