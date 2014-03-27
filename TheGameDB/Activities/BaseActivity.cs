using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TheGameDB
{
    [Activity]			
    public class BaseActivity<TViewModel> : Activity
        where TViewModel : BaseViewModel
    {
        protected readonly TViewModel viewModel;
        protected ProgressDialog progress;

        public BaseActivity()
        {
            viewModel = ServiceContainer.Resolve(typeof(TViewModel)) as TViewModel;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            progress = new ProgressDialog(this);
            progress.SetCancelable(false);
            progress.SetTitle("Loading");
        }

        protected override void OnResume()
        {
            base.OnResume();

            viewModel.IsBusyChanged += OnIsBusyChanged;
        }

        protected override void OnPause()
        {
            base.OnPause();

            viewModel.IsBusyChanged -= OnIsBusyChanged;
        }

        protected void DisplayError(Exception exc)
        {
            string error;
            AggregateException aggregate = exc as AggregateException;
            if (aggregate != null)
            {
                error = aggregate.InnerExceptions.First().Message;
            }
            else
            {
                error = exc.Message;
            }

            new AlertDialog.Builder(this)
                .SetTitle("Error!")
                .SetMessage(error)
                .SetPositiveButton("Okay", (IDialogInterfaceOnClickListener)null)
                .Show();
        }

        void OnIsBusyChanged (object sender, EventArgs e)
        {
            if (viewModel.IsBusy)
                progress.Show();
            else
                progress.Hide();
        }
    }
}

