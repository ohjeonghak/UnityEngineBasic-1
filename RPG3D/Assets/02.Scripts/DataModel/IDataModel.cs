using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.DataModel
{
    public interface IDataModel
    {
        void RequestRead(Action callBack);
        void RequestWrite(Action callBack);
    }
}