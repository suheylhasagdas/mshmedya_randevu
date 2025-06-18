using Microsoft.AspNetCore.Html;

namespace Core.Helpers.Media.Abstract
{
    public interface IButtonService
    {
        IHtmlContent PageNew(string buttonId = "PageNew");
        IHtmlContent PageCustom(string title = "", string buttonId = "PageCustom", string color = "primary", string awesomeIcon = "");
        IHtmlContent PageCreate(string buttonText = "Kaydet", string buttonId = "PageCreate");
        IHtmlContent PageUpdate(string buttonId = "PageUpdate");
        IHtmlContent PageRemove(string buttonId = "PageRemove");
        IHtmlContent PageUndo(string buttonId = "PageUndo");
        IHtmlContent PageSearch(string buttonId = "PageSearch");
        IHtmlContent PageFormReset(string buttonId = "PageFormReset");
        /// <summary>
        /// Login sayfası dışında kullanılmamalı!
        /// </summary>
        /// <returns></returns>
        IHtmlContent RowCheck(string id = "RowCheck");
        IHtmlContent PopupConfirm(string buttonId = "PopupConfirm");
        IHtmlContent PopupCancel(string buttonId = "PopupCancel");
    }
}
