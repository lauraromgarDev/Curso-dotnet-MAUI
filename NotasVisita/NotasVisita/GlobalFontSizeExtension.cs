using System;
using System.Collections.Generic;
using System.Text;

namespace NotasVisita
{
    internal class GlobalFontSizeExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        => MainPage.MyFontSize;
    }
}
