using System;
using System.Collections.Generic;
using System.Text;

namespace News.ViewModels
{
    public interface INavigate
    {
        Task NavigateTo(string route);
        Task PushModal(Page page);
        Task PopModal();
    }
}
