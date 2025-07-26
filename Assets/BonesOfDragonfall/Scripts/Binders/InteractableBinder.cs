/**************************************************************************\
   Copyright SunWorldStudio Corporation. All Rights Reserved.
\**************************************************************************/

using System;
using SkyForge.MVVM;
using SkyForge.MVVM.Binders;
using SkyForge.Reactive;

namespace BonesOfDragonfall
{
    public class InteractableBinder : EmptyMethodBinder, IInteractableBinder
    {
        private const string INTERACT_METHOD_NAME = "Interact";

        private Action<object> _action;

        public void Interact()
        {
            _action?.Invoke(null);
        }

        protected override IBinding BindInternal(IViewModel viewModel)
        {

            _action = Delegate.CreateDelegate(typeof(Action<object>), viewModel, INTERACT_METHOD_NAME) as Action<object>;

            return null;
        }
    }
}
