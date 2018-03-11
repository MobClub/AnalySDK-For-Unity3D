using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.analysdk.unity3d
{
	public abstract class  AnalySDKImpl
	{

		public virtual void trackEvent (string eventName, Hashtable customParams)
		{
		}

		public virtual void setLocation (LocationService location)
		{
		}
			
		public virtual void trackPayEvent (ALSDKPayEvent payEvent)
		{

		}

		public virtual void userRegist (ALSDKUser newUser)
		{

		}

		public virtual void userLogin (ALSDKUser loginUser)
		{

		}

		public virtual void userUpdate (ALSDKUser updateUser)
		{

		}

		public virtual void roleCreate (ALSDKRole newRole)
		{

		}

		public virtual void roleLogin (ALSDKRole loginRole)
		{

		}

		public virtual void roleUpdate (ALSDKRole updateRole)
		{

		}

	}
}


