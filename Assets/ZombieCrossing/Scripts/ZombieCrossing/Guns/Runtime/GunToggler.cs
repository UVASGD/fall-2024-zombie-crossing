using UnityEngine;
using ZombieCrossing.Input.Runtime;

namespace ZombieCrossing.Guns.Runtime
{
    public class GunToggler: MonoBehaviour
    {
        [SerializeField] private GameObject[] guns;
        [SerializeField] private InputHandler inputHandler;

        private void OnEnable()
        {
            inputHandler.OnNumber += SetActiveGun;
        }

        private void OnDisable()
        {
            inputHandler.OnNumber -= SetActiveGun; 
        }

        private void Start()
        {
            SetActiveGun(1);
        }

        private void SetActiveGun(int number)
        {
            for (var i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(i == number - 1);
            }
        }
    }
}