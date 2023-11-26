﻿using HumanResourcesApplication_DoAn.Views.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesApplication_DoAn.ViewModel.Admin
{
    public class EmployeeMainViewViewModel:ViewModelBase
    {
        //fields
        ViewModelBase _currentEmployeeChildView;
        EmployeeAllViewModel _employeeAllViewModel;
        LeaveRequestsViewModel _leaveRequestsViewModel;
        EmployeeViewViewModel _employeeViewViewModel;
        //properties
        public ViewModelBase CurrentEmployeeChildView 
        {   get => _currentEmployeeChildView;
            set
            {
                _currentEmployeeChildView = value;
                OnPropertyChanged(nameof(CurrentEmployeeChildView));
            }

        }
        public EmployeeAllViewModel EmployeeAllViewModel 
        { 
            get => _employeeAllViewModel; 
            set
            {
                _employeeAllViewModel = value;
                OnPropertyChanged(nameof(EmployeeAllViewModel));
            }
        }
        public LeaveRequestsViewModel LeaveRequestsViewModel 
        { 
            get => _leaveRequestsViewModel; 
            set
            {
                _leaveRequestsViewModel = value;
                OnPropertyChanged(nameof(LeaveRequestsViewModel));
            }
        }
        internal EmployeeViewViewModel EmployeeViewViewModel 
        { 
            get => _employeeViewViewModel; 
            set
            {
                _employeeViewViewModel = value;
                OnPropertyChanged(nameof(EmployeeViewViewModel));
            }
        }
        //Commands
        public ViewModelCommand ShowEmployeeAllViewCommand { get; }
        public ViewModelCommand ShowLeaveRequestViewCommand { get; }
        public ViewModelCommand ShowEmployeeViewCommand { get; }
        //Constructor
        public EmployeeMainViewViewModel()
        {
            ShowEmployeeAllViewCommand = new ViewModelCommand(ExcuteShowEmployeeAllViewCommand);
            ShowEmployeeViewCommand = new ViewModelCommand(ExcuteShowEmployeeViewCommand);
            ShowLeaveRequestViewCommand = new ViewModelCommand(ExcuteShowEmployeeLeaveRequestViewCommand);
            //default view 
            ExcuteShowEmployeeAllViewCommand(null);
        }

        private void ExcuteShowEmployeeLeaveRequestViewCommand(object? obj)
        {
            if (_leaveRequestsViewModel == null) { }
                _leaveRequestsViewModel = new LeaveRequestsViewModel();
            CurrentEmployeeChildView = _leaveRequestsViewModel;
        }

        private void ExcuteShowEmployeeViewCommand(object? obj)
        {
            if (_employeeViewViewModel == null) { }
                _employeeViewViewModel = new EmployeeViewViewModel();
            CurrentEmployeeChildView = _employeeViewViewModel;
        }

        private void ExcuteShowEmployeeAllViewCommand(object? obj)
        {
            if (_employeeAllViewModel == null) { }
                _employeeAllViewModel = new EmployeeAllViewModel();
            CurrentEmployeeChildView = _employeeAllViewModel;
        }
    }
}
