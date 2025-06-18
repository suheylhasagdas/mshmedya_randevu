using Microsoft.AspNetCore.Html;

namespace Core.Helpers.Media.Abstract
{
    public interface IRowButtonService
    {
        IHtmlContent RowDelete(string id = "RowDelete");
        IHtmlContent RowUpdate(string id = "RowUpdate");
        IHtmlContent RowUndo(string id = "RowUndo");
        IHtmlContent RowInfo(string id = "RowInfo");
        IHtmlContent RowInsert(string id = "RowInsert");
        IHtmlContent RowCheck(string id = "RowCheck");
    }
}
