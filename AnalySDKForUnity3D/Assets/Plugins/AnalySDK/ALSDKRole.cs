using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.analysdk.unity3d
{
	public class ALSDKRole
	{

		public string userId		{get;set;}
		public string roleId		{get;set;}
		public string roServer		{get;set;}
		public string roName		{get;set;}
		public string roCareer		{get;set;}
		public int ? roLevel		{get;set;}
		public string roVip			{get;set;}
		public int ? roRankLevel	{get;set;}
		public int ? roEnergy		{get;set;}
		public int ? roMoney		{get;set;}
		public int ? roCoin			{get;set;}
		public int ? roSource1		{get;set;}
		public int ? roSource2		{get;set;}
		public int ? roSource3		{get;set;}
		public int ? roSource4		{get;set;}

		public Hashtable customProperties;

		public ALSDKRole (string userId, string roleId)
		{
			try
			{
				this.userId = userId;
				this.roleId = roleId;
			}
			catch(Exception e) 
			{
				Console.WriteLine("{0} Exception caught.", e);
			}
		}

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



