using System;
using MTI.XamEssentials.MxeMvvm;
using MTI.XamEssentials.Services;
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
        private IToastService _toastService;

        public App()
        {
            InitializeComponent();

            RegisterDI();
            //This isn't working on iOS right now
            _toastService = MxeIOC.Container.Resolve<IToastService>();
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
