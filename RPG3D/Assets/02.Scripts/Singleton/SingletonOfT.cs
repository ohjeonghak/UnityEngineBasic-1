using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;


    namespace RPG.Singleton
    {
        public class Singleton<T>
            where T : Singleton<T>
        {
         public static T instance
         {
            get
            {
                if (_instance == null)
                {
                    //ConstructorInfo constructorInfo = typeof(T).GetConstructor(new Type[] { });
                    //_instance = constructorInfo.Invoke(new object[] { }) as T;

                    _instance = Activator.CreateInstance<T>();
                }
                return _instance;
            }
         }
         private static T _instance;
        }
    }
