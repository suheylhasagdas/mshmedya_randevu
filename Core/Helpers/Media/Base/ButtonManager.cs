using Core.Helpers.Media.Abstract;
using Microsoft.AspNetCore.Html;
using System.Text;

namespace Core.Helpers.Media.Concrete
{
    public class ButtonManager : IButtonService
    {
        private readonly ISvgIconService _icon;
        public ButtonManager(ISvgIconService icon)
        {
            _icon = icon;
        }

        public IHtmlContent PageCustom(string title = "", string buttonId = "PageCustom", string color = "primary", string awesomeIcon = "")
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("<button");
            sb.Append($" id=\"{buttonId}\"");
            sb.Append(" type = \"button\"");
            sb.Append(" class = \"btn btn-primary font-weight-bold btn-sm mr-5\"");
            sb.Append(" >");
            if (!string.IsNullOrEmpty(awesomeIcon))
            {
                sb.Append("<i");
                sb.Append(" class=\"");
                sb.Append($"{awesomeIcon}");
                if (!string.IsNullOrEmpty(title))
                    sb.Append(" mr-2");
                sb.Append("\"");
                sb.Append("></i>");
            }

            if (!string.IsNullOrEmpty(title))
                sb.Append(title);

            sb.Append("</button>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageNew(string buttonId = "PageNew")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light btn-hover-primary btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" data-original-title=\"Yeni Kayıt\" title=\"\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-primary\">");

            sb.Append(_icon.CodePlus());

            sb.Append("</span>");
            sb.Append("Yeni Kayıt");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageCreate(string buttonText = "Kaydet", string buttonId = "PageCreate")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light btn-hover-success btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" data-original-title=\"Kaydet\" title=\"\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append(_icon.CodePlus());

            sb.Append("</span>");
            sb.Append(buttonText);
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageUpdate(string buttonId = "PageUpdate")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light-warning font-weight-bold mr-2 btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Güncelle\">");
            sb.Append("<span class=\"svg-icon svg-icon-md\">");

            sb.Append(_icon.CodeDoneCircle());

            sb.Append("</span>");
            sb.Append("Güncelle");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageRemove(string buttonId = "PageRemove")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light-danger ont-weight-bold mr-2 btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Sil\">");
            sb.Append("<span class=\"svg-icon svg-icon-md\">");

            sb.Append(_icon.GeneralTrash());

            sb.Append("</span>");
            sb.Append("Sil");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageUndo(string buttonId = "PageUndo")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light btn-hover-success btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Kaydet\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append(_icon.TextUndo());

            sb.Append("</span>");
            sb.Append("Kaydet");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageSearch(string buttonId = "PageSearch")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light btn-hover-success btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Ara\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append(_icon.GeneralSearch());

            sb.Append("</span>");
            sb.Append("Ara");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowCheck(string id = "RowCheck")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-sm mr-5 btn-clean btn-icon\" id=\"{id}\" data-toggle=\"tooltip\" title=\"Onaylı\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append("<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24px\" height=\"24px\" viewBox=\"0 0 24 24\" version=\"1.1\">");
            sb.Append("<g stroke=\"none\" stroke-width=\"1\" fill=\"none\" fill-rule=\"evenodd\">");
            sb.Append("<polygon points=\"0 0 24 0 24 24 0 24\"/>");
            sb.Append("<path d=\"M6.26193932,17.6476484 C5.90425297,18.0684559 5.27315905,18.1196257 4.85235158,17.7619393 C4.43154411,17.404253 4.38037434,16.773159 4.73806068,16.3523516 L13.2380607,6.35235158 C13.6013618,5.92493855 14.2451015,5.87991302 14.6643638,6.25259068 L19.1643638,10.2525907 C19.5771466,10.6195087 19.6143273,11.2515811 19.2474093,11.6643638 C18.8804913,12.0771466 18.2484189,12.1143273 17.8356362,11.7474093 L14.0997854,8.42665306 L6.26193932,17.6476484 Z\" fill=\"#000000\" fill-rule=\"nonzero\" transform=\"translate(11.999995, 12.000002) rotate(-180.000000) translate(-11.999995, -12.000002) \"/>");
            sb.Append("</g>");
            sb.Append("</svg>");

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PageFormReset(string buttonId = "PageFormReset")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light-danger font-weight-bold mr-2 btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Sıfırla\">");
            sb.Append("<span class=\"svg-icon svg-icon-md\">");

            sb.Append(_icon.CodeErrorCircle());

            sb.Append("</span>");
            sb.Append("Sıfırla");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PopupConfirm(string buttonId = "PopupConfirm")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light-success ont-weight-bold mr-2 btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Sil\">");
            sb.Append("<span class=\"svg-icon svg-icon-md\">");

            sb.Append(_icon.NavigationDoubleCheck());

            sb.Append("</span>");
            sb.Append("Onayla");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent PopupCancel(string buttonId = "PopupCancel")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light-danger ont-weight-bold mr-2 btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" title=\"Sil\">");
            sb.Append("<span class=\"svg-icon svg-icon-md\">");

            sb.Append(_icon.CommunicationReplyAll());

            sb.Append("</span>");
            sb.Append("İptal Et");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent SendSmsForLoginOnForgotPassword(string buttonId = "SendSms", string buttonName = "Gönder")
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-light btn-hover-primary btn-sm mr-5\" id=\"{buttonId}\" data-toggle=\"tooltip\" data-original-title=\"{buttonName}\" title=\"\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-primary\">");

            sb.Append(_icon.CommunicationSend());

            sb.Append("</span>");
            sb.Append(buttonName);
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }
    }
}
