
namespace SymbEngine;

public static class Renderer
{
    //private static Thread renderer = new Thread(RenderMap);

    public static void RenderMap(Map map)
    {
        Console.SetCursorPosition(0, 0);

        string output = "";

        int cameraDelayX = map.size.x - GameSettings.renderWidth;
        int cameraDelayY = map.size.y - GameSettings.renderHeight;

        for (int y = 0; y < 13; y++)
        {
            for (int x = 0; x < 50; x++)
            {
                output += $"\x1b[38;2;{21};{32};{255}me";
            }
            output += "\n";
        }
        Console.Write(output);
    }
}

public class Camera
{
    public Vector2 position { get; protected set; } = new Vector2(GameSettings.renderWidth / 2, GameSettings.renderHeight / 2); // Regular Case

    public Entity? entityToBind { get; set; } = null;

    bool isFollowingEntity { get; set; } = true;

    private void GetCameraInBound(Map map)
    {
        if (GameSettings.renderWidth > map.size.x) GameSettings.renderWidth = map.size.x; position.x = map.size.x / 2;
        if (GameSettings.renderHeight > map.size.y) GameSettings.renderHeight = map.size.y; position.y = map.size.y / 2;

        bool sizeIsOne = map.size.x == 1;
        sizeIsOne &= map.size.y == 1;

        if (sizeIsOne) return;

        position.x = Math.Clamp(position.x, (int)Math.Ceiling((double)GameSettings.renderWidth / 2), (map.size.x - ((int)Math.Ceiling((double)GameSettings.renderWidth / 2))));
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
        if (isFollowingEntity && entityToBind != null)
        {
            this.position = entityToBind.position;
        }
        GetCameraInBound(map);
    }
}