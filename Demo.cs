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
			ALSDKUser user = new ALSDKUser ("YourUserId");

			user.age = 18;
			user.nickName = "UserNickName";
			Hashtable customTable = new Hashtable ();
			customTable.Add ("k1", "v1");
			customTable.Add ("k2", "v2");
			user.customProperties = customTable;
			Hashtable hash = user.HashtableValue ();

			AnalySDK.userRegist (user);

		}
		btnTop += btnHeight + 20 * scale;

		if (GUI.Button(new Rect((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight), "用户登录"))
		{

			//ALSDKUser user = new ALSDKUser ("YourUserId");
			ALSDKUser user = new ALSDKUser ("YourUserId","YourLoginType","YourLoginChannel", ALSDKUser.ActionType.Login);
			user.age = 18;
			user.nickName = "UserNickName";
			//...

			AnalySDK.userLogin (user);
		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "用户信息更新")) 
		{
			//ALSDKUser user = new ALSDKUser ("YourUserId");
			ALSDKUser user = new ALSDKUser ("YourUserId","YourLoginType","YourLoginChannel", ALSDKUser.ActionType.Login);
			user.age = 18;
			user.nickName = "UserNickName";
			//...

			AnalySDK.userUpdate (user);
		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "创建角色")) 
		{

			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";

			AnalySDK.roleCreate (role);

		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "角色登录")) 
		{
			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";

			AnalySDK.roleLogin (role);
		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "角色信息更新")) 
		{
			ALSDKRole role = new ALSDKRole ("YourUserId", "YourRoleId");
			role.roLevel = 100;
			role.roVip = "bigViP";

			AnalySDK.roleUpdate (role);
		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "支付事件")) 
		{
			ALSDKPayEvent payEvent = new ALSDKPayEvent ();
			payEvent.payMoney = 10000;
			payEvent.payDiscount = 0.99;

			Hashtable custom = new Hashtable ();
			custom.Add ("key1", "value1");
			payEvent.customProperties = custom;

			AnalySDK.trackPayEvent (payEvent);

		}

		btnTop += btnHeight + 20 * scale;

		if (GUI.Button (new Rect ((Screen.width - btnWidth) / 2, btnTop, btnWidth, btnHeight),  "任意自定义事件")) 
		{

			Hashtable custom = new Hashtable ();
			custom.Add ("key1", "value1");
			custom.Add ("key2", "value2");
			AnalySDK.trackEvent ("CustomEvent", custom);

		}

	}


}
