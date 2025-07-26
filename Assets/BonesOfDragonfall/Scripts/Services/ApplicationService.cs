/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using UnityEditor;
using UnityEngine;
using System;

namespace BonesOfDragonfall
{
    public class ApplicationService : IDisposable
    {
        
        public void Dispose()
        {
            
        }
        
        public void CloseGame()
        {
            
#if DEBUG
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();            
#endif
        }

        public void HideMouseCursor()
        {
            Cursor.visible = false;
        }

        public bool ShowMouseCursor()
        {
            var visibleBefore = Cursor.visible;
            Cursor.visible = true;
            return visibleBefore;
        }

        public float StopTimeGame()
        {
            var timeScaleBefore = Time.timeScale;
            Time.timeScale = 0;
            return timeScaleBefore;
        }

        public void StartTimeGame()
        {
            Time.timeScale = 1;
        }
        
    }
}