using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.analysdk.unity3d
{
	public class ALSDKUser
	{
		/// <summary>
		/// 创建用户.
		/// </summary>
		/// <param name="useriD">用户id</param>
		public ALSDKUser (string userId)
		{
			try
			{
				this.userId = userId;
			} 
			catch(Exception e) 
			{
				Console.WriteLine("{0} Exception caught.", e);
			}
		}


		public enum ActionType
		{
			Reg = 0,
			Login = 1,	
		}

		/// <summary>
		/// 创建用户.
		/// </summary>
		/// <param name="useriD">用户id</param>
		/// <param name="regOrLoginType">注册或登录的类型</param>
		/// <param name="regOrLoginChannel">注册或登录的频道</param>
		/// <param name="type">操作类型,登录或是注册</param>
		public ALSDKUser(string userId, string regOrLoginType, string regOrLoginChannel, ActionType type)
		{
			try
			{
				if (type == ActionType.Reg)
				{
					this.regType = regOrLoginType;
					this.regChannel = regOrLoginChannel;
				}
				else if (type == ActionType.Login)
				{
					this.loginType = regOrLoginType;
					this.loginChannel = regOrLoginChannel;
				}

				this.userId = userId;
					
			} 
			catch(Exception e) 
			{
				Console.WriteLine("{0} Exception caught.", e);
			} 
				 
		}
			
		public string userId 		{get;set;}
		public string nickName 		{get;set;}
		public string gender 		{get;set;}
		public string country 		{get;set;}
		public string province 		{get;set;}
		public string city 			{get;set;}
		public int ? age 			{get;set;}
		public string constellation	{get;set;}
		public string zodiac		{get;set;}
		public string regType		{get;set;}
		public string regChannel	{get;set;}
		public string loginType		{get;set;}
		public string loginChannel	{get;set;}
		public string userType		{get;set;}
		public string addiction		{get;set;}
		public int ? money			{get;set;}
		public Hashtable customProperties	{get;set;}


		//将所有属性转换成hashtable形式，以方便与oc交互
		public Hashtable HashtableValue()
		{
			Type t = this.GetType();
			PropertyInfo[] PropertyList = t.GetProperties();

			Hashtable hash = new Hashtable ();

			foreach (PropertyInfo item in PropertyList)
			{
				string name = item.Name;

				if (name == "customProperties") 
				{
					object customHash = item.GetValue(this, null);

					Hashtable custom = (Hashtable)customHash;

					if (custom != null) 
					{
						Hashtable jsonHash = new Hashtable ();
						foreach (string key in custom.Keys )
						{
							string v = custom[key].ToString();

							if (v.Length > 0)
							{
								jsonHash.Add (key, v);
							}
						}

						String json = MiniJSON.jsonEncode(jsonHash);
						hash.Add (name, json);
					}

				} 
				else
				{
					object v = item.GetValue(this, null);

					if (v != null)
					{
						hash.Add ("_" + name, v);
					}

				}
			}
				
			return hash;
		}


	}
}



