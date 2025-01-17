using RPG.Singleton;
using RPG.UI;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

namespace RPG.EventSystems
{
    public class InputManager : MonoSingleton<InputManager>
    {
       public class Map
        {
            private Dictionary<KeyCode, Action> _keyDownActions = new Dictionary<KeyCode, Action>();
            private Dictionary<KeyCode, Action> _keyPressActions = new Dictionary<KeyCode, Action>();
            private Dictionary<KeyCode, Action> _keyUpActions = new Dictionary<KeyCode, Action>();
            private Dictionary<string, Action<float>> _axisActions = new Dictionary<string, Action<float>>(); 

            public void AddKeyDonwAction(KeyCode keyCode, Action action)
            {
                if (_keyDownActions.ContainsKey(keyCode))
                    _keyDownActions[keyCode] += action;
                else
                    _keyDownActions.Add(keyCode, action);
            }

            public void AddKeyPressAction(KeyCode keyCode, Action action)
            {
                if (_keyPressActions.ContainsKey(keyCode))
                    _keyPressActions[keyCode] += action;
                else
                    _keyPressActions.Add(keyCode, action);
            }

            public void AddKeyUPAction(KeyCode keyCode, Action action)
            {
                if (_keyUpActions.ContainsKey(keyCode))
                    _keyUpActions[keyCode] += action;
                else
                    _keyUpActions.Add(keyCode, action);
            }
            public void AddAxisAction(string axis, Action <float> action)
            {
                if (_axisActions.ContainsKey(axis))
                    _axisActions[axis] += action;
                else
                    _axisActions.Add(axis, action);
            }

            public void DoActions()
            {
                foreach (var item in _keyDownActions)
                {
                    if (Input.GetKeyDown(item.Key))
                        item.Value.Invoke();
                }

                foreach (var item in _keyPressActions)
                {
                    if (Input.GetKey(item.Key))
                        item.Value.Invoke();
                }

                foreach (var item in _keyUpActions)
                {
                    if (Input.GetKeyUp(item.Key))
                        item.Value.Invoke();
                }

                foreach (var item in _axisActions)
                {
                     item.Value.Invoke(Input.GetAxis(item.Key));
                }
            }
        }
        public Dictionary<string, Map> keyMaps = new Dictionary<string, Map>();
        public string current;

        protected override void Awake()
        {
            base.Awake();
            BasicKeyMapsSetUp();
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(current))
                return;

            keyMaps[current].DoActions();
        }

        private void BasicKeyMapsSetUp()
        {
            keyMaps.Add("Player", new Map());            
            keyMaps["Player"].AddKeyDonwAction(
#if UNITY_EDITOR               
                KeyCode.BackQuote,
                () =>
                {
                    UIManager.instance.Get<ConfirmWindowUI>()
                                        .Show("Really want to exit game?", () => EditorApplication.ExitPlaymode());
                });
#else
                KeyCode.Escape,
                () =>
                {
                   UIManager.instance.Get<ConfirmWindowUI>()
                                       .Show("Really want to exit game?", () => Application.Quit());
                });
#endif
            keyMaps["Player"].AddKeyDonwAction(KeyCode.I, () =>
            {
                UIManager.instance.Get<InventoryUI>().Show();
            });
            keyMaps["Player"].AddKeyDonwAction(KeyCode.E, () =>
            {
                UIManager.instance.Get<ItemsEquippedUI>().Show();
            });

            keyMaps.Add("PopUpUI", new Map());
            keyMaps["PopUpUI"].AddKeyDonwAction(
#if UNITY_EDITOR               
                KeyCode.BackQuote,
                 () =>
                 {
                     UIManager.instance.HideLast();
                 });
#else
                KeyCode.Escape,
                {
                   UIManager.instance.Get<ConfirmWindowUI>()
                                       .Show("Really want to exit game?", () => Application.Quit());
                });
#endif

            keyMaps["Player"].AddKeyDonwAction(KeyCode.I, () =>
            {
                InventoryUI uI = UIManager.instance.Get<InventoryUI>();
                if (uI.gameObject.activeSelf)
                    uI.Hide();
                else
                    uI.Show();


            });
            keyMaps["PopupUI"].AddKeyDonwAction(KeyCode.E, () =>
            {
               ItemsEquippedUI uI = UIManager.instance.Get<ItemsEquippedUI>();
                if(uI.gameObject.activeSelf)
                    uI.Hide();
                else
                    uI.Show();
            });
            current = "Player";
        }
    }
}