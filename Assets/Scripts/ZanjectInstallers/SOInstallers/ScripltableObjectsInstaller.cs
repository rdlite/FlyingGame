using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ScripltableObjectsInstaller", menuName = "Installers/ScripltableObjectsInstaller")]
public class ScripltableObjectsInstaller : ScriptableObjectInstaller<ScripltableObjectsInstaller>
{
    [SerializeField] private GameConfig _gameConfig;
    [SerializeField] private ScoreData _scoreData;

    public override void InstallBindings()
    {
        Container.BindInstance(_gameConfig);
        Container.BindInstance(_scoreData);
    }
}