using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;


namespace com.analysdk.unity3d
{
	#if UNITY_IPHONE
	public class iOSAnalySDKImpl : AnalySDKImpl
	{

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKtrackEvent (string eventName, string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKSetLocation (float latitude, float longitude);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKUserRegist (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKUserLogin (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKUserUpdate (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKRoleCreate (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKRoleLogin (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKRoleUpdate (string eventsInfo);

		[DllImport("__Internal")]
		private static extern void __iosAnalySDKTrackPayEvent (string eventsInfo);


		public override void trackEvent (string eventName, Hashtable customParams)
		{
			String json = MiniJSON.jsonEncode(customParams);

			__iosAnalySDKtrackEvent (eventName, json);
		}

		public override void setLocation (LocationService location)
		{
			float latitude = location.lastData.latitude;
			float longitude = location.lastData.longitude;

			__iosAnalySDKSetLocation (latitude, longitude);

		}
			
		public override void trackPayEvent (ALSDKPayEvent payEvent)
		{
			Hashtable hashValue = payEvent.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);

			__iosAnalySDKTrackPayEvent (json);
		}

		public override void userRegist (ALSDKUser newUser)
		{
			Hashtable hashValue = newUser.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);
			Debug.Log ("json :" + json);
			__iosAnalySDKUserRegist (json);
		}

		public override void userLogin (ALSDKUser loginUser)
		{
			Hashtable hashValue = loginUser.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);
			__iosAnalySDKUserLogin (json);
		}

		public override void userUpdate (ALSDKUser updateUser)
		{
			Hashtable hashValue = updateUser.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);
			__iosAnalySDKUserUpdate (json);
		}

		public override void roleCreate (ALSDKRole newRole)
		{
			Hashtable hashValue = newRole.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);

			Debug.Log ("json :" + json);
			__iosAnalySDKRoleCreate (json);
		}

		public override void roleLogin (ALSDKRole loginRole)
		{
			Hashtable hashValue = loginRole.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);
			__iosAnalySDKRoleLogin (json);
		}

		public override void roleUpdate (ALSDKRole updateRole)
		{
			Hashtable hashValue = updateRole.HashtableValue();
			String json = MiniJSON.jsonEncode(hashValue);
			__iosAnalySDKRoleUpdate (json);
		}


	}
	#endif
}


