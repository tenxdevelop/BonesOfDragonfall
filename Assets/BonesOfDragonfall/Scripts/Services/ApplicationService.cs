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

        public void ShowMouseCursor()
        {
            Cursor.visible = true;
        }
        
    }
}