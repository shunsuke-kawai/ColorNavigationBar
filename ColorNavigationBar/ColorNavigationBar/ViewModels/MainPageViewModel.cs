using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorNavigationBar.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {

        /// <summary>
        /// ナビゲーションサービス
        /// </summary>
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainPageViewModel(
            INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }

        #region 次へ選択コマンド
        private ICommand _nextPageCommand;
        /// <summary>
        /// 次へコマンド
        /// </summary>
        public ICommand NextPageCommand =>
            _nextPageCommand ?? (_nextPageCommand = new Command(async () => await executeNextPageCommandAsync()));

        /// <summary>
        /// 次へコマンド実行
        /// </summary>
        /// <returns></returns>
        private async Task executeNextPageCommandAsync()
        {
            await _navigationService.NavigateAsync($"SecondPage");
        }
        #endregion
    }
}
