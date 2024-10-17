using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField]
    private MazeGenerator _mazeGenerator;
    [SerializeField]
    private Transform _charPosition;
    [SerializeField]
    private Color _wallColor;
    [SerializeField]
    private Color _groundColor;
    [SerializeField]
    private Color _unexploredColor;
    [SerializeField]
    private int _revealRadius = 2;

    private int[,] _mazeGrid;
    private Texture2D _minimapTexture;
    private (int Width, int Height) _size;

    void Start()
    {
        _mazeGrid = _mazeGenerator.GetMazeGrid;

        _size = (_mazeGrid.GetLength(0), _mazeGrid.GetLength(1));

        _minimapTexture = new Texture2D(_size.Width, _size.Height);
        _minimapTexture.name = "map";
        _minimapTexture.filterMode = FilterMode.Point;
        _minimapTexture.wrapMode = TextureWrapMode.Clamp;

        for (int x = 0; x < _size.Width; x++)
        {
            for (int y = 0; y < _size.Height; y++)
                _minimapTexture.SetPixel(x, y, _unexploredColor);
        }

        _minimapTexture.Apply();
        this.GetComponent<RawImage>().texture = _minimapTexture;
    }

    private int counter = 0;
    void Update()
    {
        counter++;
        if(counter > 200)
        {
            counter = 0;
            DiscoverCells();
        }
    }

    private void DiscoverCells()
    {
        Vector2Int cur = new Vector2Int((int)(_charPosition.position.x / 2), (int)(_charPosition.position.y / 2));

        for (int dx = -_revealRadius; dx <= _revealRadius; dx++)
        {
            for (int dy = -_revealRadius; dy <= _revealRadius; dy++)
            {
                int nx = cur.x + dx;
                int ny = cur.y + dy;

                if (nx >= 0 && nx < _size.Width && ny >= 0 && ny < _size.Height)
                {
                    if (_mazeGrid[nx, ny] == 0)
                        _minimapTexture.SetPixel(nx, ny, _groundColor);
                    else if (_mazeGrid[nx, ny] == 1)
                        _minimapTexture.SetPixel(nx, ny, _wallColor);
                }
            }
        }

        _minimapTexture.Apply();
    }
}
