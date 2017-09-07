using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorNavigationBar.ViewModels
{
    public class ModalPageViewModel : BindableBase, INavigationAware
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

        public ModalPageViewModel(
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

        #region 閉じる選択コマンド
        private ICommand _closeCommand;
        /// <summary>
        /// 閉じるコマンド
        /// </summary>
        public ICommand CloseCommand =>
            _closeCommand ?? (_closeCommand = new Command(async () => await executeCloseCommandAsync()));

        /// <summary>
        /// 閉じるコマンド実行
        /// </summary>
        /// <returns></returns>
        private async Task executeCloseCommandAsync()
        {
            await _navigationService.GoBackAsync();
        }
        #endregion
    }
}
