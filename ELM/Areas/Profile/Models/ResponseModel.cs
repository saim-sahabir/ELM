namespace ELM.Areas.Profile.Models;

public class ResponseModel
{
    public string? TypeCssClass { get; private set; }
    public string? SignCssClass { get; private set; }
    public string? Message { get; set; }
    public string? HeaderText { get; set; }

    public ResponseModel(string headerText, string message, ResponseType type)
    {
        Message = message;
        HeaderText = headerText;
        TypeCssClass = type == ResponseType.Success ? "success" : "danger";
        SignCssClass = type == ResponseType.Success ? "check" : "ban";
    }


public enum ResponseType
{
    Fail,
    Success
}

}