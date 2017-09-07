using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorNavigationBar.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigationAware
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

        public SecondPageViewModel(
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

        #region ナビゲーションアイコン選択コマンド
        private ICommand _showModalCommand;
        /// <summary>
        /// ナビゲーションアイコンコマンド
        /// </summary>
        public ICommand ShowModalCommand =>
            _showModalCommand ?? (_showModalCommand = new Command(async () => await executeShowModalCommandAsync()));

        /// <summary>
        /// ナビゲーションアイコンコマンド実行
        /// </summary>
        /// <returns></returns>
        private async Task executeShowModalCommandAsync()
        {
            await _navigationService.NavigateAsync($"ModalPage", null, true);
        }
        #endregion
    }
}
