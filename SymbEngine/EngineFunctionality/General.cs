
namespace SymbEngine;

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
