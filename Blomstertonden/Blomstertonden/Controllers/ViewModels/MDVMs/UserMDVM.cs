using GenericsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstertonden
{
    class UserMDVM : MasterDetailsViewModelBase<UserTData, User, int>
    {
        public UserMDVM() : base(new UserVMFactory(), UserCatalog.Instance)
        {
        }

        public override void SelectedItemEvent()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(FK_Role));
            _catalog.DataPackage.Key = ItemViewModelSelected.Obj.Key;
            _deleteCommand.RaiseCanExecuteChanged();
            _updateCommand.RaiseCanExecuteChanged();
        }

        //All properties for binding to the given view
        public string Name
        {
            get => _catalog.DataPackage.Name = ItemViewModelSelected.Obj.Name;
            set => _catalog.DataPackage.Name = value;
        }
        public string Password
        {
            get => _catalog.DataPackage.Password = ItemViewModelSelected.Obj.Password;
            set => _catalog.DataPackage.Password = value;
        }
        public int FK_Role
        {
            get => _catalog.DataPackage.FK_Role = ItemViewModelSelected.Obj.FK_Role;
            set => _catalog.DataPackage.FK_Role = value;
        }

    }
}
