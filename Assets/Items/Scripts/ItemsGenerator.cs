using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator _mazeGenerator;
    [SerializeField]
    private GameObject _mapPrefab;
    [SerializeField]
    private GameObject _compassPrefab;

    private int[,] _mazeGrid;
    private int _width;
    private int _height;


    private void Awake()
    {
        _mazeGrid = _mazeGenerator.GetMazeGrid;
        _width = _mazeGrid.GetLength(0);
        _height = _mazeGrid.GetLength(1);

        CreateMap();
        CreateCompasses();
    }

    private void CreateMap()
    {
        int x = Random.Range(0, _width / 2) + _width / 4;
        int y = Random.Range(0, _height / 2) + _height / 4;

        Place(x, y, _mapPrefab.transform);
    }

    private void CreateCompasses()
    {
        for (int i = 0; i < _width * _height / 400; i++)
            CreateCompass();
    }

    private void CreateCompass()
    {
        int x = Random.Range(1, _width - 1);
        int y = Random.Range(1, _height - 1);

        var compass = Instantiate(_compassPrefab, this.transform);
        Place(x, y, compass.transform);
    }

    private void Place(int x, int y, Transform transform)
    {
        if (_mazeGrid[x, y] == 1)
        {
            if (_mazeGrid[x + 1, y] == 0) x++;
            else if (_mazeGrid[x - 1, y] == 0) x--;
            else if (_mazeGrid[x, y + 1] == 0) y++;
            else if (_mazeGrid[x, y - 1] == 0) y--;
        }

        transform.position = new Vector3(x * 2, y * 2, 0);
    }
}
