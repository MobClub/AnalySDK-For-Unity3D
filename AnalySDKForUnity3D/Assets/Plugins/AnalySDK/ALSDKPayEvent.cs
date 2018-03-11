using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace com.analysdk.unity3d
{
	public class ALSDKPayEvent  
	{

		public int ? payMoney				{get;set;}
		public string payContent			{get;set;}
		public string payType				{get;set;}
		public string payActivity			{get;set;}
		public double ? payDiscount			{get;set;}
		public string discountReason		{get;set;}
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


