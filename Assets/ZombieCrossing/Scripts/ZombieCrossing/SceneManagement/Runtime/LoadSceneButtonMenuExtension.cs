using System;
using Eflatun.SceneReference;
using Mushakushi.MenuFramework.Runtime.ExtensionFramework;
using Mushakushi.MenuFramework.Runtime.SerializableUQuery;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace ZombieCrossing.SceneManagement.Runtime
{
    [Serializable] public class LoadSceneButtonMenuExtension: MenuEventExtension<Button>
    {
        [field: SerializeField] public override UQueryBuilderSerializable Query { get; protected set; }
        [SerializeField] private SceneReference sceneReference;
        
        protected override Action OnAttach(Button button, PlayerInput playerInput)
        {
            button.clicked += LoadScene; 
            return () => button.clicked -= LoadScene;
        }

        private void LoadScene()
        {
            // if (sceneReference.State == SceneReferenceState.Unsafe) return; 
            SceneManager.LoadScene(sceneReference.Name);
        }
    }
}