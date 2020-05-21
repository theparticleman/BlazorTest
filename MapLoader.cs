using System;
using System.IO;

public class MapLoader
{
    public static GameTiles[,] Load(string mapString)
    {
        var loadedMap = new GameTiles[16, 11];
        var sr = new StringReader(mapString);
        sr.ReadLine();
        for (int y = 0; y < 11; y++)
        {
            var line = sr.ReadLine();
            for (int x = 0; x < 16; x++)
            {
                loadedMap[x, y] = ConvertToGameTile(line[x]);                
            }
        }
        return loadedMap;
    }

    private static GameTiles ConvertToGameTile(char c)
    {
        switch(c)
        {
            case '.':
                return GameTiles.Empty;
            case 'g':
                return GameTiles.GreenRock;
            case 'c':
                return GameTiles.Cave;
            default:
                throw new ArgumentException($"Unexpected map value '{c}'");
        }
    }
}