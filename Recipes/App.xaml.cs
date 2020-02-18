using System;
using MTI.XamEssentials.MxeMvvm;
using Recipes.Pages.RecipeSelectionPage;
using Recipes.Repository.ReceipeSelectionRepository;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Recipes
{
    public partial class App : Application
    {
        Page page;
        private MxeNavigationContainer _mainNavContainer;

        public App()
        {
            InitializeComponent();

            RegisterDI();
            Mapping.Mapping.RegisterMappings();
            SetMainPage();
        }

        public void SetMainPage()
        {
            page = MxePageModelResolver.ResolvePageModel<RecipeSelectionPageModel>();
            _mainNavContainer = new MxeNavigationContainer(page);
            _mainNavContainer.BarTextColor = Color.White;
            MainPage = _mainNavContainer;
        }

        private void RegisterDI()
        {
            MxeIOC.Container.Register<IRecipeSelectionRepository, MockRecipeSelectionRepository>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
