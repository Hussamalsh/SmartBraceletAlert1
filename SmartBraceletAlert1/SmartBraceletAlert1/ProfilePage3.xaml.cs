﻿using SmartBraceletAlert1.Managers;
using SmartBraceletAlert1.Managers.Contracts;
using SmartBraceletAlert1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SmartBraceletAlert1
{
    public partial class ProfilePage3 : ContentPage, INotifyPropertyChanged
    {

        readonly IProfileManager _profileManager;
        Profile _profile;

        IProfileManager profileManager = new ProfileManager();
        public ProfilePage3()
        {
            _profileManager = profileManager;
            Title = "Profile";
            LoadProfile();
            
            InitializeComponent();
            username.Text = _profile.FBusername;
            image.Source = _profile.FBimage;
        }


        void LoadProfile()
        {
            _profile = _profileManager.LoadProfile();
        }

        /*ICommand _doSaveProfile;
        public ICommand DoSaveProfile
        {
            get
            {
                _doSaveProfile = _doSaveProfile ?? new Command(SaveProfile);
                return _doSaveProfile;
            }
        }*/

        void OnclickedSaveProfile(object sender, EventArgs e)
        {

            SaveProfile();


        }

        void SaveProfile()
        {
            _profileManager.SaveProfile(_profile);
        }

        public string Username
        {
            get
            {
                return _profile.Username;
            }
            set
            {
                if (_profile.Username != value)
                {
                    _profile.Username = value;
                    RaisePropertyChanged("Username");
                }
            }
        }

        public string Firstname
        {
            get
            {
                return _profile.Firstname;
            }
            set
            {
                if (_profile.Firstname != value)
                {
                    _profile.Firstname = value;
                    RaisePropertyChanged("Firstname");
                }
            }
        }

        public bool NotifyNews
        {
            get
            {
                return _profile.NotifyNews;
            }
            set
            {
                if (_profile.NotifyNews != value)
                {
                    _profile.NotifyNews = value;
                    RaisePropertyChanged("NotifyNews");
                }
            }
        }

        public bool NotifyFriends
        {
            get
            {
                return _profile.NotifyFriends;
            }
            set
            {
                if (_profile.NotifyFriends != value)
                {
                    _profile.NotifyFriends = value;
                    RaisePropertyChanged("NotifyFriends");
                }
            }
        }

        public string Image
        {
            get
            {
                return _profile.FBimage;
            }
            set
            {
                if (_profile.FBimage != value)
                {
                    _profile.FBimage = value;
                    RaisePropertyChanged("Image");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
