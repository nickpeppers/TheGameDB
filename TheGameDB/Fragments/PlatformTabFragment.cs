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
    public class PlatformTabFragment : Fragment
    {
        private List<PlatformsList> _platformList = new GamesDBService().GetPlatformsList();

        public override View OnCreateView (LayoutInflater inflater,
            ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView (inflater, container, savedInstanceState);

            var view = inflater.Inflate (Resource.Layout.PlatformTabLayout, container, false);

            var listView = view.FindViewById <ListView>(Resource.Id.PlatformTabListView);
            listView.Adapter = new ArrayAdapter<PlatformsList>(Activity, Android.Resource.Layout.SimpleListItem1, _platformList);

            listView.ItemClick += (sender, e) => 
            {
                if(!string.IsNullOrEmpty(_platformList[e.Position].PlatformId))
                {
                    var platformIntent = new Intent(Activity, typeof(PlatformActivity));
                    platformIntent.PutExtra("PlatformId", _platformList[e.Position].PlatformId);
                    StartActivity(platformIntent);
                }
            };

            return view;
        }
    }
}



