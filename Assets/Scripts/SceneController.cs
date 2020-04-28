using UnityEngine;
using UnityEngine.AI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private SceneCreator sceneCreator;

    [SerializeField]
    private NavMeshSurface navMesh;

    void Start()
    {
        sceneCreator.CreateScene(Levels.Level3);
        navMesh.BuildNavMesh();
        //Time.timeScale = 2f;
    }

    public void Refresh()
    {
        sceneCreator.Refresh(Levels.Level3);
    }

    void Update()
    {

    }
}