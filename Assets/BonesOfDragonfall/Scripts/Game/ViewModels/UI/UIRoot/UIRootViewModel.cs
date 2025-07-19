/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForge.Extension;
using SkyForge.Reactive;
using System.Linq;

namespace BonesOfDragonfall
{
    public class UIRootViewModel : IUIRootViewModel
    {

        public ReactiveProperty<bool> IsOpenLoadingScreen { get; private set; } = new();

        public ReactiveCollection<UIScreenView> StaticScreens { get; private set; } = new();
        public ReactiveCollection<UIScreenView> Screens { get; private set; } = new();
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        
        public void AttachUIStaticScreen(UIScreenView uIStaticScreenView)
        {
            StaticScreens.Add(uIStaticScreenView);
        }

        public void DetachUIStaticScreen(UIScreenView uIStaticScreenView)
        {
            var deleteUIStaticScreenView = StaticScreens.FirstOrDefault(screenView => screenView.Equals(uIStaticScreenView));
            
            if(deleteUIStaticScreenView is not null)
                StaticScreens.Remove(deleteUIStaticScreenView);
        }

        public void ClearUIStaticScreens()
        {
            StaticScreens.Clear();
        }

        public void AttachUIScreen(UIScreenView uIScreenView)
        {
           Screens.Add(uIScreenView);
        }

        public void DetachUIScreen(UIScreenView uIScreenView)
        {
            var deleteUIScreenView = Screens.FirstOrDefault(screenView => screenView.Equals(uIScreenView));
            
            if(deleteUIScreenView is not null)
                Screens.Remove(deleteUIScreenView);
        }

        public void ClearUIScreens()
        {
            Screens.Clear();
        }

        public void ShowLoadingScreen()
        {
            IsOpenLoadingScreen.Value = true;
        }

        public void HideLoadingScreen()
        {
            IsOpenLoadingScreen.Value = false;
        }
    }
}