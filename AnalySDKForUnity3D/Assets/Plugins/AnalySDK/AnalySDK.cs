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

		/// <summary>
		/// 统计事件.
		/// </summary>
		/// <param name="eventName">事件名称.</param>
		/// <param name="customParams">自定义参数.</param>
		public static void trackEvent (string eventName, Hashtable customParams)
		{
			analyUtils.trackEvent (eventName, customParams);
		}

		/// <summary>
		/// 设定地理位置信息.一旦设定,后续统计的时间都将带上该地理信息。使用时应在每次地理位置变动时调用此接口
		/// </summary>
		/// <param name="location">地理位置信息.</param>
		public static void setLocation (LocationService location)
		{
			analyUtils.setLocation (location);
		}

		/// <summary>
		/// 统计付费事件【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="payEvent">付费事件对象.</param>
		public static void trackPayEvent (ALSDKPayEvent payEvent)
		{
			analyUtils.trackPayEvent (payEvent);
		}

		/// <summary>
		/// 用户注册事件【使用后事件的统计会关联上该用户】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="newUser">注册的用户对象.</param>
		public static void userRegist (ALSDKUser newUser)
		{
			analyUtils.userRegist (newUser);
		}

		/// <summary>
		/// 用户登录事件【使用后事件的统计会关联上该用户】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="loginUser">登录的用户对象.</param>
		public static void userLogin (ALSDKUser loginUser)
		{
			analyUtils.userLogin (loginUser);
		}

		/// <summary>
		/// 用户信息更新事件【使用后事件的统计会关联上该用户】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="updateUser">有资料更新的用户对象.</param>
		public static void userUpdate (ALSDKUser updateUser)
		{
			analyUtils.userUpdate (updateUser);
		}

		/// <summary>
		/// 角色创建事件【使用后事件的统计会关联上该角色】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="newRole">新的角色对象.</param>
		public static void roleCreate (ALSDKRole newRole)
		{
			analyUtils.roleCreate (newRole);
		}

		/// <summary>
		/// 角色登录事件【使用后事件的统计会关联上该角色】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="newRole">登录的角色对象.</param>
		public static void roleLogin (ALSDKRole loginRole)
		{
			analyUtils.roleLogin (loginRole);
		}

		/// <summary>
		/// 角色资料更新事件【使用后事件的统计会关联上该角色】【游戏类模板统计建议使用】
		/// </summary>
		/// <param name="newRole">有更新的角色对象.</param>
		public static void roleUpdate (ALSDKRole updateRole)
		{
			analyUtils.roleUpdate (updateRole);
		}

		/// <summary>
		/// 统计事件/行为 持续时长【搭配 behaviorEnd 方法进行使用,要求标识一致】
		/// </summary>
		/// <param name="eventName">行为/事件标识.</param>
		/// /// <param name="customParams">自定义参数.</param>
		public static void behaviorStart (string eventName, Hashtable customParams)
		{
			analyUtils.behaviorStart (eventName, customParams);
		}

		/// <summary>
		/// 统计事件/行为 持续时长【搭配 behaviorStart 方法进行使用,要求标识一致】
		/// </summary>
		/// <param name="eventName">行为/事件标识.</param>
		/// /// <param name="customParams">自定义参数.</param>
		public static void behaviorEnd (string eventName, Hashtable customParams)
		{
			analyUtils.behaviorEnd (eventName, customParams);
		}


	}
}


