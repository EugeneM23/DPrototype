using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class ShellPool : MemoryPool<Vector3, Quaternion, Vector3, float, Shell>, IShellSpawner
    {
        public Shell Create(Vector3 position, Quaternion rotation, Vector3 shellImpulse, float power)
        {
            return Spawn(position, rotation, shellImpulse, power);
        }

        protected override void Reinitialize(Vector3 position, Quaternion rotation, Vector3 shellImpulse, float power,
            Shell shell)
        {
            shell.SetPositionAndRotation(position, rotation);
            shell.SetImpulse(shellImpulse, power);
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