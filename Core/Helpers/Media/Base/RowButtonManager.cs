using Core.Helpers.Abstract;
using Core.Helpers.Media.Abstract;
using Microsoft.AspNetCore.Html;
using System.Text;

namespace Core.Helpers.Media.Concrete
{
    public class RowButtonManager : IRowButtonService
    {
        private readonly ISvgIconService _icon;
        public RowButtonManager(ISvgIconService icon)
        {
            _icon = icon;


        }

        public IHtmlContent RowDelete(string id = "RowDelete")
        {

            StringBuilder sb = new StringBuilder();

            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-danger btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Sil\" title=\"Sil\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-danger\">");

            sb.Append(_icon.GeneralTrash());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowUpdate(string id = "RowUpdate")
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-warning btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Güncelle\" title=\"Güncelle\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-warning\">");

            sb.Append(_icon.CommunicationWrite());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowUndo(string id = "RowUndo")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-success btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Kurtar\" title=\"Geri Al\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append(_icon.TextUndo());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowInfo(string id = "RowInfo")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-success btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Bilgi\" title=\"Bilgi\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-primary\">");

            sb.Append(_icon.CodeInfoCircle());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowInsert(string id = "RowInsert")
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-success btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Ekle\" title=\"Ekle\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-primary\">");

            sb.Append(_icon.NavigationPlus());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

        public IHtmlContent RowCheck(string id = "RowCheck")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<a href=\"javascript:;\" class=\"btn btn-icon btn-hover-success btn-sm\" id=\"{id}\" data-toggle=\"tooltip\" data-original-title=\"Seç\" title=\"Seç\">");
            sb.Append("<span class=\"svg-icon svg-icon-md svg-icon-success\">");

            sb.Append(_icon.NavigationDoubleCheck());

            sb.Append("</span>");
            sb.Append("</a>");

            return new HtmlString(sb.ToString());
        }

    }
}
