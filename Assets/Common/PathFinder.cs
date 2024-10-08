using System.Collections.Generic;
using UnityEngine;

public static class PathFinder
{
    private static int[,] _mazeGrid;

    public static void SetMazeGrid(int[,] mazeGrid)
        => _mazeGrid = mazeGrid;

    public static List<Vector2Int> FindPath(Vector2Int start, Vector2Int end)
    {
        int rows = _mazeGrid.GetLength(0);
        int cols = _mazeGrid.GetLength(1);

        Queue<Vector2Int> toVisit = new Queue<Vector2Int>();
        toVisit.Enqueue(start);

        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        cameFrom[start] = start;

        while (toVisit.Count > 0)
        {
            Vector2Int current = toVisit.Dequeue();

            if (current == end)
            {
                return ReconstructPath(cameFrom, start, end);
            }

            foreach (Vector2Int neighbor in GetNeighbors(current, rows, cols))
            {
                if (_mazeGrid[neighbor.x, neighbor.y] == 1 || cameFrom.ContainsKey(neighbor))
                    continue;

                cameFrom[neighbor] = current;
                toVisit.Enqueue(neighbor);
            }
        }

        return null;
    }

    private static List<Vector2Int> GetNeighbors(Vector2Int position, int rows, int cols)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();

        if (position.x - 1 >= 0) neighbors.Add(new Vector2Int(position.x - 1, position.y)); // Left
        if (position.x + 1 < rows) neighbors.Add(new Vector2Int(position.x + 1, position.y)); // Right
        if (position.y - 1 >= 0) neighbors.Add(new Vector2Int(position.x, position.y - 1)); // Down
        if (position.y + 1 < cols) neighbors.Add(new Vector2Int(position.x, position.y + 1)); // Up

        return neighbors;
    }

    private static List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int current = end;

        while (current != start)
        {
            path.Add(current);
            current = cameFrom[current];
        }

        path.Add(start);
        path.Reverse();

        return path;
    }

}
