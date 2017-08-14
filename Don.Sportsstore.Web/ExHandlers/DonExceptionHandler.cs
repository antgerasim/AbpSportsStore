using Abp.Dependency;
using Abp.Events.Bus.Exceptions;
using Abp.Events.Bus.Handlers;

namespace Don.Sportsstore.Web.ExHandlers
{
    public class DonExceptionHandler : IEventHandler<AbpHandledExceptionData>, ITransientDependency
    {
        public void HandleEvent(AbpHandledExceptionData eventData)
        {
            //TODO: Check eventData.Exception!
            var test = eventData.Exception;
        }
    }
}