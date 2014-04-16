using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameDB
{
    public class ISettings
    {
		private readonly Context _context;
		private ISharedPreferences _preferences;
		private ISharedPreferencesEditor _editor;

		public ISettings(Context context)
		{
			_context = context;
		}

		public User User
		{
			get { return GetObject<User>("User"); }
			set { Put("User", value); }
		}

		public bool IsLoggedIn
		{
			get { return GetBool("IsLoggedIn"); }
			set { Put("IsLoggedIn", value); }
		}

		public void Save()
		{
			//Commit changes and dispose
			if (_editor != null)
			{
				_editor.Commit();
				_editor.Dispose();
				_editor = null;
			}
			if (_preferences != null)
			{
				_preferences.Dispose();
				_preferences = null;
			}
		}

		private T GetObject<T>(string key)
			where T : class
		{
			//Use a local instance of preferences for "Get"
			using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
			{
				string json = preferences.GetString(key, string.Empty);
				if (string.IsNullOrEmpty(json))
					return null;
				return JsonConvert.DeserializeObject<T>(json);
			}
		}

		private string GetString(string key)
		{
			//Use a local instance of preferences for "Get"
			using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
			{
				return preferences.GetString(key, string.Empty);
			}
		}

		private bool GetBool(string key)
		{
			//Use a local instance of preferences for "Get"
			using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
			{
				return preferences.GetBoolean(key, false);
			}
		}

		private int GetInt(string key)
		{
			//Use a local instance of preferences for "Get"
			using (var preferences = PreferenceManager.GetDefaultSharedPreferences(_context))
			{
				return preferences.GetInt(key, 0);
			}
		}

		private void Put(string key, object value)
		{
			CheckPreferences();

			_editor.PutString(key, JsonConvert.SerializeObject(value));
			_editor.Commit();
		}

		private void Put(string key, string value)
		{
			CheckPreferences();

			_editor.PutString(key, value);
			_editor.Commit();
		}

		private void Put(string key, bool value)
		{
			CheckPreferences();

			_editor.PutBoolean(key, value);
			_editor.Commit();
		}

		private void Put(string key, int value)
		{
			CheckPreferences();

			_editor.PutInt(key, value);
			_editor.Commit();
		}

		private void CheckPreferences()
		{
			//Create preferences & editor if needed
			if (_preferences == null)
				_preferences = PreferenceManager.GetDefaultSharedPreferences(_context);
			if (_editor == null)
				_editor = _preferences.Edit();
		}
    }
}

