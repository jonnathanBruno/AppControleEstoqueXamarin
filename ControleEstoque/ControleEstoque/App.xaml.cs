using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ControleEstoque.View;
using Xamarin.Forms;
using ControleEstoque.Models;

namespace ControleEstoque
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();
            //MainPage = new ControleEstoque.View.Login();
            MainPage = new NavigationPage(new ControleEstoque.MainPage());
        }

		protected override void OnStart ()
		{
            //MessagingCenter.Subscribe<Empresa[]>(this, "SucessoLogin",
            //    (empresa) =>
            //    {
            //        MainPage = new NavigationPage(new ControleEstoque.MainPage());
            //    });
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
