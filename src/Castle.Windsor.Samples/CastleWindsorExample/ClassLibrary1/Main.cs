using System;

namespace ClassLibrary1
{
	public class Main
	{
		private IDependency1 object1;
		private IDependency2 object2;

		/// <summary>
		/// 使用构造函数，注入依赖项
		/// </summary>
		/// <param name="dependency1"></param>
		/// <param name="dependency2"></param>
		public Main(IDependency1 dependency1, IDependency2 dependency2)
		{
			object1 = dependency1;
			object2 = dependency2;
		}

		public void DoSomething()
		{
			object1.SomeObject = $"Hello World {DateTime.Now}";
			object2.SomeOtherObject = $"Hello Mars {DateTime.Now}";
		}

		public string GetInfo()
		{
			return $"{object1.SomeObject}, {object2.SomeOtherObject}";
		}
	}
}
