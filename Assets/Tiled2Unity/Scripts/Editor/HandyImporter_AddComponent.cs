﻿using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;



[Tiled2Unity.CustomTiledImporter]
/// <summary>
/// 컴포넌트를 추가합니다.
/// </summary>
public class HandyImporter_AddComponent : Tiled2Unity.ICustomTiledImporter
{
    /// <summary>
    /// 사용자 정의 속성을 다룹니다.
    /// </summary>
    /// <param name="gameObject">대상 GameObject입니다.</param>
    /// <param name="customProperties">사용자 정의 속성 딕셔너리입니다.</param>
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> customProperties)
    {
        if (customProperties.ContainsKey("AddComponent"))
        {
            string typename = customProperties["AddComponent"];
            switch (typename)
            {
                case "CameraZone":
                    gameObject.AddComponent<CameraZone>();
                    break;

                case "CameraZoneBorder":
                    gameObject.AddComponent<CameraZoneBorder>();
                    break;

                case "TiledGeometryScript":
                    gameObject.AddComponent<TiledGeometryScript>();
                    break;

                default:
                    Debug.Log("Unknown component typename '" + typename + "'");
                    break;
            }
            // Debug.Log(string.Format("AddComponent.Component '{0}({1})' added", customProperties["AddComponent"], typename));
        }
        // Debug.Log("HandyImporter_AddComponent.HandleCustomProperties() called.");
    }



    /// <summary>
    /// 프리팹을 커스터마이징합니다.
    /// </summary>
    /// <param name="prefab">커스터마이징할 프리팹입니다.</param>
    public void CustomizePrefab(GameObject prefab)
    {
        // Do Nothing
    }
}
