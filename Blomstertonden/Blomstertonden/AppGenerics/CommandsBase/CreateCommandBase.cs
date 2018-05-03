using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLibrary
{
    public class CreateCommandBase<TData, T, TKey> : CommandBase<TData, T, TKey>
        where TData : IKey<TKey>, new()
        where T : IKey<TKey>, new()
    {
        public CreateCommandBase(ICRUD<T, TData, TKey> catalog, MasterDetailsViewModelBase<TData, T, TKey> viewModel)
        :base(catalog, viewModel){}
        public override void ExecuteEvent()
        {
            _viewModel.RefreshItemViewModelCollection();
        }
        public override bool CanExecute()
        {
            return true;
        }
        public override void Execute()
        {
            _catalog.Create(_viewModel.DataPackage);
            ExecuteEvent();
        }
    }
}
