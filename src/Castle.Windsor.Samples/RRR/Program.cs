using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRR
{
	class Program
	{
		static void Main(string[] args)
		{
		}

		/// <summary>
		/// 创建并配置容器
		/// </summary>
		/// <returns></returns>
		public IWindsorContainer BootstrapContainer()
		{
			return new WindsorContainer()
				.Install(
					Configuration.FromAppConfig(),
					FromAssembly.This()
					//其它设置
				);
		}
	}

}
