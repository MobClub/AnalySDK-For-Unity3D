using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using com.analysdk.unity3d;

public class Demo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnGUI ()
	{

		float scale = 1.0f;

		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			scale = Screen.width / 320;
		}

		float btnWidth = 200 * scale;
		float btnHeight = 45 * scale;
		float btnTop = 20 * scale;
		GUI.skin.button.fontSize = Convert.ToInt32(16 * scale);


		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "用户注册")) 
		{
			
			ALSDKUser user = new ALSDKUser ("YourUserId","YourRegType","YourRegChannel", ALSDKUser.ActionType.Reg);
			user.age = 18;
			user.nickName = "UserNickName";
			//...更多字段请参考该类文件

			Hashtable customTable = new Hashtable ();
			customTable.Add ("k1", "v1");
			customTable.Add ("k2", "v2");
			user.customProperties = customTable;

			AnalySDK.userRegist (user);

		}
		btnTop += btnHeight + 10 * scale;

		if (GUI.Button(new Rect((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight), "用户登录"))
		{

			//ALSDKUser user = new ALSDKUser ("YourUserId");
			ALSDKUser user = new ALSDKUser ("YourUserId","YourLoginType","YourLoginChannel", ALSDKUser.ActionType.Login);
			user.age = 18;
			user.nickName = "UserNickName";
			//...更多字段请参考该类文件

			AnalySDK.userLogin (user);
		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "用户信息更新")) 
		{
			ALSDKUser user = new ALSDKUser ("YourUserId");
			user.age = 18;
			user.nickName = "UserNickName";
			//...更多字段请参考该类文件

			AnalySDK.userUpdate (user);
		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "创建角色")) 
		{

			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";
			//...更多字段请参考该类文件

			AnalySDK.roleCreate (role);

		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "角色登录")) 
		{
			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";
			//...更多字段请参考该类文件

			AnalySDK.roleLogin (role);
		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "角色信息更新")) 
		{
			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";
			//...更多字段请参考该类文件
			AnalySDK.roleUpdate (role);
		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "支付事件")) 
		{
			ALSDKPayEvent payEvent = new ALSDKPayEvent ();
			payEvent.payMoney = 10000;
			payEvent.payContent = "购买月卡";
			//...更多字段请参考该类文件

			AnalySDK.trackPayEvent (payEvent);

		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "任意自定义事件")) 
		{

			Hashtable custom = new Hashtable ();
			custom.Add ("key1", "value1");
			custom.Add ("key2", "value2");
			AnalySDK.trackEvent ("CustomEvent", custom);

		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "开始统计行为")) 
		{

			Hashtable custom = new Hashtable ();
			custom.Add ("key1", "value1");
			custom.Add ("key2", "value2");
			AnalySDK.behaviorStart ("aEventName", custom);//对于同一个行为的时长统计,标识参数请保持与behaviorEnd一致

		}

		btnTop += btnHeight + 10 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "结束统计行为")) 
		{

			Hashtable custom = new Hashtable ();
			custom.Add ("key1", "value1");
			custom.Add ("key2", "value2");
			AnalySDK.behaviorEnd ("aEventName", custom); //对于同一个行为的时长统计,标识参数请保持与behaviorStart一致

		}

	}


}
