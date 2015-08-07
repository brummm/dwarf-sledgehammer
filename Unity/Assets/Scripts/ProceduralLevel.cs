using UnityEngine;
using System.Collections;
using Level;
using Player;
using Enemy;

/// <summary>
/// This is the core class to the game.
/// It will load all the others classes "procedurally".
/// </summary>
public class ProceduralLevel : MonoBehaviour {

    private LevelLoader levelLoaderInstance;


    /// <summary>
    /// The current level name will, by default, be it's number plus 1
    /// </summary>
    private int _currentLevel = 1;
    public int CurrentLevel {
        get {
            return _currentLevel;
        }
        set{
            _currentLevelInstance = null;
            _currentLevel = value;
        }
    }


    private string environmentPlaceholderPrefabName;

    private GameObject _environmentPlaceholder;
    public GameObject EnvironmentPlaceholder
    {
        get
        {
            if (environmentPlaceholderPrefabName != CurrentLevelInstance.EnvironmentPlaceholderPrefabName)
            {
                environmentPlaceholderPrefabName = CurrentLevelInstance.EnvironmentPlaceholderPrefabName;
                _environmentPlaceholder = Instantiate(Resources.Load<GameObject>("Prefabs/EnvironmentPlaceholders/" + environmentPlaceholderPrefabName));
            }
            return _environmentPlaceholder;
        }
        set { _environmentPlaceholder = value;  }
    }


    /// <summary>
    /// To be used as the instance of current level
    /// </summary>
    private BaseLevel _currentLevelInstance;
    public BaseLevel CurrentLevelInstance
    {
        get
        {
            if (_currentLevelInstance==null)
            {
                _currentLevelInstance = levelLoaderInstance.Load(CurrentLevel);
            }
            return _currentLevelInstance;
        }
    }

    private PlayerAvatar playerAvatarInstance;

    void Awake()
    {
        levelLoaderInstance = new LevelLoader();
    }

	// Use this for initialization
	void Start () {
        SetupPlayer();
        SetupLevel();
        SetupHud();
        LoadInventory();

        // TEMP
        InstantiateEnemyPlaceholders();
        // /TEMP

        SetupEvents();
        StartCurrentLevel();
	}

    

    private void InstantiateEnemyPlaceholders() {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("EnemyPlaceholder");
        foreach (GameObject go in gos)
        {
            EnemyPlaceholder ep = go.AddComponent<EnemyPlaceholder>();
            ep.EnemyPlaceholderHitDown += playerAvatarInstance.OnEnemyPlaceholderHitDown;
            ep.EnemyPlaceholderHitUp += playerAvatarInstance.OnEnemyPlaceholderHitUp;
        }
    }

    

    void StartCurrentLevel()
    {
        GameObject thisGameObject = this.gameObject;
        CurrentLevelInstance.StartLevel();
    }
	

	void Update () {
        if (CurrentLevelInstance.IsFinished())
        {
            SetCurrentLevelToTheNext();
            StartCurrentLevel();
        }
	}

    void SetupPlayer()
    {
        playerAvatarInstance = gameObject.AddComponent<PlayerAvatar>();
    }

    void SetupLevel()
    {

    }

    void SetupHud()
    {

    }

    void LoadInventory()
    {

    }

    /// <summary>
    /// Here we will set the publishers and the subscribers to the events
    /// </summary>
    private void SetupEvents()
    {
        // TODO: use this to setup events
        // player events
        //playerAvatarInstance.PlayerAvatarGetHit += lifeInstance.OnPlayerAvatarGetHit;
    }

    void SetCurrentLevelToTheNext()
    {
        CurrentLevel++;
    }


}
