using System;
using System.Collections.Generic;
using System.Text;

namespace TheGameDB
{
    public class BaseViewModel
    {
        protected readonly ISettings settings = ServiceContainer.Resolve<ISettings>();

        public event EventHandler IsBusyChanged = delegate { };

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                IsBusyChanged(this, EventArgs.Empty);
            }
        }
    }
}

