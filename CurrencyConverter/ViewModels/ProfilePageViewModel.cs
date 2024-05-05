using CommunityToolkit.Mvvm.ComponentModel;
using CurrencyConverter.Models;
using CurrencyConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.ViewModels
{
    public partial class ProfilePageViewModel:ObservableObject
    {
        //public static User CurrentUser { get; set; }

        [ObservableProperty]
        private User currentUser;

        public ProfilePageViewModel()
        {
            this.CurrentUser = LocalDbConnection.CurrentUser;
        }

    }
}
