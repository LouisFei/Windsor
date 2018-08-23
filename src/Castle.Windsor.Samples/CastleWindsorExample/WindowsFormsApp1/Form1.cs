using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// create a windsor container object and register the interfaces, and their concrete implementations.
			var container = new WindsorContainer();
			container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.Main>());
			container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.IDependency1>().ImplementedBy<ClassLibrary1.Dependency1>());
			container.Register(Castle.MicroKernel.Registration.Component.For<ClassLibrary1.IDependency2>().ImplementedBy<ClassLibrary1.Dependency2>());

			// create the main object and invoke its methods as desired.
			var mainThing = container.Resolve<ClassLibrary1.Main>();
			mainThing.DoSomething();

			var info = mainThing.GetInfo();

			MessageBox.Show(info);
		}
	}
}
