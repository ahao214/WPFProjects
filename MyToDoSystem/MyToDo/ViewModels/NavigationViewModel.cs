using MyToDo.Extensions;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace MyToDo.ViewModels
{
    public class NavigationViewModel :BindableBase, INavigationAware
    {
        private readonly IContainerProvider _containerProvider;
        public readonly IEventAggregator aggregator;
        public NavigationViewModel(IContainerProvider containerProvider)
        {
            _containerProvider = containerProvider;
            aggregator = _containerProvider.Resolve<IEventAggregator>();
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }


        public void UpdateLoading(bool IsOpen)
        {
            aggregator.UpdateLoading(new Common.Events.UpdateModel()
            {
                IsOpen = IsOpen
            });
        }

    }
}
