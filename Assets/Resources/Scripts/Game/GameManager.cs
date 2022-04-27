using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static int CurrentMazeNumber { set; get; }
    public static string CurrentMazeName { set; get; }
    public static bool bIsEnterMaze { set; get; }
    public GameObject Character{ set; get; }

    private void Awake()
    {
        Instance = this;

        GameObject characterObject = Resources.Load<GameObject>("Prefabs/Character/Knight/Knight_01") as GameObject;
        if (null != characterObject)
        {
            Character = Instantiate(characterObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {

    }    
}
