using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.MainModule
{
	public enum AddOption:int
	{
		BASIC	= 0,
		EMPTY	= 1,
		ALL		= 2
	}

	public  class Permission
	{
		[Flags]
		public enum PermissionFlags
		{
			None	= 0b_0000_0000,	//0
			None1	= 0b_0000_0001,	//1
			None2	= 0b_0000_0010	//2
		
		}

		private bool [] Permissions = new bool[50];

		public Permission(int option = (int)AddOption.EMPTY)
        {
			switch (option)
            {
				case (int)AddOption.BASIC:
					Permissions[0] = false;
					break;
				default:
					Permissions[0] = true;
					break;
            }
        }

		public bool Grant()	//권한부여
        {
			return false;
        }
		public bool Grant_all() //권한부여
		{
			return false;
		}
	}
}
