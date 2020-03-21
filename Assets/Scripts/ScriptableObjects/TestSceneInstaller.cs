using UnityEngine;
using Zenject;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "TestSceneInstaller", menuName = "Installers/TestSceneInstaller")]
    public class TestSceneInstaller : ScriptableObjectInstaller<TestSceneInstaller>
    {
        public override void InstallBindings()
        {
        }
    }
}