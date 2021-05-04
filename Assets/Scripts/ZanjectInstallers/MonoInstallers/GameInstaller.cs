using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    protected GameConfig _config;

    [Inject]
    private void Construct(GameConfig config)
    {
        _config = config;
    }

    public override void InstallBindings()
    {
        Container.BindFactory<Obstacle, Obstacle.ObstacleFactory>().FromComponentInNewPrefab(_config.AsteroidPrefab);
    }
}