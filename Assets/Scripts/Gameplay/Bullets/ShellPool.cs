using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ShellPool : MemoryPool<Vector3, Quaternion, Shell>, IShellSpawner
    {
        public Shell Create(Vector3 position, Quaternion rotation)
        {
            return Spawn(position, rotation);
        }

        protected override void Reinitialize(Vector3 position, Quaternion rotation, Shell shell)
        {
            shell.SetPositionAndRotation(position, rotation);
        }

        protected override void OnSpawned(Shell shell)
        {
            base.OnSpawned(shell);
            shell.gameObject.SetActive(true);
            shell.OnDispose += Despawn;
        }

        protected override void OnDespawned(Shell shell)
        {
            base.OnDespawned(shell);
            shell.gameObject.SetActive(false);
            shell.OnDispose -= Despawn;
        }
    }
}