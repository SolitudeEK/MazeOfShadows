using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{ 
    [SerializeField]
    private int _width = 5;
    [SerializeField]
    private int _height = 5;
    [SerializeField]
    private float noiseScale = 0.1f;
    [SerializeField]
    private GameObject _wallPrefab;
    [SerializeField]
    private GameObject _groundPrefab;

    private int[,] _mazeGrid;
    private (int X, int Y) _finish;
    private (int X, int Y) _start;
    private List<Vector2Int> _wallsList;
    public int[,] GetMazeGrid()
        => _mazeGrid;

    void Awake()
    {
        _mazeGrid = new int[_width, _height];

        CreateOuterWalls();
        //CreateFinish();
        //GenerateMaze();
        Divide(1, 1, _width - 2, _height - 2);
        RenderMaze();
    }


    private void CreateOuterWalls()
    {
        for (int i = 0; i < _width; i++)
        {
            _mazeGrid[i, 0] = 1;
            _mazeGrid[i, _height - 1] = 1;
        }

        for (int i = 0; i < _height; i++)
        {
            _mazeGrid[0, i] = 1;
            _mazeGrid[_width - 1, i] = 1;
        }
    }

    private void CreateFinish()
    {
        int x = Random.Range(0, _width-1);
        int y = Random.Range(0, _height-1);

        _mazeGrid[x, y] = 0;
        _finish = (x, y);
    }

    private void CreateStart()
    {
        int x = Random.Range(_width / 4, (_width / 4) * 3);
        int y = Random.Range(_height / 4, (_height / 4) * 3);

        _mazeGrid[x, y] = 0;
        _start = (x, y);
    }

    void Divide(int x, int y, int w, int h)
    {
        if (w < 2 || h < 2)
            return;

        bool horizontal = w < h;

        if (horizontal)
        {
            int divideY = RandomNum(y + 1, y + h - 1, true);

            CreateHorizontalWall(x, divideY, w);

            int gapX = RandomNum(x + 1, x + w - 1, false);

            _mazeGrid[gapX, divideY] = 0;

            Divide(x, y, w, divideY - y);
            Divide(x, divideY + 1, w, y + h - divideY - 1);
        }
        else
        {
            int divideX = RandomNum(x + 1, x + w - 1, true);

            CreateVerticalWall(divideX, y, h);

            int gapY = RandomNum(y + 1, y + h - 1, false);

            _mazeGrid[divideX, gapY] = 0;

            Divide(x, y, divideX - x, h);
            Divide(divideX + 1, y, x + w - divideX - 1, h);
        }
    }

    private void CreateHorizontalWall(int x, int y, int length)
    {
        for (int i = 0; i < length; i++)
        {
            _mazeGrid[x + i, y] = 1;
        }
    }

    private void CreateVerticalWall(int x, int y, int length)
    {
        for (int i = 0; i < length; i++)
        {
            _mazeGrid[x, y + i] = 1;
        }
    }

    private int RandomNum(int from, int to, bool isOddNeeded)
    {
        int otp = Random.Range(from, to);
        if(otp % 2 == (isOddNeeded ? 1 : 0))
        {
            if (from + 1 <= otp) otp++;
            else otp--;
        }
        return otp;
    }

    private void RenderMaze()
    {
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                if (_mazeGrid[x, y] == 1)
                {
                    Instantiate(_wallPrefab, new Vector3(x * 2, y * 2, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(_groundPrefab, new Vector3(x * 2, y * 2, 1), Quaternion.identity);
                }
            }
        }
    }
}
