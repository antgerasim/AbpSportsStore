using Abp.Web.Mvc.Views;

namespace Don.Sportsstore.Web.Views
{
    public abstract class SportsstoreWebViewPageBase : SportsstoreWebViewPageBase<dynamic>
    {

    }

    public abstract class SportsstoreWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected SportsstoreWebViewPageBase()
        {
            LocalizationSourceName = SportsstoreConsts.LocalizationSourceName;
        }
    }
}