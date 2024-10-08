using System.Linq;
using UnityEngine;

public class ChaserSpawner : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator _maze;
    [SerializeField]
    private int _trapDensity = 120;
    [SerializeField]
    private GameObject _trapPrefab;

    private int[,] _mazeGrid;
    private int _width;
    private int _height;

    private void Awake()
    {
        _mazeGrid = _maze.GetMazeGrid;
        _width = MazeConfig.MazeWidth;
        _height = MazeConfig.MazeHeight;

        SpawnTraps();
    }

    private void SpawnTraps()
    {
        var trapCount = _width * _height / _trapDensity;

        Enumerable.Range(0, trapCount).ToList().ForEach(_ => SpawTrap());
    }

    private void SpawTrap()
    {
        var x = RandomOdd(_width)*2;
        var y = RandomOdd(_height)*2;
        Instantiate(_trapPrefab, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0), this.transform);
    }

    private int RandomOdd(int range)
    {
        var num = Random.Range(1, range-2);
        return num % 2 == 0 ? num + 1 : num;
    }
}
