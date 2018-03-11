using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.analysdk.unity3d
{
	public class AnalySDK : MonoBehaviour {

		private static bool isInit;
		private static AnalySDK _instance;
		private static AnalySDKImpl analyUtils;

		void Awake()
		{
			if (!isInit) 
			{
				
				#if UNITY_ANDROID
				analyUtils = new AndroidAnalySDKImpl();
				#elif UNITY_IPHONE
				analyUtils = new iOSAnalySDKImpl();
				#endif
				isInit = true;
			}

			if (_instance != null) 
			{
				DestroyObject (_instance.gameObject);
			}
			_instance = this;

			DontDestroyOnLoad(this.gameObject);
		}
			
		public static void trackEvent (string eventName, Hashtable customParams)
		{
			analyUtils.trackEvent (eventName, customParams);
		}

		public static void setLocation (LocationService location)
		{
			analyUtils.setLocation (location);
		}

		public static void trackPayEvent (ALSDKPayEvent payEvent)
		{
			analyUtils.trackPayEvent (payEvent);
		}

		public static void userRegist (ALSDKUser newUser)
		{
			analyUtils.userRegist (newUser);
		}

		public static void userLogin (ALSDKUser loginUser)
		{
			analyUtils.userLogin (loginUser);
		}

		public static void userUpdate (ALSDKUser updateUser)
		{
			analyUtils.userUpdate (updateUser);
		}

		public static void roleCreate (ALSDKRole newRole)
		{
			analyUtils.roleCreate (newRole);
		}

		public static void roleLogin (ALSDKRole loginRole)
		{
			analyUtils.roleLogin (loginRole);
		}

		public static void roleUpdate (ALSDKRole updateRole)
		{
			analyUtils.roleUpdate (updateRole);
		}


	}
}


