﻿using SWTC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SWTC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditWorkDay : ContentPage
    {
        //Dirty way to pass workday id vm to vm
        public EditWorkDay(int id)
        {
            InitializeComponent();

            BindingContext = new EditWorkDaysViewModel(Navigation, id);
        }
    }
}