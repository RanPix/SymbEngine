
namespace SymbEngine;

public class Base

{
    private string       name;
    private string       symbol;
    private ConsoleColor color;

    /*public Base(string Name, string Symbol, ConsoleColor Color)
    {
        name = Name;
        symbol = Symbol;
        color = Color;
    }*/
}

public class Tile : Base
{
    public ConsoleColor backgroundColor { get; }

    /*public Tile(string Name, string Symbol, ConsoleColor Color, ConsoleColor BackgroundColor)
    {
        name   = Name;
        symbol = Symbol;
        color  = Color;

        backgroundColor = BackgroundColor;
    }*/

    public static Dictionary<string, Tile> TileDictionary { get; } = new Dictionary<string, Tile>()
    {
        //["Grass"] = new Tile("Grass", ".", ConsoleColor.Green, ConsoleColor.Black)
    };
}

public class Entity : Base
{
    public Vector2? position { get; set; }

    /*public Entity(string Name, string Symbol, ConsoleColor Color, Vector2 Position)
    {
        name   = Name;
        symbol = Symbol;
        color  = Color;

        position = Position;
    }*/

    public static Dictionary<string, Entity> Bestiary { get; } = new Dictionary<string, Entity>()
    {
        // ["Void"] = new Entity("Void", " ", ConsoleColor.Black, null)
    };
}
