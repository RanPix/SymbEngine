namespace SymbEngine;

//Gimmigoodies ok

public class Vector2
{
    public int x { get; set; }
    public int y { get; set; }

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
    public static int renderWidth { get; set; }
    public static int renderHeight { get; set; }
}

public class Tile
{
    public string name { get; }
    public string symbol { get; }
    public ConsoleColor color { get; }

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
    public string name   { get; }
    public string symbol { get; } = "";
    public ConsoleColor color { get; }

    public Vector2? position { get; set; }

    public Entity(string Name, string Symbol, ConsoleColor Color, Vector2 Position)
    {
        name = Name;
        symbol = Symbol;
        color = Color;

        position = Position;
    }

    public static Dictionary<string, Entity> Bestiary { get; } = new Dictionary<string, Entity>()
    {
        ["Void"] = new Entity("Void", " ", ConsoleColor.Black, null)
    };
}

public class Map
{
    public Vector2 size { get; }

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
    public class Camera
    {
        public Vector2 position { get; protected set; } = new Vector2(GameSettings.renderWidth / 2, GameSettings.renderHeight / 2); // Regular Case

        public Entity? entityToBind { get; set; } = null;

        bool isFollowingEntity { get; set; } = true;

        private void GetCameraInBound(Map map)
        {
            if (GameSettings.renderWidth  > map.size.x) GameSettings.renderWidth  = map.size.x; position.x = map.size.x / 2;
            if (GameSettings.renderHeight > map.size.y) GameSettings.renderHeight = map.size.y; position.y = map.size.y / 2;

            bool sizeIsOne =  map.size.x == 1;
                 sizeIsOne &= map.size.y == 1;
            
            if (sizeIsOne) return;

            position.x = Math.Clamp(position.x, (int)Math.Ceiling((double)GameSettings.renderWidth/2),    (map.size.x - ((int)Math.Ceiling((double)GameSettings.renderWidth / 2))));
            position.y = Math.Clamp(position.y, (int)Math.Ceiling((double)GameSettings.renderHeight / 2), (map.size.y - ((int)Math.Ceiling((double)GameSettings.renderHeight / 2))));
        }
        
        public void MoveCamera(Map map)
        {
            if (isFollowingEntity && entityToBind != null)
            {
                this.position = entityToBind.position;
            }
            GetCameraInBound(map);
        }

        public void MoveCamera(Map map, Vector2 position)
        {
            if(isFollowingEntity && entityToBind != null)
            {
                this.position = entityToBind.position;
            }
            GetCameraInBound(map);
        }
    }

    public static void RenderMap(Map map)
    {
            
    }
}
