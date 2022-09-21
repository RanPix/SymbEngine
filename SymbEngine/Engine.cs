namespace SymbEngine;



public class Engine // rename 100%
{
    Camera cam = new Camera();
    Map map = new Map(200, 200);

    public void GameLoop()
    {
        while (true)
        {
            Renderer.RenderMap(map);
        }
    }
}